using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Pedido.ConsultaDePedido.Model;

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
            RealizarFluxoDeVerificarVendasRealizadas();
            FecharTelaDaConsultaDeVendaComEsc();
        }

        private void RealizarFluxoDeVerificarVendasRealizadas()
        {
            ClicarBotaoName("Filtro (F3)");
            DriverService.DigitarNoCampoId(ConsultaDePedidoModel.NumeroDoPedido, "6");
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(ConsultaDePedidoModel.CampoDaGridValor), "R$5,55");
        }

        private void FecharTelaDaConsultaDeVendaComEsc() =>
            DriverService.FecharJanelaComEsc(ConsultaDePedidoModel.ElementoTelaDePedido);
    }
}
