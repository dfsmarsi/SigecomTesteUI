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
