using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Model;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Model;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page
{
    public class ClonarNaConsultaDePreVendaPage: PageObjectModel
    {
        public ClonarNaConsultaDePreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDePreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDePreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeClonarNaConsultaDePreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.AbrirFecharAbaDeFiltroTelaDeConsulta("Consulta de pré vendas");
            DriverService.DigitarNoCampoId("comboBoxEditFiltroMes", "p");
            DriverService.DigitarNoCampoId("dateEditDataInicio", "13032023");
            DriverService.DigitarNoCampoId("dateEditDataFim", "13032023");
            DriverService.ClicarBotaoName(", Filtrar");

            DriverService.CliqueNoElementoDaGridComVarios("Valor", "R$11,11");
            ClicarBotaoName(ConsultaDePreVendaModel.BotaoDaClonarPreVenda);
            DriverService.EditarItensNaGridComDuploClickComTab(PreVendaModel.CampoDaGridDeQuantidadeDoProduto, LancarItemNaPreVendaModel.QuantidadeParaClonarPreVenda);
            DriverService.EditarItensNaGridComDuploClickComTab(PreVendaModel.CampoDaGridDeValorUnitarioDoProduto, LancarItemNaPreVendaModel.ValorTotalParaClonarPreVenda);
            DriverService.EditarItensNaGridComDuploClickComTab(PreVendaModel.CampoDaGridDeDescontoDoProduto, LancarItemNaPreVendaModel.DescontoParaClonarPreVenda);
            AvancarPreVenda();
            AvancarPreVenda();
            DriverService.RealizarSelecaoDaAcao(PreVendaModel.AcoesDaPreVenda, 2);
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.GridDeFormaDePagamento, 1);
            DriverService.CliqueNoElementoDaGridComVariosEVerificar(PreVendaModel.CampoDaGridDeValorTotalDaTelaDeConsultaDePreVenda, LancarItemNaPreVendaModel.VerificarValorTotalParaClonarPreVenda);
        }

        private void AvancarPreVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);
    }
}
