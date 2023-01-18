using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Model;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Model;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page
{
    public class FaturarNaConsultaDePreVendaPage:PageObjectModel
    {
        public FaturarNaConsultaDePreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDePreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDePreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeFaturarNaConsultaDePreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            RealizarOFluxoDeGerarPreVendaNaConsulta();
            EsperarAcaoEmSegundos(1);
            RealizarOFaturaNaConsulta();
        }

        private void RealizarOFluxoDeGerarPreVendaNaConsulta()
        {
            ClicarBotaoName(ConsultaDePreVendaModel.BotaoDaNovaPreVenda);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PreVendaModel.ElementoPesquisaDeProduto,
                LancarItemNaPreVendaModel.PesquisarItemId, Keys.Enter);
            DriverService.EditarItensNaGridComDuploClick(PreVendaModel.CampoDaGridDeValorUnitarioDoProduto,
                LancarItemNaPreVendaModel.ValorTotalParaFaturarPreVenda);
            AvancarNaPreVenda();
            AvancarNaPreVenda();
            DriverService.RealizarSelecaoDaAcao(PreVendaModel.AcoesDaPreVenda, 2);
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.GridDeFormaDePagamento, 1);
        }

        private void RealizarOFaturaNaConsulta()
        {
            DriverService.CliqueNoElementoDaGridComVariosEVerificar(
                PreVendaModel.CampoDaGridDeValorTotalDaTelaDeConsultaDePreVenda,
                LancarItemNaPreVendaModel.VerificarValorTotalParaFaturarPreVenda);
            ClicarBotaoName(ConsultaDePreVendaModel.BotaoDaFaturarPreVenda);
            AvancarNaPreVenda();
            AvancarNaPreVenda();
            AvancarNaPreVenda();
            DriverService.RealizarSelecaoDaAcao(PreVendaModel.AcoesDaPreVenda, 2);
            AvancarNaPreVenda();
            EsperarAcaoEmSegundos(1);
            AcessarOpcaoSubMenu(PedidoModel.ElementoTelaConsultaDeVenda);
            DriverService.VerificarSePossuiOValorNaGrid(PreVendaModel.CampoDaGridDeValorTotalDaTelaDeConsultaDePreVenda,
                LancarItemNaPreVendaModel.VerificarValorTotalParaFaturarPreVenda);
        }

        private void AvancarNaPreVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);
    }
}
