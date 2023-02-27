using System;
using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Page
{
    public class LancarVendaDeBancoNoPedidoPage: PageObjectModel
    {
        public LancarVendaDeBancoNoPedidoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PedidoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PedidoModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarVendaDeBancoNoPedido()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProdutoPadrao();
            AvancarVenda();
            AvancarVenda();
            DriverService.RealizarSelecaoDaAcao(PedidoModel.AcoesDoPedido, 2);
            DriverService.RealizarSelecaoDaFormaDePagamento(PedidoModel.GridDeFormaDePagamento, 5);
            ClicarBotaoName(PedidoModel.ElementoNameDoConfirmar);
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

        private void FecharTelaDeVendaComEsc() =>
            DriverService.FecharJanelaComEsc(PedidoModel.ElementoTelaDeVenda);
    }
}
