using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace SigecomTestesUI.Gerenciador;

/// <summary>Assistente que verifica e instala os requisitos para rodar os testes.</summary>
public class SetupWizardForm : Form
{
    private readonly ListView _list = new();
    private readonly TextBox _log = new();
    private readonly Button _btnInstall = new() { Text = "Instalar o que falta (administrador)", AutoSize = true };
    private readonly Button _btnRecheck = new() { Text = "Verificar novamente", AutoSize = true };
    private readonly Button _btnClose = new() { Text = "Fechar", AutoSize = true, DialogResult = DialogResult.OK };
    private readonly Label _summary = new() { Dock = DockStyle.Top, Height = 44, Padding = new Padding(10, 10, 10, 0) };
    private readonly System.Windows.Forms.Timer _timer = new() { Interval = 700 };

    private List<Requirement> _reqs = new();
    private Process _process;
    private string _logPath;
    private long _logOffset;

    public SetupWizardForm()
    {
        Text = "Requisitos para executar os testes";
        Width = 820;
        Height = 620;
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 9f);
        MinimizeBox = false;
        MaximizeBox = false;
        FormBorderStyle = FormBorderStyle.FixedDialog;

        _list.Dock = DockStyle.Fill;
        _list.View = View.Details;
        _list.FullRowSelect = true;
        _list.CheckBoxes = true;
        _list.ShowItemToolTips = true;
        _list.HeaderStyle = ColumnHeaderStyle.Nonclickable;
        _list.Columns.Add("Requisito", 290);
        _list.Columns.Add("Situação", 90);
        _list.Columns.Add("Detalhe", 400);

        _log.Dock = DockStyle.Fill;
        _log.Multiline = true;
        _log.ReadOnly = true;
        _log.ScrollBars = ScrollBars.Both;
        _log.WordWrap = false;
        _log.Font = new Font("Consolas", 9f);
        _log.BackColor = Color.FromArgb(30, 30, 30);
        _log.ForeColor = Color.Gainsboro;

        var buttons = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom, FlowDirection = FlowDirection.RightToLeft,
            Height = 46, Padding = new Padding(8)
        };
        buttons.Controls.AddRange(new Control[] { _btnClose, _btnInstall, _btnRecheck });

        var split = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 230 };
        split.Panel1.Controls.Add(_list);
        split.Panel2.Controls.Add(_log);

        Controls.Add(split);
        Controls.Add(_summary);
        Controls.Add(buttons);
        AcceptButton = _btnClose;

        _btnRecheck.Click += (_, _) => Verificar();
        _btnInstall.Click += (_, _) => Instalar();
        _timer.Tick += (_, _) => LerLog();
        Shown += (_, _) => Verificar();
        FormClosing += (_, e) =>
        {
            if (_process is { HasExited: false })
            {
                MessageBox.Show("A instalação ainda está em andamento. Aguarde terminar.", Text);
                e.Cancel = true;
            }
        };
    }

    public static bool TudoOk() => Requirements.Check().Where(r => r.Installable).All(r => r.Ok);

    private void Verificar()
    {
        _reqs = Requirements.Check();
        _list.Items.Clear();
        foreach (var r in _reqs)
        {
            var item = new ListViewItem(r.Name) { Tag = r, ToolTipText = r.Help };
            item.SubItems.Add(r.Ok ? "✔ OK" : (r.Installable ? "✘ Falta" : "⚠ Aviso"));
            item.SubItems.Add(r.Detail);
            item.ForeColor = r.Ok ? Color.FromArgb(22, 128, 60) : (r.Installable ? Color.FromArgb(200, 30, 30) : Color.DarkGoldenrod);
            item.Checked = !r.Ok && r.Installable;
            _list.Items.Add(item);
        }

        var faltam = _reqs.Count(r => !r.Ok && r.Installable);
        _summary.Text = faltam == 0
            ? "✔ Tudo pronto para executar os testes."
            : $"{faltam} requisito(s) pendente(s). Marque o que deseja instalar e clique em \"Instalar o que falta\" (o Windows pedirá permissão de administrador).";
        _summary.ForeColor = faltam == 0 ? Color.FromArgb(22, 128, 60) : SystemColors.ControlText;
        _btnInstall.Enabled = faltam > 0 && _process is not { HasExited: false };
    }

    private void Instalar()
    {
        var ids = _list.Items.Cast<ListViewItem>()
            .Where(i => i.Checked && i.Tag is Requirement { Installable: true, Ok: false })
            .Select(i => ((Requirement)i.Tag).Id).ToList();
        if (ids.Count == 0)
        {
            MessageBox.Show("Marque ao menos um requisito pendente.", Text);
            return;
        }

        var dir = Path.Combine(Path.GetTempPath(), "SigecomGerenciadorDeTestes");
        Directory.CreateDirectory(dir);
        _logPath = Path.Combine(dir, $"instalacao-{DateTime.Now:yyyyMMdd-HHmmss}.log");
        var scriptPath = Path.Combine(dir, "instalar-requisitos.ps1");
        File.WriteAllText(scriptPath, Requirements.BuildScript(ids), new UTF8Encoding(true));

        _log.Clear();
        _logOffset = 0;
        try
        {
            _process = Process.Start(new ProcessStartInfo("powershell.exe")
            {
                // Caminhos do Windows não podem conter aspas duplas, então envolver em "" é seguro.
                Arguments = $"-NoProfile -NonInteractive -ExecutionPolicy Bypass -File \"{scriptPath}\" -LogPath \"{_logPath}\"",
                UseShellExecute = true,
                Verb = "runas", // pede elevação (UAC)
                WindowStyle = ProcessWindowStyle.Hidden
            });
        }
        catch (Win32Exception)
        {
            _log.Text = "Instalação cancelada: a permissão de administrador não foi concedida.";
            return;
        }

        _btnInstall.Enabled = false;
        _btnRecheck.Enabled = false;
        _btnClose.Enabled = false;
        _summary.Text = "Instalando… isso pode levar alguns minutos.";
        _timer.Start();
    }

    private void LerLog()
    {
        try
        {
            if (File.Exists(_logPath))
            {
                using var fs = new FileStream(_logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
                if (fs.Length > _logOffset)
                {
                    fs.Seek(_logOffset, SeekOrigin.Begin);
                    using var reader = new StreamReader(fs, Encoding.UTF8);
                    var texto = reader.ReadToEnd();
                    _logOffset = fs.Length;
                    _log.AppendText(texto);
                }
            }
        }
        catch { /* arquivo em escrita: tenta no próximo tick */ }

        if (_process is { HasExited: true })
        {
            _timer.Stop();
            var codigo = _process.ExitCode;
            _process = null;
            _btnRecheck.Enabled = true;
            _btnClose.Enabled = true;
            Verificar();
            if (codigo != 0)
                _summary.Text = $"⚠ A instalação terminou com {codigo} falha(s). Veja o log abaixo e tente novamente.";
        }
    }
}
