using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.Page
{
    public class GravarEImprimirPreVendaPage: PageObjectModel
    {
        public GravarEImprimirPreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeGravarEImprimir()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto(LancarItemNaPreVendaModel.PesquisarItem);
            AvancarPreVenda();
            AvancarPreVenda();
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.AcoesDaPreVenda, 1);
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.GridDeFormaDePagamento, 1);
            ClicarBotaoName(PreVendaModel.ElementoNameDoNao);
            Assert.AreEqual(DriverService.ObterValorElementoId("4524078"), "10");
            DriverService.FecharTelaDePreVisualizar();
            FecharTelaDeVendaComEsc();
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(PreVendaModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarPreVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);

        private void FecharTelaDeVendaComEsc()
            => DriverService.FecharJanelaComEsc(PreVendaModel.ElementoTelaDePreVenda);
    }
}
