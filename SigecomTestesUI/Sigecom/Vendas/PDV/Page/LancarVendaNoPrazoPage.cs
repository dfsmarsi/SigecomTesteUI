using System;
using System.Threading;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Enum;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class LancarVendaNoPrazoPage:ILancarFormaDePagamentoPage
    {
        private readonly DriverService _driverService;

        public LancarVendaNoPrazoPage(DriverService driverService) => _driverService = driverService;

        public void RealizarFluxoDeLancarVendaNoPdv(LancarVendaNaFormaDePagamentoPage lancarVendaNaFormaDePagamentoPage, FormaDePagamento formaDePagamento)
        {
            lancarVendaNaFormaDePagamentoPage.ClicarNaOpcaoDoMenu();
            lancarVendaNaFormaDePagamentoPage.ClicarNaOpcaoDoSubMenu();
            lancarVendaNaFormaDePagamentoPage.EditarClienteDoPedido();
            lancarVendaNaFormaDePagamentoPage.LancarProdutoPadrao();
            lancarVendaNaFormaDePagamentoPage.PagarPedido();
            SelecionarFormaDePagamento();
            lancarVendaNaFormaDePagamentoPage.FecharTelaDoPdv();
        }

        public void SelecionarFormaDePagamento() => 
            _driverService.RealizarSelecaoDaFormaDePagamento(PdvModel.GridDeFormaDePagamento, 3);
    }
}
