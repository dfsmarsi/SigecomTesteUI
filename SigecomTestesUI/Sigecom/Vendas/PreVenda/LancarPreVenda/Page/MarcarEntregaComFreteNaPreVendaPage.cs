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
    public class MarcarEntregaComFreteNaPreVendaPage: PageObjectModel
    {
        public MarcarEntregaComFreteNaPreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeMarcarEntregaComFrete()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoName(PreVendaModel.BotaoAtalhosPreVenda);
            ClicarBotaoName(PreVendaModel.AtalhoDeEditarClienteDaPreVenda);
            LancarProdutoPadraoEAtribuirCliente();
            AvancarNaPreVenda();
            ClicarBotaoName(PreVendaModel.ElementoNameSelecionar);
            DriverService.DarDuploCliqueNoBotaoId(PreVendaModel.ElementoDeTaxaEntrega);
            DriverService.DigitarNoCampoId(PreVendaModel.ElementoDeTaxaEntrega, LancarItemNaPreVendaModel.LancarValorDaEntrega);
            AvancarNaPreVenda();
            DriverService.RealizarSelecaoDaAcao(PreVendaModel.AcoesDaPreVenda, 4);
            DriverService.RealizarSelecaoDaFormaDePagamentoSemEnter(PreVendaModel.GridDeFormaDePagamento, 1);
            Assert.AreEqual(DriverService.ObterValorElementoId(PreVendaModel.ValorTotalParaPagarAoFaturar), LancarItemNaPreVendaModel.ValorTotalComFrete);
            AvancarNaPreVenda();
            FecharTelaDePreVendaComEsc();
        }

        private void LancarProdutoPadraoEAtribuirCliente()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.AbrirOAtalhoParaSelecionarCliente();
            vendasBasePage.LancarProdutoPadraoNaVenda(PreVendaModel.ElementoTelaDePreVenda);
        }

        private void AvancarNaPreVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);

        private void FecharTelaDePreVendaComEsc() =>
            DriverService.FecharJanelaComEsc(PreVendaModel.ElementoTelaDePreVenda);
    }
}
