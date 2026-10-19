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
            EsperarAcaoEmSegundos(3); // tela de consulta de vendas terminar de carregar antes de abrir o filtro
            DriverService.DigitarNoCampoId("cbxFiltroMes", "p");
            EsperarAcaoEmSegundos(2); // trocar o período recarrega a grid; em máquina lenta o foco se perde e ativa a toggle de estornadas
            DriverService.DigitarNoCampoId(ConsultaDePedidoModel.NumeroDoPedido, "34");
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(ConsultaDePedidoModel.CampoDaGridValor), "R$5,55");
        }

        private void FecharTelaDaConsultaDeVendaComEsc() =>
            DriverService.FecharJanelaComEsc(ConsultaDePedidoModel.ElementoTelaDePedido);
    }
}
