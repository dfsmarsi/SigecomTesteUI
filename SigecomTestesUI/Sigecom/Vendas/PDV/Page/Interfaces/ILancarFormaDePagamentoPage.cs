using SigecomTestesUI.Sigecom.Vendas.PDV.Enum;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces
{
    public interface ILancarFormaDePagamentoPage
    {
        void RealizarFluxoDeLancarItemNoPdv(LancarItensNoPdvPage lancarItensNoPdvPage, FormaDePagamento formaDePagamento);
    }
}
