using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace SigecomTestesUI.Gerenciador;

public class Requirement
{
    public string Id { get; init; }
    public string Name { get; init; }
    public string Help { get; init; }
    public bool Installable { get; init; } = true;
    public bool Ok { get; set; }
    public string Detail { get; set; }
}

/// <summary>Localiza o dotnet.exe mesmo quando acabou de ser instalado e o PATH do processo está desatualizado.</summary>
public static class DotnetLocator
{
    public static string Path
    {
        get
        {
            var fromPath = (Environment.GetEnvironmentVariable("PATH") ?? "")
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(d => { try { return System.IO.Path.Combine(d.Trim(), "dotnet.exe"); } catch { return null; } })
                .FirstOrDefault(p => p != null && File.Exists(p));
            if (fromPath != null) return fromPath;

            var candidates = new[]
            {
                System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "dotnet", "dotnet.exe"),
                System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft", "dotnet", "dotnet.exe")
            };
            return candidates.FirstOrDefault(File.Exists) ?? "dotnet";
        }
    }

    public static string Run(params string[] args)
    {
        try
        {
            var psi = new ProcessStartInfo(Path)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.UTF8
            };
            foreach (var a in args) psi.ArgumentList.Add(a);
            using var p = Process.Start(psi);
            var output = p.StandardOutput.ReadToEnd();
            p.WaitForExit(15000);
            return output;
        }
        catch { return ""; }
    }
}

public static class Requirements
{
    public const string WinAppDriverPadrao = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";
    public const string SigecomPadrao = @"C:\SIGECOM\SIGECOM.exe";

    /// <summary>Caminhos efetivos (configurados em Caminhos… ou o padrão); definidos a partir do Settings.</summary>
    public static string WinAppDriverExe { get; set; } = WinAppDriverPadrao;
    public static string SigecomExe { get; set; } = SigecomPadrao;

    public static void Aplicar(Settings s)
    {
        WinAppDriverExe = string.IsNullOrWhiteSpace(s.WinAppDriverPath) ? WinAppDriverPadrao : s.WinAppDriverPath;
        SigecomExe = string.IsNullOrWhiteSpace(s.SigecomExePath) ? SigecomPadrao : s.SigecomExePath;
    }
    private const string WinAppDriverMsi = "https://github.com/microsoft/WinAppDriver/releases/download/v1.2.1/WindowsApplicationDriver_1.2.1.msi";

    public static List<Requirement> Check()
    {
        var list = new List<Requirement>();

        // Modo desenvolvedor (exigido pelo WinAppDriver)
        var dev = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\AppModelUnlock",
            "AllowDevelopmentWithoutDevLicense", 0) is int v && v == 1;
        list.Add(new Requirement
        {
            Id = "devmode", Name = "Modo desenvolvedor do Windows", Ok = dev,
            Help = "Necessário para o WinAppDriver controlar aplicativos.",
            Detail = dev ? "Ativado" : "Desativado"
        });

        // WinAppDriver
        var wad = File.Exists(WinAppDriverExe);
        list.Add(new Requirement
        {
            Id = "winappdriver", Name = "Windows Application Driver (WinAppDriver)", Ok = wad,
            Help = "Ponte que permite aos testes clicarem e digitarem no Sigecom.",
            Detail = wad ? "Instalado" : "Não encontrado em " + WinAppDriverExe
        });

        // .NET SDK
        var sdks = DotnetLocator.Run("--list-sdks");
        var maiorSdk = Regex.Matches(sdks, @"^(\d+)\.", RegexOptions.Multiline)
            .Select(m => int.Parse(m.Groups[1].Value)).DefaultIfEmpty(0).Max();
        var sdkOk = maiorSdk >= 6;
        list.Add(new Requirement
        {
            Id = "sdk", Name = ".NET SDK (6 ou superior)", Ok = sdkOk,
            Help = "Compila e executa os testes (comando dotnet).",
            Detail = sdkOk ? $"SDK {maiorSdk}.x instalado" : "Não encontrado"
        });

        // Runtime 3.1 (o projeto de testes é netcoreapp3.1)
        var runtimes = DotnetLocator.Run("--list-runtimes");
        var rt31 = Regex.IsMatch(runtimes, @"^Microsoft\.NETCore\.App 3\.1\.", RegexOptions.Multiline);
        list.Add(new Requirement
        {
            Id = "runtime31", Name = ".NET Core 3.1 Runtime", Ok = rt31,
            Help = "O projeto de testes ainda roda em .NET Core 3.1.",
            Detail = rt31 ? "Instalado" : "Não encontrado"
        });

        // Sigecom (só informativo)
        var sig = File.Exists(SigecomExe);
        list.Add(new Requirement
        {
            Id = "sigecom", Name = "Sigecom instalado", Ok = sig, Installable = false,
            Help = "Os testes abrem " + SigecomExe + ".",
            Detail = sig ? "Encontrado" : "Não encontrado — instale o Sigecom normalmente"
        });

        return list;
    }

    /// <summary>Gera o script PowerShell (rodado como administrador) para os requisitos informados.</summary>
    public static string BuildScript(IEnumerable<string> ids, string logPath)
    {
        var set = ids.ToHashSet();
        var sb = new StringBuilder();
        sb.AppendLine("$ErrorActionPreference = 'Stop'");
        sb.AppendLine("[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12");
        sb.AppendLine("$ProgressPreference = 'SilentlyContinue'");
        sb.AppendLine($"Start-Transcript -Path '{logPath}' -Force | Out-Null");
        sb.AppendLine("$falhas = 0");
        sb.AppendLine("function Passo($nome, [scriptblock]$acao) {");
        sb.AppendLine("  Write-Host \"==> $nome\"");
        sb.AppendLine("  try { & $acao; Write-Host \"OK: $nome\" } catch { Write-Host \"ERRO: $nome - $($_.Exception.Message)\"; $script:falhas++ }");
        sb.AppendLine("}");

        if (set.Contains("devmode"))
            sb.AppendLine("""
                Passo 'Ativando modo desenvolvedor' {
                  $k = 'HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\AppModelUnlock'
                  if (-not (Test-Path $k)) { New-Item $k -Force | Out-Null }
                  Set-ItemProperty $k -Name AllowDevelopmentWithoutDevLicense -Value 1 -Type DWord
                  Set-ItemProperty $k -Name AllowAllTrustedApps -Value 1 -Type DWord
                }
                """);

        if (set.Contains("winappdriver"))
            sb.AppendLine("""
                Passo 'Instalando WinAppDriver 1.2.1' {
                  $msi = Join-Path $env:TEMP 'WindowsApplicationDriver_1.2.1.msi'
                  Write-Host 'Baixando...'
                  Invoke-WebRequest -Uri '__MSI__' -OutFile $msi -UseBasicParsing
                  Write-Host 'Instalando...'
                  $p = Start-Process msiexec.exe -ArgumentList '/i', ('"' + $msi + '"'), '/qn', '/norestart' -Wait -PassThru
                  if ($p.ExitCode -notin 0, 3010) { throw "msiexec retornou $($p.ExitCode)" }
                }
                """.Replace("__MSI__", WinAppDriverMsi));

        if (set.Contains("sdk") || set.Contains("runtime31"))
        {
            sb.AppendLine("""
                $dotnetDir = Join-Path $env:ProgramFiles 'dotnet'
                $installer = Join-Path $env:TEMP 'dotnet-install.ps1'
                Passo 'Baixando instalador do .NET' {
                  Invoke-WebRequest -Uri 'https://dot.net/v1/dotnet-install.ps1' -OutFile $installer -UseBasicParsing
                }
                """);
            if (set.Contains("sdk"))
                sb.AppendLine("Passo 'Instalando .NET SDK 8' { & $installer -Channel 8.0 -InstallDir $dotnetDir }");
            if (set.Contains("runtime31"))
                sb.AppendLine("Passo 'Instalando .NET Core 3.1 Runtime' { & $installer -Runtime dotnet -Channel 3.1 -InstallDir $dotnetDir }");
            sb.AppendLine("""
                Passo 'Garantindo dotnet no PATH' {
                  $machine = [Environment]::GetEnvironmentVariable('Path', 'Machine')
                  if (($machine -split ';') -notcontains $dotnetDir) {
                    [Environment]::SetEnvironmentVariable('Path', ($machine.TrimEnd(';') + ';' + $dotnetDir), 'Machine')
                  }
                }
                """);
        }

        sb.AppendLine("Write-Host \"CONCLUIDO - falhas: $falhas\"");
        sb.AppendLine("Stop-Transcript | Out-Null");
        sb.AppendLine("exit $falhas");
        return sb.ToString();
    }
}
