using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Page
{
    public class DarDescontoNaPreVendaPage: PageObjectModel
    {
        public DarDescontoNaPreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeDarDescontoNoItemDaPreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProdutoPadrao();
            DriverService.DigitarNoCampoName(PreVendaModel.CampoDaGridDeQuantidadeDoProduto, LancarItemNaPreVendaModel.QuantidadeDeProduto);
            DriverService.EditarItensNaGridComDuploClickComTab(PreVendaModel.CampoDaGridDeDescontoDoProduto, LancarItemNaPreVendaModel.DescontoNoItemPreVenda);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(PreVendaModel.CampoDaGridDeTotalDoProduto), LancarItemNaPreVendaModel.ItemComDescontoNoPreVenda);
            AvancarPreVenda();
            AvancarPreVenda();
            DriverService.RealizarSelecaoDaAcao(PreVendaModel.AcoesDaPreVenda, 2);
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.GridDeFormaDePagamento, 1);
            FecharTelaDePreVendaComEsc();
        }

        private void LancarProdutoPadrao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(PreVendaModel.ElementoTelaDePreVenda);
        }

        private void AvancarPreVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);

        private void FecharTelaDePreVendaComEsc() =>
            DriverService.FecharJanelaComEsc(PreVendaModel.ElementoTelaDePreVenda);
    }
}
