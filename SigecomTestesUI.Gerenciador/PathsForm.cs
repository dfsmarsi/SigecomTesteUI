namespace SigecomTestesUI.Gerenciador;

/// <summary>Configuração dos caminhos do Sigecom.exe e do WinAppDriver.exe.</summary>
public class PathsForm : Form
{
    private readonly TextBox _sigecom = new() { Dock = DockStyle.Fill };
    private readonly TextBox _winAppDriver = new() { Dock = DockStyle.Fill };
    private readonly Settings _settings;

    public PathsForm(Settings settings)
    {
        _settings = settings;
        Text = "Caminhos dos programas";
        Width = 760;
        Height = 230;
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MinimizeBox = MaximizeBox = false;
        Font = new Font("Segoe UI", 9f);

        _sigecom.Text = Requirements.SigecomExe;
        _winAppDriver.Text = Requirements.WinAppDriverExe;

        var table = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, RowCount = 5, Padding = new Padding(12) };
        table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

        AddRow(table, 0, "Sigecom.exe:", _sigecom, "SIGECOM.exe|SIGECOM.exe|Executáveis|*.exe");
        AddRow(table, 1, "WinAppDriver.exe:", _winAppDriver, "WinAppDriver.exe|WinAppDriver.exe|Executáveis|*.exe");

        var dica = new Label
        {
            Text = "O padrão do WinAppDriver é o local do instalador oficial. Altere só se instalou em outra pasta.",
            AutoSize = true, ForeColor = Color.DimGray, Margin = new Padding(3, 8, 3, 8)
        };
        table.Controls.Add(dica, 0, 2);
        table.SetColumnSpan(dica, 3);

        var padrao = new Button { Text = "Restaurar padrões", AutoSize = true };
        var ok = new Button { Text = "Salvar", AutoSize = true, DialogResult = DialogResult.OK };
        var cancel = new Button { Text = "Cancelar", AutoSize = true, DialogResult = DialogResult.Cancel };
        var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };
        buttons.Controls.AddRange(new Control[] { cancel, ok, padrao });
        table.Controls.Add(buttons, 0, 4);
        table.SetColumnSpan(buttons, 3);

        padrao.Click += (_, _) =>
        {
            _sigecom.Text = Requirements.SigecomPadrao;
            _winAppDriver.Text = Requirements.WinAppDriverPadrao;
        };
        ok.Click += (_, _) => Salvar();
        AcceptButton = ok;
        CancelButton = cancel;
        Controls.Add(table);
    }

    private static void AddRow(TableLayoutPanel table, int row, string label, TextBox box, string filtro)
    {
        table.Controls.Add(new Label { Text = label, AutoSize = true, Anchor = AnchorStyles.Left, Margin = new Padding(3, 8, 8, 8) }, 0, row);
        table.Controls.Add(box, 1, row);
        var browse = new Button { Text = "Procurar…", AutoSize = true };
        browse.Click += (_, _) =>
        {
            var parts = filtro.Split('|');
            using var dlg = new OpenFileDialog { Filter = $"{parts[2]} ({parts[3]})|{parts[3]}", FileName = parts[1], CheckFileExists = true };
            if (File.Exists(box.Text)) dlg.InitialDirectory = Path.GetDirectoryName(box.Text);
            if (dlg.ShowDialog() == DialogResult.OK) box.Text = dlg.FileName;
        };
        table.Controls.Add(browse, 2, row);
    }

    private void Salvar()
    {
        var sig = _sigecom.Text.Trim();
        var wad = _winAppDriver.Text.Trim();

        var avisos = new List<string>();
        if (!File.Exists(sig)) avisos.Add("Sigecom.exe não encontrado: " + sig);
        if (!File.Exists(wad)) avisos.Add("WinAppDriver.exe não encontrado: " + wad);
        if (avisos.Count > 0 && MessageBox.Show(string.Join("\n", avisos) + "\n\nSalvar mesmo assim?", Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
        {
            DialogResult = DialogResult.None; // mantém a janela aberta
            return;
        }

        // Guarda vazio quando é o padrão, para seguir o padrão se ele mudar no futuro.
        _settings.SigecomExePath = string.Equals(sig, Requirements.SigecomPadrao, StringComparison.OrdinalIgnoreCase) ? null : sig;
        _settings.WinAppDriverPath = string.Equals(wad, Requirements.WinAppDriverPadrao, StringComparison.OrdinalIgnoreCase) ? null : wad;
        _settings.Save();
        Requirements.Aplicar(_settings);
    }
}
