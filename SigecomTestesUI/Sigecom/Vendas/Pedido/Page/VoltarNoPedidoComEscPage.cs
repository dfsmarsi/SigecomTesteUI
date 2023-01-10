using OpenQA.Selenium;
using SigecomTestesUI.Config;
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
            LancarProduto(LancarItemNoPedidoModel.PesquisarItem);
            AvancarVenda();
            AvancarVenda();
            DriverService.RealizarSelecaoDaFormaDePagamento(PedidoModel.AcoesDoPedido, 2);
            DriverService.DigitarNoCampoId(PedidoModel.GridDeFormaDePagamento, "1");
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PedidoModel.ElementoTotalPagamento, "5", Keys.Enter);
            DriverService.DigitarNoCampoId(PedidoModel.GridDeFormaDePagamento, "3");
            FecharTelaDeVendaComEsc();
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(PedidoModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

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
