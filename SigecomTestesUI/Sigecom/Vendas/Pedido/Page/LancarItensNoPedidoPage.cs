using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.Page
{
    public class LancarItensNoPedidoPage : PageObjectModel
    {
        public LancarItensNoPedidoPage(DriverService driver) : base(driver) { }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PedidoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PedidoModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarItemNoPedido()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto(LancarItemNoPedidoModel.PesquisarItem);
            LancarProduto(LancarItemNoPedidoModel.PesquisarItemId);
            LancarProduto(LancarItemNoPedidoModel.PesquisarItemReferencia);
            LancarProduto(LancarItemNoPedidoModel.PesquisarItemCodInterno);
            LancarProduto(LancarItemNoPedidoModel.PesquisarItemMultiplicadorDeQuantidade);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Qtde"), LancarItemNoPedidoModel.QuantidadeDeProduto);
            AvancarVenda();
            DriverService.DigitarNoCampoId(PedidoModel.ElementoDeObservação, LancarItemNoPedidoModel.Observacao);
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
