using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Model;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page
{
    public class EditarNaConsultaDePreVendaPage:PageObjectModel
    {
        public EditarNaConsultaDePreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDePreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDePreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeEditarNaConsultaDePreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.ClicarBotaoName("Filtro (F3)");
            DriverService.DigitarNoCampoId("comboBoxEditFiltroMes", "p");
            DriverService.DigitarNoCampoId("txtDataInicio", "13032023");
            DriverService.DigitarNoCampoId("txtDataFim", "13032023");
            DriverService.ClicarBotaoName(", Filtrar");
            DriverService.CliqueNoElementoDaGridComVarios("Valor", "R$12,12");
            ClicarBotaoName(ConsultaDePreVendaModel.BotaoDaEditarPreVenda);
            DriverService.DigitarNoCampoName(PreVendaModel.CampoDaGridDeValorUnitarioDoProduto, LancarItemNaPreVendaModel.ValorUnitarioParaEditarPreVenda);
            AvancarPreVenda();
            AvancarPreVenda();
            DriverService.RealizarSelecaoDaAcao(PreVendaModel.AcoesDaPreVenda, 2);
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.GridDeFormaDePagamento, 1);
        }

        private void AvancarPreVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);
    }
}
