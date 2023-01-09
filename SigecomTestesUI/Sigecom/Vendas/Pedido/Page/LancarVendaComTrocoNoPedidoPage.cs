using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.Page
{
    public class LancarVendaComTrocoNoPedidoPage: PageObjectModel
    {
        public LancarVendaComTrocoNoPedidoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PedidoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PedidoModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarVendaComTrocoNoPedido()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto(LancarItemNoPedidoModel.PesquisarItemId);
            AvancarVenda();
            AvancarVenda();
            DriverService.RealizarSelecaoDaFormaDePagamento(PedidoModel.AcoesDoPedido, 2);
            DriverService.DigitarNoCampoId(PedidoModel.GridDeFormaDePagamento, "1");
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PedidoModel.ElementoTotalPagamento,
                LancarItemNoPedidoModel.ValorTotalParaGerarTroco, Keys.Enter);
            ClicarBotaoName(PedidoModel.ElementoNameDoConfirmar);
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
