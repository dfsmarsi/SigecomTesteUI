using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.Page
{
    public class AlterarTabelaDePrecoDaPreVendaPage: PageObjectModel
    {
        public AlterarTabelaDePrecoDaPreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeAlterarTabelaDePrecoNaPreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto(LancarItemNaPreVendaModel.PesquisarItemId);
            SelecionarItemComboBox(3);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Total"), LancarItemNaPreVendaModel.ValorUnitarioDoPrimeiroProdutoNoPreVenda);
            SelecionarItemComboBox(4);
            LancarProduto(LancarItemNaPreVendaModel.PesquisarItemIdDoSegundoProdutoNoPreVenda);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Total", "1"), LancarItemNaPreVendaModel.ValorUnitarioDoSegundoProdutoNoPreVenda);
            AvancarPreVenda();
            AvancarPreVenda();
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.AcoesDaPreVenda, 2);
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.GridDeFormaDePagamento, 1);
            FecharTelaDeVendaComEsc();
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(PreVendaModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void SelecionarItemComboBox(int posicao)
            => DriverService.SelecionarItemComboBoxSemEnter(PreVendaModel.ElementoDoComboDaTabelaDePreco, posicao);

        private void AvancarPreVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);

        private void FecharTelaDeVendaComEsc() =>
            DriverService.FecharJanelaComEsc(PreVendaModel.ElementoTelaDePreVenda);
    }
}
