using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Enum;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class LancarVendaNoChequePage: ILancarFormaDePagamentoPage
    {
        private readonly DriverService _driverService;

        public LancarVendaNoChequePage(DriverService driverService) => _driverService = driverService;

        public void RealizarFluxoDeLancarItemNoPdv(LancarItensNoPdvPage lancarItensNoPdvPage, FormaDePagamento formaDePagamento)
        {
            lancarItensNoPdvPage.ClicarNaOpcaoDoMenu();
            lancarItensNoPdvPage.ClicarNaOpcaoDoSubMenu();
            lancarItensNoPdvPage.EditarClienteDoPedido();
            lancarItensNoPdvPage.LancarItemNoPedido();
            lancarItensNoPdvPage.PagarPedido();
            SelecionarFormaDePagamento();
            _driverService.ClicarBotaoName(", Confirmar (ENTER)");
            lancarItensNoPdvPage.ConcluirPedido();
            lancarItensNoPdvPage.FecharTelaDeVendaComEsc();
        }

        public void SelecionarFormaDePagamento() => 
            _driverService.RealizarSelecaoDaFormaDePagamento(PdvModel.GridDeFormaDePagamento, 4);
    }
}
