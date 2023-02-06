using System;
using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Pedido.ConsultaDePedido.Model;
using SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Model;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.ConsultaDePedido.Page
{
    public class ConsultarVendasRealizadasPage: PageObjectModel
    {
        public ConsultarVendasRealizadasPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDePedidoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDePedidoModel.BotaoSubMenu);

        public void RealizarFluxoDeConsultarVendasRealizadas()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            RealizarFluxoDeGerarPedidoNaConsultaDePedido();
            RealizarFluxoDeVerificarVendasRealizadas();
            FecharTelaDaConsultaDeVendaComEsc();
        }

        private void RealizarFluxoDeGerarPedidoNaConsultaDePedido()
        {
            ClicarBotaoName(ConsultaDePedidoModel.BotaoDaNovoPedido);
            LancarProdutoPadrao();
            DriverService.EditarItensNaGridComDuploClickComTab(PedidoModel.CampoDaGridDeUnitarioDoProduto, LancarItemNoPedidoModel.ValorUnitarioParaVerificarVendasRealizadas);
            AvancarVenda();
            AvancarVenda();
            DriverService.RealizarSelecaoDaAcao(PedidoModel.AcoesDoPedido, 2);
            DriverService.RealizarSelecaoDaFormaDePagamento(PedidoModel.GridDeFormaDePagamento, 1);
        }

        private void RealizarFluxoDeVerificarVendasRealizadas() => 
            DriverService.VerificarSePossuiOValorNaGrid(ConsultaDePedidoModel.CampoDaGridValor, $"R${LancarItemNoPedidoModel.ValorUnitarioParaVerificarVendasRealizadas}");

        private void LancarProdutoPadrao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(PedidoModel.ElementoTelaDeVenda);
        }

        private void AvancarVenda()
            => ClicarBotaoName(PedidoModel.ElementoNameDoAvancar);

        private void FecharTelaDaConsultaDeVendaComEsc() =>
            DriverService.FecharJanelaComEsc(ConsultaDePedidoModel.ElementoTelaDePedido);
    }
}
