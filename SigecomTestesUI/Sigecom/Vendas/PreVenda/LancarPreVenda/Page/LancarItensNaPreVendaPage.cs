using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Page
{
    public class LancarItensNaPreVendaPage:PageObjectModel
    {
        public LancarItensNaPreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarItemNaPreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto(LancarItemNaPreVendaModel.PesquisarItem);
            LancarProduto(LancarItemNaPreVendaModel.PesquisarItemId);
            LancarProduto(LancarItemNaPreVendaModel.PesquisarItemReferencia);
            LancarProduto(LancarItemNaPreVendaModel.PesquisarItemCodInterno);
            LancarProduto(LancarItemNaPreVendaModel.PesquisarItemMultiplicadorDeQuantidade);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Qtde"), LancarItemNaPreVendaModel.QuantidadeDeProduto);
            AvancarVenda();
            DriverService.DigitarNoCampoId(PreVendaModel.ElementoDeObservação, LancarItemNaPreVendaModel.Observacao);
            AvancarVenda();
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.AcoesDaPreVenda, 2);
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.GridDeFormaDePagamento, 1);
            FecharTelaDeVendaComEsc();
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(PreVendaModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);

        private void FecharTelaDeVendaComEsc() =>
            DriverService.FecharJanelaComEsc(PreVendaModel.ElementoTelaDePreVenda);
    }
}
