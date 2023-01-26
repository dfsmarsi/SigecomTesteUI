using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.Page
{
    public class DarDescontoNoPedidoPage: PageObjectModel
    {
        public DarDescontoNoPedidoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PedidoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PedidoModel.BotaoSubMenu);

        public void RealizarFluxoDeDescontoNoItemDoPedido()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto(LancarItemNoPedidoModel.PesquisarItem);
            DriverService.DigitarNoCampoName(PedidoModel.CampoDaGridDeQuantidadeDoProduto, LancarItemNoPedidoModel.QuantidadeDeProduto);
            DriverService.EditarItensNaGridComDuploClickComEnter(PedidoModel.CampoDaGridDeDescontoDoProduto, LancarItemNoPedidoModel.DescontoNoItemPedido);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(PedidoModel.CampoDaGridDeTotalDoProduto), LancarItemNoPedidoModel.ItemComDescontoNoPedido);
            AvancarVenda();
            AvancarVenda();
            DriverService.RealizarSelecaoDaAcao(PedidoModel.AcoesDoPedido, 2);
            DriverService.RealizarSelecaoDaFormaDePagamento(PedidoModel.GridDeFormaDePagamento, 1);
            FecharTelaDeVendaComEsc();
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(PedidoModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarVenda()
            => ClicarBotaoName(PedidoModel.ElementoNameDoAvancar);

        private void FecharTelaDeVendaComEsc() =>
            DriverService.FecharJanelaComEsc(PedidoModel.ElementoTelaDeVenda);
    }
}
