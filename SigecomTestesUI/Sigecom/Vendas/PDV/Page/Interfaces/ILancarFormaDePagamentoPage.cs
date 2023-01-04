using SigecomTestesUI.Sigecom.Vendas.PDV.Enum;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces
{
    public interface ILancarFormaDePagamentoPage
    {
        void RealizarFluxoDeLancarVendaNoPdv(LancarVendaNaFormaDePagamentoPage lancarVendaNaFormaDePagamentoPage, FormaDePagamento formaDePagamento);
    }
}
