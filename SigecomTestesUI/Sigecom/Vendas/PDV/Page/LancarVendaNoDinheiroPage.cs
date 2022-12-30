using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class LancarVendaNoDinheiroPage: ILancarFormaDePagamentoPage
    {
        private readonly DriverService _driverService;

        public LancarVendaNoDinheiroPage(DriverService driverService) => 
            _driverService = driverService;

        public void SelecionarFormaDePagamento() => 
            _driverService.RealizarAtalhoEnterNaFormaDePagamento(PdvModel.GridDeFormaDePagamento);
    }
}
