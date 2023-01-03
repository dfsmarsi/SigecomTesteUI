using OpenQA.Selenium;
using SigecomTestesUI.Sigecom.Vendas.PDV.Enum;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class LancarVendaComTrocoPage: ILancarFormaDePagamentoPage
    {
        private readonly DriverService _driverService;

        public LancarVendaComTrocoPage(DriverService driverService) => _driverService = driverService;

        public void RealizarFluxoDeLancarItemNoPdv(LancarItensNoPdvPage lancarItensNoPdvPage, FormaDePagamento formaDePagamento)
        {
            lancarItensNoPdvPage.ClicarNaOpcaoDoMenu();
            lancarItensNoPdvPage.ClicarNaOpcaoDoSubMenu();
            lancarItensNoPdvPage.LancarItemNoPedido();
            lancarItensNoPdvPage.PagarPedido();
            SelecionarFormaDePagamento();
            _driverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.TotalPagamento, "100", Keys.Enter);
            lancarItensNoPdvPage.ConcluirPedido();
            lancarItensNoPdvPage.FecharTelaDeVendaComEsc();
        }

        public void SelecionarFormaDePagamento() => 
            _driverService.RealizarAtalhoEnterNaFormaDePagamentoComTroco(PdvModel.GridDeFormaDePagamento);
    }
}
