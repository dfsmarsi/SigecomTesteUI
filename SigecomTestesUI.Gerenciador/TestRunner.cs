using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace SigecomTestesUI.Gerenciador;

public class TestRunner
{
    private readonly string _projectDir;
    private Process _current;

    public TestRunner(string projectDir) => _projectDir = projectDir;

    public string CsprojPath => Path.Combine(_projectDir, "SigecomTestesUI.csproj");
    public string DllPath => Path.Combine(_projectDir, "bin", "Debug", "netcoreapp3.1", "SigecomTestesUI.dll");

    // Sem processos residentes de compilação (nós do MSBuild e servidor do compilador), que travam a pasta depois.
    public Task<int> BuildAsync(Action<string> onLine, CancellationToken ct) =>
        RunDotnetAsync(new[] { "build", CsprojPath, "-c", "Debug", "--nologo",
            "-nodeReuse:false", "-p:UseSharedCompilation=false" }, onLine, ct);

    /// <summary>Roda os testes informados. <paramref name="runAll"/> omite o filtro.</summary>
    public Task<int> RunAsync(IReadOnlyCollection<TestInfo> tests, bool runAll,
        Action<string> onLine, Action<string, TestStatus> onResult, string trxPath, CancellationToken ct)
    {
        var args = new List<string> { "test", DllPath, "--nologo",
            "--logger", "console;verbosity=normal",
            "--logger", $"trx;LogFileName={Path.GetFileName(trxPath)}",
            "--results-directory", Path.GetDirectoryName(trxPath)! };

        if (!runAll)
        {
            args.Add("--filter");
            args.Add(string.Join("|", tests.Select(t => $"FullyQualifiedName={t.FullName}")));
        }

        // Inglês (forçado acima) e português (pt-BR) como garantia, caso a variável de idioma seja ignorada.
        var rx = new Regex(@"^\s*(Passed|Failed|Skipped|Aprovado|Com falha|Falhou|Ignorado)\s+(\S.*?)(\s+\[[^\]]*\])?\s*$");
        return RunDotnetAsync(args, line =>
        {
            onLine(line);
            var m = rx.Match(line);
            if (!m.Success) return;
            var status = m.Groups[1].Value switch
            {
                "Passed" or "Aprovado" => TestStatus.Passou,
                "Failed" or "Com falha" or "Falhou" => TestStatus.Falhou,
                _ => TestStatus.Ignorado
            };
            onResult(m.Groups[2].Value, status);
        }, ct);
    }

    public void Stop()
    {
        try { _current?.Kill(entireProcessTree: true); } catch { /* já terminou */ }
        EncerrarTesthostsDoProjeto();
    }

    /// <summary>Encerra testhost.exe que sobrou rodando a partir da pasta do projeto (ele trava a pasta).</summary>
    private void EncerrarTesthostsDoProjeto()
    {
        foreach (var p in Process.GetProcessesByName("testhost"))
        {
            try
            {
                var caminho = p.MainModule?.FileName;
                if (caminho != null && caminho.StartsWith(_projectDir, StringComparison.OrdinalIgnoreCase))
                    p.Kill(entireProcessTree: true);
            }
            catch { /* sem acesso ou já terminou */ }
            finally { p.Dispose(); }
        }
    }

    private async Task<int> RunDotnetAsync(IEnumerable<string> args, Action<string> onLine, CancellationToken ct)
    {
        var psi = new ProcessStartInfo(DotnetLocator.Path)
        {
            WorkingDirectory = _projectDir,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            StandardOutputEncoding = Encoding.UTF8,
            StandardErrorEncoding = Encoding.UTF8
        };
        foreach (var a in args) psi.ArgumentList.Add(a);
        // Lidas pelo DriverFabrica do projeto de testes.
        psi.Environment["SIGECOM_EXE"] = Requirements.SigecomExe;
        psi.Environment["WINAPPDRIVER_EXE"] = Requirements.WinAppDriverExe;
        // Saída do dotnet test em inglês: o leitor de resultados ao vivo depende das palavras Passed/Failed.
        psi.Environment["VSLANG"] = "1033";
        psi.Environment["DOTNET_CLI_UI_LANGUAGE"] = "en";
        psi.Environment["MSBUILDDISABLENODEREUSE"] = "1";
        psi.Environment["DOTNET_CLI_USE_MSBUILD_SERVER"] = "0";

        using var process = new Process { StartInfo = psi, EnableRaisingEvents = true };
        process.OutputDataReceived += (_, e) => { if (e.Data != null) onLine(e.Data); };
        process.ErrorDataReceived += (_, e) => { if (e.Data != null) onLine(e.Data); };

        // Espera só o término do processo, não o fechamento dos pipes: o WinAppDriver aberto pelos testes herda a
        // saída redirecionada e continua vivo depois do dotnet test, o que travaria WaitForExit/WaitForExitAsync.
        var terminou = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        process.Exited += (_, _) => terminou.TrySetResult();

        _current = process;
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        using var reg = ct.Register(Stop);
        await terminou.Task;
        await Task.Delay(1000); // dá tempo de os handlers de saída entregarem as últimas linhas
        _current = null;
        return ct.IsCancellationRequested ? -1 : process.ExitCode;
    }

    /// <summary>Resultado autoritativo (chave classe completa + método) lido do .trx.</summary>
    public static Dictionary<string, (TestStatus Status, TimeSpan Duration, string Error)> ParseTrx(string trxPath)
    {
        var result = new Dictionary<string, (TestStatus, TimeSpan, string)>();
        if (!File.Exists(trxPath)) return result;

        XNamespace ns = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010";
        var doc = XDocument.Load(trxPath);

        var names = doc.Descendants(ns + "UnitTest").ToDictionary(
            u => (string)u.Attribute("id"),
            u =>
            {
                var tm = u.Element(ns + "TestMethod");
                return $"{(string)tm.Attribute("className")}.{(string)tm.Attribute("name")}";
            });

        foreach (var r in doc.Descendants(ns + "UnitTestResult"))
        {
            var id = (string)r.Attribute("testId");
            if (id == null || !names.TryGetValue(id, out var fullName)) continue;

            var status = (string)r.Attribute("outcome") switch
            {
                "Passed" => TestStatus.Passou,
                "Failed" => TestStatus.Falhou,
                _ => TestStatus.Ignorado
            };
            TimeSpan.TryParse((string)r.Attribute("duration"), out var duration);

            var error = r.Descendants(ns + "ErrorInfo").FirstOrDefault();
            var text = error == null ? null :
                ((string)error.Element(ns + "Message") + Environment.NewLine + (string)error.Element(ns + "StackTrace")).Trim();
            result[fullName] = (status, duration, text);
        }
        return result;
    }
}
