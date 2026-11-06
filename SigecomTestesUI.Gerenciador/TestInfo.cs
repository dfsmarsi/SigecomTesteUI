namespace SigecomTestesUI.Gerenciador;

public enum TestStatus { NaoExecutado, Pendente, Passou, Falhou, Ignorado }

public class TestInfo
{
    public string Namespace { get; init; }
    public string Class { get; init; }
    public string Method { get; init; }
    public string Description { get; init; }

    public string FullName => $"{Namespace}.{Class}.{Method}";
    public string DisplayName => string.IsNullOrWhiteSpace(Description) ? Method : Description;

    public bool Checked { get; set; }
    public TestStatus Status { get; set; } = TestStatus.NaoExecutado;
    public TimeSpan? Duration { get; set; }
    public DateTime? LastRun { get; set; }
    public string Error { get; set; }
}
