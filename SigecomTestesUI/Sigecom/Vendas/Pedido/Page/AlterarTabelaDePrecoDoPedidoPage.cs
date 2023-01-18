using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.Page
{
    public class AlterarTabelaDePrecoDoPedidoPage: PageObjectModel
    {
        public AlterarTabelaDePrecoDoPedidoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PedidoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PedidoModel.BotaoSubMenu);

        public void RealizarFluxoDeAlterarTabelaDePrecoNoPedido()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto(LancarItemNoPedidoModel.PesquisarItemId);
            DriverService.SelecionarItemComboBoxSemEnter(PedidoModel.ElementoDoComboDaTabelaDePreco,3);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(PedidoModel.CampoDaGridDeTotalDoProduto), LancarItemNoPedidoModel.ValorUnitarioDoPrimeiroProdutoNoPedido);
            DriverService.SelecionarItemComboBoxSemEnter(PedidoModel.ElementoDoComboDaTabelaDePreco, 4);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(PedidoModel.CampoDaGridDeTotalDoProduto), LancarItemNoPedidoModel.ValorUnitarioDoPrimeiroProdutoNoPedido);
            LancarProduto(LancarItemNoPedidoModel.PesquisarItemIdDoSegundoProdutoNoPedido);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao(PedidoModel.CampoDaGridDeTotalDoProduto, "1"), LancarItemNoPedidoModel.ValorUnitarioDoSegundoProdutoNoPedido);
            AvancarVenda();
            AvancarVenda();
            DriverService.RealizarSelecaoDaFormaDePagamento(PedidoModel.AcoesDoPedido, 2);
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
