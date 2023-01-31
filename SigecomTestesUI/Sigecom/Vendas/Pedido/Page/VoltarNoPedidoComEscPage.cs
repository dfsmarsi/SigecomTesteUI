using System;
using Autofac;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.Page
{
    public class VoltarNoPedidoComEscPage:PageObjectModel
    {
        public VoltarNoPedidoComEscPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PedidoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PedidoModel.BotaoSubMenu);

        public void RealizarFluxoDeVoltarNoPedido()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProdutoPadrao();
            AvancarVenda();
            AvancarVenda();
            DriverService.RealizarSelecaoDaAcao(PedidoModel.AcoesDoPedido, 2);
            DriverService.RealizarSelecaoDaFormaDePagamentoSemEnter(PedidoModel.GridDeFormaDePagamento, 1);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PedidoModel.ElementoTotalPagamento, "5", Keys.Enter);
            DriverService.RealizarSelecaoDaFormaDePagamentoSemEnter(PedidoModel.GridDeFormaDePagamento, 3);
            FecharTelaDeVendaComEsc();
        }

        private void LancarProdutoPadrao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(PedidoModel.ElementoTelaDeVenda);
        }

        private void AvancarVenda()
            => ClicarBotaoName(PedidoModel.ElementoNameDoAvancar);

        private void FecharTelaDeVendaComEsc()
        {
            DriverService.FecharJanelaComEsc(PedidoModel.ElementoTelaDeVenda);
            DriverService.FecharJanelaComEsc(PedidoModel.ElementoTelaDeVenda);
            ClicarBotaoName(", Sim (ENTER)");
            DriverService.FecharJanelaComEsc(PedidoModel.ElementoTelaDeVenda);
            DriverService.FecharJanelaComEsc(PedidoModel.ElementoTelaDeVenda);
            DriverService.FecharJanelaComEsc(PedidoModel.ElementoTelaDeVenda);
            ClicarBotaoName(", Sim (ENTER)");
        }
    }
}
