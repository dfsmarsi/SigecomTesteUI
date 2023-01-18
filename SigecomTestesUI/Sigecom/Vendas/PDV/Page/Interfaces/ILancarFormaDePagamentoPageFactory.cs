using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Enum;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces
{
    public interface ILancarFormaDePagamentoPageFactory
    {
        ILancarFormaDePagamentoPage Fabricar(DriverService driverService, FormaDePagamento formaDePagamento);
    }
}
