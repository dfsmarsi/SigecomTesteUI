using System;
using System.ComponentModel;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.Page
{
    public class FaturarEImprimirPreVendaPage:PageObjectModel
    {
        public FaturarEImprimirPreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeFaturarEImprimir()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto(LancarItemNaPreVendaModel.PesquisarItem);
            AvancarPreVenda();
            AvancarPreVenda();
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.AcoesDaPreVenda, 3);
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.GridDeFormaDePagamento, 1);
            ClicarBotaoName(PreVendaModel.ElementoNameDoNao);
            Assert.AreEqual(DriverService.ObterValorElementoId("4524078"), "10");
            DriverService.FecharTelaDePreVisualizar();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            DriverService.FecharTelaDeImpressaoTermica();
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
