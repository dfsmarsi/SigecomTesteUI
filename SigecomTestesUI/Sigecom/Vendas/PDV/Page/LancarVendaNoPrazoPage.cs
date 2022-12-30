using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class LancarVendaNoPrazoPage:ILancarFormaDePagamentoPage
    {
        private readonly DriverService _driverService;

        public LancarVendaNoPrazoPage(DriverService driverService) => _driverService = driverService;

        public void SelecionarFormaDePagamento() => 
            _driverService.RealizarSelecaoDaFormaDePagamentoADireita(PdvModel.GridDeFormaDePagamento, 3);
    }
}
