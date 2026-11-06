using System.Diagnostics;
using System.Text;

namespace SigecomTestesUI.Gerenciador;

public class MainForm : Form
{
    private const string PrefixoNamespace = "SigecomTestesUI.Sigecom.";

    private readonly Settings _settings = Settings.Load();
    private TestRunner _runner;
    private List<TestInfo> _tests = new();
    private readonly Dictionary<TestInfo, TreeNode> _nodes = new();
    private CancellationTokenSource _cts;
    private bool _running;
    private bool _updatingChecks;

    private readonly TreeView _tree = new();
    private readonly TextBox _log = new();
    private readonly TextBox _detail = new();
    private readonly ToolStripButton _btnRun = new("▶  Executar selecionados");
    private readonly ToolStripButton _btnStop = new("■  Parar") { Enabled = false };
    private readonly ToolStripButton _btnReload = new("⟳  Recarregar");
    private readonly ToolStripButton _btnAll = new("Marcar todos");
    private readonly ToolStripButton _btnNone = new("Desmarcar");
    private readonly ToolStripButton _btnFailed = new("Marcar falhas");
    private readonly ToolStripButton _btnExpand = new("Expandir todos");
    private readonly ToolStripButton _btnCollapse = new("Recolher todos");
    private readonly ToolStripButton _btnFolder = new("Pasta…");
    private readonly ToolStripButton _btnSetup = new("⚙  Requisitos…");
    private readonly ToolStripButton _btnPaths = new("Caminhos…");
    private readonly ToolStripButton _btnOpenLog = new("Abrir relatório");
    private readonly ToolStripButton _chkBuild = new("Compilar antes") { CheckOnClick = true };
    private readonly ToolStripTextBox _filterText = new() { AutoSize = false, Width = 200 };
    private readonly ToolStripComboBox _filterStatus = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 130 };
    private readonly ToolStripStatusLabel _statusLabel = new() { Spring = true, TextAlign = ContentAlignment.MiddleLeft };
    private readonly ToolStripStatusLabel _lblOk = new() { ForeColor = Color.FromArgb(22, 128, 60), Font = new Font("Segoe UI", 9f, FontStyle.Bold), BorderSides = ToolStripStatusLabelBorderSides.Left };
    private readonly ToolStripStatusLabel _lblFalha = new() { ForeColor = Color.FromArgb(200, 30, 30), Font = new Font("Segoe UI", 9f, FontStyle.Bold), BorderSides = ToolStripStatusLabelBorderSides.Left };
    private readonly ToolStripStatusLabel _lblNaoExec = new() { ForeColor = Color.DimGray, Font = new Font("Segoe UI", 9f, FontStyle.Bold), BorderSides = ToolStripStatusLabelBorderSides.Left };
    private readonly ToolStripProgressBar _progress = new() { Width = 180, Visible = false };

    private string _lastTrx;

    public MainForm()
    {
        Text = "Gerenciador de Testes — Sigecom UI";
        Width = 1100;
        Height = 700;
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Segoe UI", 9f);

        BuildLayout();
        Shown += async (_, _) => await InicializarAsync();
        FormClosing += (_, e) =>
        {
            if (_running && MessageBox.Show("Há testes em execução. Parar e sair?", Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
            _runner?.Stop();
            _settings.Save();
        };
    }

    // ---------- layout ----------

    private void BuildLayout()
    {
        var tool = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, Padding = new Padding(6, 4, 6, 4) };
        _filterStatus.Items.AddRange(new object[] { "Todos", "Falhas", "Passaram", "Não executados" });
        _filterStatus.SelectedIndex = 0;
        _chkBuild.Checked = _settings.BuildBeforeRun;
        _chkBuild.ToolTipText = "Compila o projeto de testes antes de executar (pega alterações feitas no código).";

        tool.Items.AddRange(new ToolStripItem[]
        {
            _btnRun, _btnStop, new ToolStripSeparator(),
            _btnAll, _btnNone, _btnFailed, new ToolStripSeparator(),
            _btnExpand, _btnCollapse, new ToolStripSeparator(),
            new ToolStripLabel("Buscar:"), _filterText, _filterStatus, new ToolStripSeparator(),
            _btnReload, _chkBuild, _btnFolder, _btnPaths, _btnSetup, _btnOpenLog
        });
        foreach (var b in tool.Items.OfType<ToolStripButton>()) b.DisplayStyle = ToolStripItemDisplayStyle.Text;
        _btnRun.Font = new Font(Font, FontStyle.Bold);

        _tree.Dock = DockStyle.Fill;
        _tree.CheckBoxes = true;
        _tree.HideSelection = false;
        _tree.ShowLines = true;
        _tree.ItemHeight = 22;
        _tree.BorderStyle = BorderStyle.None;

        _detail.Dock = DockStyle.Fill;
        _detail.Multiline = true;
        _detail.ReadOnly = true;
        _detail.ScrollBars = ScrollBars.Both;
        _detail.WordWrap = false;
        _detail.Font = new Font("Consolas", 9f);
        _detail.BackColor = SystemColors.Window;

        _log.Dock = DockStyle.Fill;
        _log.Multiline = true;
        _log.ReadOnly = true;
        _log.ScrollBars = ScrollBars.Both;
        _log.WordWrap = false;
        _log.Font = new Font("Consolas", 9f);
        _log.BackColor = Color.FromArgb(30, 30, 30);
        _log.ForeColor = Color.Gainsboro;

        var detailGroup = new GroupBox { Text = "Detalhe do teste selecionado", Dock = DockStyle.Fill, Padding = new Padding(6) };
        detailGroup.Controls.Add(_detail);
        var logGroup = new GroupBox { Text = "Saída da execução", Dock = DockStyle.Fill, Padding = new Padding(6) };
        logGroup.Controls.Add(_log);

        var right = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 220 };
        right.Panel1.Controls.Add(detailGroup);
        right.Panel2.Controls.Add(logGroup);

        var main = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 520 };
        main.Panel1.Controls.Add(_tree);
        main.Panel2.Controls.Add(right);

        Shown += (_, _) => main.SplitterDistance = (int)(main.Width * 0.42);

        var status = new StatusStrip();
        status.Items.AddRange(new ToolStripItem[] { _statusLabel, _progress, _lblOk, _lblFalha, _lblNaoExec });
        _tree.ImageList = CriarIcones();

        Controls.Add(main);
        Controls.Add(tool);
        Controls.Add(status);

        _btnRun.Click += async (_, _) => await ExecutarAsync(TestesMarcados());
        _btnStop.Click += (_, _) => { _cts?.Cancel(); Log("⏹ Parando…"); };
        _btnReload.Click += async (_, _) => await RecarregarAsync(compilar: _chkBuild.Checked, zerarResultados: true);
        _btnAll.Click += (_, _) => MarcarTodos(t => true);
        _btnNone.Click += (_, _) => MarcarTodos(t => false);
        _btnFailed.Click += (_, _) => MarcarTodos(t => t.Status == TestStatus.Falhou);
        _btnExpand.Click += (_, _) => { _tree.BeginUpdate(); _tree.ExpandAll(); _tree.EndUpdate(); _tree.Nodes.OfType<TreeNode>().FirstOrDefault()?.EnsureVisible(); };
        _btnCollapse.Click += (_, _) => { _tree.BeginUpdate(); _tree.CollapseAll(); _tree.EndUpdate(); };
        _btnFolder.Click += async (_, _) => { if (EscolherPasta()) await RecarregarAsync(compilar: true, zerarResultados: true); };
        _btnOpenLog.Click += (_, _) => AbrirRelatorio();
        _btnPaths.Click += (_, _) => { using var paths = new PathsForm(_settings); paths.ShowDialog(this); };
        _btnSetup.Click +=(_, _) => { using var wizard = new SetupWizardForm(); wizard.ShowDialog(this); };
        _chkBuild.CheckedChanged += (_, _) => _settings.BuildBeforeRun = _chkBuild.Checked;
        _filterText.TextChanged += (_, _) => RenderTree();
        _filterStatus.SelectedIndexChanged += (_, _) => RenderTree();
        _tree.AfterCheck += TreeAfterCheck;
        _tree.AfterSelect += (_, e) => MostrarDetalhe(e.Node?.Tag as TestInfo);
        _tree.NodeMouseDoubleClick += async (_, e) =>
        {
            if (e.Node.Tag is TestInfo t) await ExecutarAsync(new List<TestInfo> { t });
        };
    }

    // ---------- inicialização / descoberta ----------

    private async Task InicializarAsync()
    {
        Requirements.Aplicar(_settings);
        if (!SetupWizardForm.TudoOk())
        {
            using var wizard = new SetupWizardForm();
            wizard.ShowDialog(this);
        }

        if (string.IsNullOrEmpty(_settings.ProjectDir) || !File.Exists(Path.Combine(_settings.ProjectDir, "SigecomTestesUI.csproj")))
        {
            _settings.ProjectDir = Settings.AutoDetectProjectDir();
            if (_settings.ProjectDir == null && !EscolherPasta()) return;
        }
        _runner = new TestRunner(_settings.ProjectDir);

        var dll = _runner.DllPath;
        await RecarregarAsync(compilar: !File.Exists(dll));
    }

    /// <summary>True se algum .cs/.csproj do projeto de testes é mais novo que a DLL (ex.: zip extraído por cima).</summary>
    private bool CodigoMaisNovoQueADll()
    {
        try
        {
            var dll = new FileInfo(_runner.DllPath);
            if (!dll.Exists) return true;
            var sep = Path.DirectorySeparatorChar;
            return Directory.EnumerateFiles(_settings.ProjectDir, "*.*", SearchOption.AllDirectories)
                .Where(f => f.EndsWith(".cs", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".csproj", StringComparison.OrdinalIgnoreCase))
                .Where(f => !f.Contains($"{sep}bin{sep}") && !f.Contains($"{sep}obj{sep}"))
                .Any(f => File.GetLastWriteTimeUtc(f) > dll.LastWriteTimeUtc);
        }
        catch
        {
            return false;
        }
    }

    private bool EscolherPasta()
    {
        using var dlg = new FolderBrowserDialog
        {
            Description = "Selecione a pasta do projeto de testes (a que contém SigecomTestesUI.csproj)",
            UseDescriptionForTitle = true
        };
        while (dlg.ShowDialog(this) == DialogResult.OK)
        {
            if (File.Exists(Path.Combine(dlg.SelectedPath, "SigecomTestesUI.csproj")))
            {
                _settings.ProjectDir = dlg.SelectedPath;
                _runner = new TestRunner(_settings.ProjectDir);
                _settings.Save();
                return true;
            }
            MessageBox.Show("Essa pasta não contém o SigecomTestesUI.csproj.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        return false;
    }

    /// <param name="zerarResultados">Descarta os resultados (OK/falha) anteriores; o botão Recarregar usa true.</param>
    private async Task RecarregarAsync(bool compilar, bool zerarResultados = false)
    {
        if (_running || _runner == null) return;
        SetBusy(true, "Carregando testes…");
        try
        {
            if (!compilar && CodigoMaisNovoQueADll())
            {
                Log("▶ O código foi alterado desde a última compilação.");
                compilar = true;
            }
            if (compilar)
            {
                Log("▶ Compilando o projeto de testes…");
                _cts = new CancellationTokenSource();
                var code = await _runner.BuildAsync(LogAsync, _cts.Token);
                if (code != 0)
                {
                    Log("✘ A compilação falhou. Corrija os erros acima e clique em Recarregar.");
                    return;
                }
            }

            if (!File.Exists(_runner.DllPath))
            {
                Log($"✘ Não encontrei {_runner.DllPath}. Compile o projeto primeiro.");
                return;
            }

            var antigos = _tests.ToDictionary(t => t.FullName, t => t.Checked);
            _tests = await Task.Run(() => TestDiscovery.Discover(_runner.DllPath));
            if (zerarResultados)
            {
                _settings.Results.Clear();
                _settings.Save();
            }
            foreach (var t in _tests)
            {
                if (antigos.TryGetValue(t.FullName, out var marcado)) t.Checked = marcado;
                if (_settings.Results.TryGetValue(t.FullName, out var r))
                {
                    t.Status = r.Status;
                    t.Duration = r.DurationSeconds is double s ? TimeSpan.FromSeconds(s) : null;
                    t.LastRun = r.LastRun;
                    t.Error = r.Error;
                }
            }
            RenderTree();
            Log($"✔ {_tests.Count} testes carregados de {_settings.ProjectDir}");
        }
        catch (Exception ex)
        {
            Log("✘ Erro ao carregar os testes: " + ex.Message);
            MessageBox.Show("Não foi possível carregar os testes:" + Environment.NewLine + Environment.NewLine + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally
        {
            SetBusy(false);
        }
    }

    // ---------- árvore ----------

    private bool PassaNoFiltro(TestInfo t)
    {
        var texto = _filterText.Text.Trim();
        if (texto.Length > 0 &&
            !(t.DisplayName.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
              t.FullName.Contains(texto, StringComparison.OrdinalIgnoreCase)))
            return false;

        return _filterStatus.SelectedIndex switch
        {
            1 => t.Status == TestStatus.Falhou,
            2 => t.Status == TestStatus.Passou,
            3 => t.Status == TestStatus.NaoExecutado,
            _ => true
        };
    }

    private void RenderTree()
    {
        _updatingChecks = true;
        _tree.BeginUpdate();
        _tree.Nodes.Clear();
        _nodes.Clear();

        foreach (var test in _tests.Where(PassaNoFiltro))
        {
            var ns = test.Namespace.StartsWith(PrefixoNamespace) ? test.Namespace[PrefixoNamespace.Length..] : test.Namespace;
            var segmentos = ns.Split('.', StringSplitOptions.RemoveEmptyEntries).Where(s => s != "Teste").ToList();
            segmentos.Add(test.Class);

            var colecao = _tree.Nodes;
            foreach (var seg in segmentos)
            {
                var existente = colecao.Cast<TreeNode>().FirstOrDefault(n => n.Tag == null && n.Name == seg);
                if (existente == null) existente = colecao.Add(seg, seg);
                colecao = existente.Nodes;
            }

            var leaf = colecao.Add(test.Method, "");
            leaf.Tag = test;
            leaf.Checked = test.Checked;
            _nodes[test] = leaf;
            AplicarVisual(test);
        }

        AtualizarGrupos();
        foreach (TreeNode n in _tree.Nodes) SincronizarMarcacaoDosGrupos(n);
        if (_filterText.Text.Length > 0 || _filterStatus.SelectedIndex > 0) _tree.ExpandAll();
        else foreach (TreeNode n in _tree.Nodes) n.Expand();

        _tree.EndUpdate();
        _updatingChecks = false;
        AtualizarStatusBar();
    }

    private static readonly Color Verde = Color.FromArgb(22, 128, 60);
    private static readonly Color Vermelho = Color.FromArgb(200, 30, 30);

    private static (string Icone, Color Cor) Visual(TestStatus s) => s switch
    {
        TestStatus.Passou => ("ok", Verde),
        TestStatus.Falhou => ("falha", Vermelho),
        TestStatus.Pendente => ("pendente", Color.FromArgb(30, 90, 200)),
        TestStatus.Ignorado => ("ignorado", Color.DarkGoldenrod),
        _ => ("nenhum", Color.Gray)
    };

    private static ImageList CriarIcones()
    {
        var lista = new ImageList { ImageSize = new Size(18, 18), ColorDepth = ColorDepth.Depth32Bit };

        void Add(string chave, Color fundo, Action<Graphics, Pen> glifo, bool vazado = false)
        {
            var bmp = new Bitmap(18, 18);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                if (vazado) { using var p = new Pen(fundo, 1.6f); g.DrawEllipse(p, 2, 2, 13, 13); }
                else { using var b = new SolidBrush(fundo); g.FillEllipse(b, 1, 1, 16, 16); }
                using var branco = new Pen(vazado ? fundo : Color.White, 2.2f) { StartCap = System.Drawing.Drawing2D.LineCap.Round, EndCap = System.Drawing.Drawing2D.LineCap.Round };
                glifo(g, branco);
            }
            lista.Images.Add(chave, bmp);
        }

        Add("ok", Verde, (g, p) => g.DrawLines(p, new[] { new PointF(5, 9.5f), new PointF(8, 12.5f), new PointF(13, 5.5f) }));
        Add("falha", Vermelho, (g, p) => { g.DrawLine(p, 5.5f, 5.5f, 12.5f, 12.5f); g.DrawLine(p, 12.5f, 5.5f, 5.5f, 12.5f); });
        Add("pendente", Color.FromArgb(30, 90, 200), (g, p) => g.DrawLines(p, new[] { new PointF(9, 4.5f), new PointF(9, 9), new PointF(12.5f, 11) }));
        Add("ignorado", Color.DarkGoldenrod, (g, p) => g.DrawLine(p, 5, 9, 13, 9));
        Add("nenhum", Color.Gray, (g, p) => { }, vazado: true);
        Add("parcial", Color.FromArgb(230, 150, 20), (g, p) => g.DrawLine(p, 5, 9, 13, 9)); // grupo com parte executada
        return lista;
    }

    private void AplicarVisual(TestInfo test)
    {
        if (!_nodes.TryGetValue(test, out var node)) return;
        var (icone, cor) = Visual(test.Status);
        var duracao = test.Duration is TimeSpan d && test.Status is TestStatus.Passou or TestStatus.Falhou
            ? $"  ({d.TotalSeconds:0.0}s)" : "";
        node.Text = $"{test.DisplayName}{duracao}";
        node.ForeColor = cor;
        node.ImageKey = node.SelectedImageKey = icone;
    }

    private void AtualizarGrupo(TreeNode grupo)
    {
        foreach (TreeNode filho in grupo.Nodes)
            if (filho.Tag == null) AtualizarGrupo(filho);

        var folhas = Folhas(grupo).ToList();
        var falhas = folhas.Count(t => t.Status == TestStatus.Falhou);
        var passou = folhas.Count(t => t.Status == TestStatus.Passou);
        grupo.Text = $"{grupo.Name}  ({folhas.Count})   ✔ {passou} / ✘ {falhas}";

        var (icone, cor) =
            falhas > 0 ? ("falha", Vermelho)
            : passou == folhas.Count && folhas.Count > 0 ? ("ok", Verde)
            : folhas.Any(t => t.Status != TestStatus.NaoExecutado) ? ("parcial", Color.FromArgb(230, 150, 20))
            : ("nenhum", (Color)SystemColors.WindowText);
        grupo.ForeColor = cor;
        grupo.ImageKey = grupo.SelectedImageKey = icone;
    }

    private void AtualizarGrupos()
    {
        foreach (TreeNode n in _tree.Nodes) AtualizarGrupo(n);
    }

    /// <summary>Deixa a caixa de marcação de cada grupo coerente com seus testes (marcada só se todos estiverem).</summary>
    private static bool SincronizarMarcacaoDosGrupos(TreeNode node)
    {
        if (node.Tag is TestInfo t) return t.Checked;
        var todos = node.Nodes.Count > 0;
        foreach (TreeNode filho in node.Nodes)
            todos &= SincronizarMarcacaoDosGrupos(filho);
        node.Checked = todos;
        return todos;
    }

    private static IEnumerable<TestInfo> Folhas(TreeNode node)
    {
        foreach (TreeNode filho in node.Nodes)
        {
            if (filho.Tag is TestInfo t) yield return t;
            else foreach (var x in Folhas(filho)) yield return x;
        }
    }

    private void TreeAfterCheck(object sender, TreeViewEventArgs e)
    {
        if (_updatingChecks) return;
        _updatingChecks = true;
        try
        {
            PropagarMarcacao(e.Node, e.Node.Checked);
            foreach (TreeNode n in _tree.Nodes) SincronizarMarcacaoDosGrupos(n);
        }
        finally { _updatingChecks = false; }
        AtualizarStatusBar();
    }

    private static void PropagarMarcacao(TreeNode node, bool marcado)
    {
        if (node.Tag is TestInfo t) t.Checked = marcado;
        foreach (TreeNode filho in node.Nodes)
        {
            filho.Checked = marcado;
            PropagarMarcacao(filho, marcado);
        }
    }

    private void MarcarTodos(Func<TestInfo, bool> regra)
    {
        _updatingChecks = true;
        _tree.BeginUpdate();
        foreach (var (test, node) in _nodes)
        {
            test.Checked = regra(test);
            node.Checked = test.Checked;
        }
        foreach (TreeNode n in _tree.Nodes) SincronizarMarcacaoDosGrupos(n);
        _tree.EndUpdate();
        _updatingChecks = false;
        AtualizarStatusBar();
    }

    private List<TestInfo> TestesMarcados() => _nodes.Keys.Where(t => t.Checked).ToList();

    // ---------- detalhe / status ----------

    private void MostrarDetalhe(TestInfo t)
    {
        if (t == null) { _detail.Text = ""; return; }
        var sb = new StringBuilder();
        sb.AppendLine(t.DisplayName);
        sb.AppendLine(t.FullName);
        sb.AppendLine();
        sb.AppendLine($"Situação: {t.Status}");
        if (t.Duration is TimeSpan d) sb.AppendLine($"Duração:  {d.TotalSeconds:0.0}s");
        if (t.LastRun is DateTime l) sb.AppendLine($"Última execução: {l:dd/MM/yyyy HH:mm:ss}");
        if (!string.IsNullOrWhiteSpace(t.Error))
        {
            sb.AppendLine();
            sb.AppendLine("--- Erro ---");
            sb.AppendLine(t.Error);
        }
        _detail.Text = sb.ToString();
    }

    private void AtualizarStatusBar()
    {
        var marcados = _nodes.Keys.Count(t => t.Checked);
        var passou = _tests.Count(t => t.Status == TestStatus.Passou);
        var falhou = _tests.Count(t => t.Status == TestStatus.Falhou);
        var naoExecutados = _tests.Count - passou - falhou;
        if (!_running) _statusLabel.Text = $"{_tests.Count} testes   |   {marcados} marcados";
        _lblOk.Text = $"  ✔ {passou} OK  ";
        _lblFalha.Text = $"  ✘ {falhou} com falha  ";
        _lblNaoExec.Text = $"  ○ {naoExecutados} não executados  ";
    }

    private void SetBusy(bool busy, string texto = null)
    {
        _running = busy;
        _btnRun.Enabled = !busy;
        _btnReload.Enabled = !busy;
        _btnFolder.Enabled = !busy;
        _btnStop.Enabled = busy;
        _progress.Visible = busy;
        if (busy) _statusLabel.Text = texto ?? "Executando…";
        else AtualizarStatusBar();
    }

    // ---------- execução ----------

    private async Task ExecutarAsync(List<TestInfo> selecionados)
    {
        if (_running || _runner == null) return;
        if (selecionados.Count == 0)
        {
            MessageBox.Show("Marque ao menos um teste (ou dê duplo clique em um deles).", Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show(
                $"Executar {selecionados.Count} teste(s)?\n\nO Sigecom será aberto e controlado automaticamente — " +
                "não use o mouse e o teclado enquanto os testes estiverem rodando.",
                Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;

        _cts = new CancellationTokenSource();
        SetBusy(true, "Executando…");
        var inicio = Stopwatch.StartNew();
        try
        {
            if (_chkBuild.Checked || CodigoMaisNovoQueADll())
            {
                Log("▶ Compilando…");
                _statusLabel.Text = "Compilando…";
                if (await _runner.BuildAsync(LogAsync, _cts.Token) != 0)
                {
                    Log("✘ A compilação falhou — testes não executados.");
                    return;
                }
            }

            foreach (var t in selecionados)
            {
                t.Status = TestStatus.Pendente;
                t.Error = null;
                AplicarVisual(t);
            }

            var pendentes = new List<TestInfo>(selecionados);
            var concluidos = 0;
            _progress.Minimum = 0;
            _progress.Maximum = selecionados.Count;
            _progress.Value = 0;

            var dirTrx = Path.Combine(Path.GetTempPath(), "SigecomGerenciadorDeTestes");
            Directory.CreateDirectory(dirTrx);
            _lastTrx = Path.Combine(dirTrx, $"execucao-{DateTime.Now:yyyyMMdd-HHmmss}.trx");

            Log($"▶ Executando {selecionados.Count} teste(s)…");
            var runAll = selecionados.Count == _tests.Count;
            await _runner.RunAsync(selecionados, runAll, LogAsync, (nome, status) =>
            {
                BeginInvoke(() =>
                {
                    // A saída do dotnet test traz só o nome do método. Se mais de um teste pendente tiver esse nome
                    // (classes diferentes), não dá para saber qual terminou: só avança o progresso e deixa o .trx
                    // (que tem o nome completo) marcar o status no final.
                    var candidatos = pendentes.Where(t => nome == t.Method || nome.StartsWith(t.Method + "(")).ToList();
                    if (candidatos.Count == 0) return;
                    if (candidatos.Count == 1)
                    {
                        var teste = candidatos[0];
                        pendentes.Remove(teste);
                        teste.Status = status;
                        AplicarVisual(teste);
                        AtualizarGrupos();
                        AtualizarStatusBar();
                    }
                    concluidos++;
                    _progress.Value = Math.Min(concluidos, _progress.Maximum);
                    _statusLabel.Text = $"Executando… {concluidos}/{selecionados.Count}";
                });
            }, _lastTrx, _cts.Token);

            AplicarTrx(selecionados);
            var cancelado = _cts.IsCancellationRequested;
            foreach (var t in selecionados.Where(t => t.Status == TestStatus.Pendente))
                t.Status = TestStatus.NaoExecutado;

            SalvarResultados(selecionados);
            foreach (var t in selecionados) AplicarVisual(t);
            AtualizarGrupos();
            MostrarDetalhe(_tree.SelectedNode?.Tag as TestInfo);

            var ok = selecionados.Count(t => t.Status == TestStatus.Passou);
            var ko = selecionados.Count(t => t.Status == TestStatus.Falhou);
            Log($"{(cancelado ? "⏹ Interrompido" : "■ Concluído")} em {inicio.Elapsed:mm\\:ss} — ✔ {ok} passaram, ✘ {ko} falharam, de {selecionados.Count}.");
        }
        catch (Exception ex)
        {
            Log("✘ Erro na execução: " + ex.Message);
        }
        finally
        {
            foreach (var t in selecionados.Where(t => t.Status == TestStatus.Pendente))
            {
                t.Status = TestStatus.NaoExecutado;
                AplicarVisual(t);
            }
            SetBusy(false);
        }
    }

    private void AplicarTrx(List<TestInfo> selecionados)
    {
        var resultados = TestRunner.ParseTrx(_lastTrx);
        foreach (var t in selecionados)
        {
            if (!resultados.TryGetValue(t.FullName, out var r)) continue;
            t.Status = r.Status;
            t.Duration = r.Duration;
            t.Error = r.Error;
        }
    }

    private void SalvarResultados(List<TestInfo> selecionados)
    {
        var agora = DateTime.Now;
        foreach (var t in selecionados.Where(t => t.Status is TestStatus.Passou or TestStatus.Falhou or TestStatus.Ignorado))
        {
            t.LastRun = agora;
            _settings.Results[t.FullName] = new SavedResult
            {
                Status = t.Status,
                DurationSeconds = t.Duration?.TotalSeconds,
                LastRun = agora,
                Error = t.Error
            };
        }
        _settings.Save();
    }

    private void AbrirRelatorio()
    {
        if (_lastTrx != null && File.Exists(_lastTrx))
            Process.Start(new ProcessStartInfo(_lastTrx) { UseShellExecute = true });
        else
            MessageBox.Show("Ainda não há relatório de execução nesta sessão.", Text);
    }

    // ---------- log ----------

    private void LogAsync(string linha) => BeginInvoke(() => Log(linha));

    private void Log(string linha)
    {
        if (_log.TextLength > 400_000) _log.Text = _log.Text[^200_000..];
        _log.AppendText($"[{DateTime.Now:HH:mm:ss}] {linha}{Environment.NewLine}");
    }
}
