using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Page
{
    public class AlterarTabelaDePrecoNaOrdemDeServicoPage: PageObjectModel
    {
        public AlterarTabelaDePrecoNaOrdemDeServicoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
           AcessarOpcaoMenu(OrdemDeServicoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(OrdemDeServicoModel.BotaoSubMenu);

        public void RealizarFluxoDeAlterarTabelaDePrecoNaOrdemDeServico()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoName(OrdemDeServicoModel.BotaoAtalhosOrdemDeServico);
            ClicarBotaoName(OrdemDeServicoModel.AtalhoDePesquisarObjetoDaOrdemDeServico);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastrarObjetoModel.ElementoDoObjeto, CadastrarObjetoModel.ValorDoObjeto, Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(CadastrarObjetoModel.ElementoDoCampoDePesquisa, CadastrarObjetoModel.ValorDoObjeto, Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastrarObjetoModel.ElementoDaMarca, CadastrarObjetoModel.ValorDaMarca, Keys.Enter);
            ClicarBotaoName(OrdemDeServicoModel.ElementoNameDoCadastrar);
            ClicarBotaoName(OrdemDeServicoModel.ElementoNameDoConfirmarDoPesquisar);
            LancarProduto(LancarItensNaOrdemDeServicoModel.PesquisarItemId);
            DriverService.SelecionarItemComboBoxSemEnter(OrdemDeServicoModel.ElementoDoComboDaTabelaDePreco, 3);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(OrdemDeServicoModel.CampoDaGridDeTotalDoProduto),
                LancarItensNaOrdemDeServicoModel.ValorUnitarioDoPrimeiroProdutoNaOrdemDeServico);
            DriverService.SelecionarItemComboBoxSemEnter(OrdemDeServicoModel.ElementoDoComboDaTabelaDePreco, 1);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(OrdemDeServicoModel.CampoDaGridDeTotalDoProduto),
                LancarItensNaOrdemDeServicoModel.ValorUnitarioDoPrimeiroProdutoNaOrdemDeServico);
            LancarProduto(LancarItensNaOrdemDeServicoModel.PesquisarItemIdDoSegundoProdutoNaOrdemDeServico);
            Assert.AreEqual(
                DriverService.PegarValorDaColunaDaGridNaPosicao(OrdemDeServicoModel.CampoDaGridDeTotalDoProduto, "1"),
                LancarItensNaOrdemDeServicoModel.ValorUnitarioDoSegundoProdutoNaOrdemDeServico);
            AvancarNaOrdemDeServico();
            DriverService.SelecionarItemComboBoxSemEnter(OrdemDeServicoModel.ElementoDeTipoDaOrdemDeServico, 1);
            DriverService.SelecionarItemComboBoxSemEnter(OrdemDeServicoModel.ElementoDoStatusDaOrdemDeServico, 1);
            DriverService.DigitarNoCampoId(OrdemDeServicoModel.ElementoDoSolicitanteDaOrdemDeServico, LancarItensNaOrdemDeServicoModel.SolicitanteDaOrdemDeServico);
            DriverService.DigitarNoCampoId(OrdemDeServicoModel.ElementoDoDefeitoDaOrdemDeServico, LancarItensNaOrdemDeServicoModel.DefeitoDaOrdemDeServico);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(OrdemDeServicoModel.ElementoDeObservação, LancarItensNaOrdemDeServicoModel.Observacao, Keys.Enter);
            DriverService.RealizarSelecaoDaAcao(OrdemDeServicoModel.AcoesDaOrdemDeServico, 2);
            FecharTelaDeOrdemDeServicoComEsc();
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(OrdemDeServicoModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarNaOrdemDeServico()
            => ClicarBotaoName(OrdemDeServicoModel.ElementoNameDoAvancar);

        private void FecharTelaDeOrdemDeServicoComEsc() =>
            DriverService.FecharJanelaComEsc(OrdemDeServicoModel.ElementoTelaDeOrdemDeServico);
    }
}
