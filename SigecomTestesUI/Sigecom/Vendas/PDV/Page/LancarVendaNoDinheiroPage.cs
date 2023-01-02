using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Enum;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class LancarVendaNoDinheiroPage: ILancarFormaDePagamentoPage
    {
        private readonly DriverService _driverService;

        public LancarVendaNoDinheiroPage(DriverService driverService) => 
            _driverService = driverService;

        public void RealizarFluxoDeLancarItemNoPdv(LancarItensNoPdvPage lancarItensNoPdvPage, FormaDePagamento formaDePagamento)
        {
            lancarItensNoPdvPage.ClicarNaOpcaoDoMenu();
            lancarItensNoPdvPage.ClicarNaOpcaoDoSubMenu();
            lancarItensNoPdvPage.LancarItemNoPedido();
            lancarItensNoPdvPage.EditarItemDoPedido();
            lancarItensNoPdvPage.PagarPedido();
            SelecionarFormaDePagamento();
            lancarItensNoPdvPage.ConcluirPedido();
            lancarItensNoPdvPage.FecharTelaDeVendaComEsc();
        }

        public void SelecionarFormaDePagamento() => 
            _driverService.RealizarAtalhoEnterNaFormaDePagamento(PdvModel.GridDeFormaDePagamento);
    }
}
