using System.Text.Json;

namespace SigecomTestesUI.Gerenciador;

public class Settings
{
    public string ProjectDir { get; set; }
    public bool BuildBeforeRun { get; set; } = true;
    public string SigecomExePath { get; set; }      // vazio = C:\SIGECOM\SIGECOM.exe
    public string WinAppDriverPath { get; set; }    // vazio = caminho padrão do instalador
    public Dictionary<string, SavedResult> Results { get; set; } = new();

    private static readonly string FilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "SigecomGerenciadorDeTestes", "settings.json");

    public static Settings Load()
    {
        try
        {
            if (File.Exists(FilePath))
                return JsonSerializer.Deserialize<Settings>(File.ReadAllText(FilePath)) ?? new Settings();
        }
        catch { /* arquivo corrompido: começa limpo */ }
        return new Settings();
    }

    public void Save()
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
            File.WriteAllText(FilePath, JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true }));
        }
        catch { /* falha ao salvar não impede o uso */ }
    }

    /// <summary>Procura a pasta SigecomTestesUI (com o .csproj) subindo a partir do exe.</summary>
    public static string AutoDetectProjectDir()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null)
        {
            var candidate = Path.Combine(dir.FullName, "SigecomTestesUI", "SigecomTestesUI.csproj");
            if (File.Exists(candidate)) return Path.GetDirectoryName(candidate);
            dir = dir.Parent;
        }
        return null;
    }
}

public class SavedResult
{
    public TestStatus Status { get; set; }
    public double? DurationSeconds { get; set; }
    public DateTime? LastRun { get; set; }
    public string Error { get; set; }
}
