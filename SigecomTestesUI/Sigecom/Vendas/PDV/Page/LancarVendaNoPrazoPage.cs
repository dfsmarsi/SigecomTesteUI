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
            if (_driverService.VerificarSePossuiOValorNaTela("Prosseguir assim mesmo - F5"))
                _driverService.ClicarBotaoName("Prosseguir assim mesmo - F5");
            lancarVendaNaFormaDePagamentoPage.ConcluirPedido();
            FecharTela();
        }

        private void FecharTela()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _driverService.TrocarJanela();
            _driverService.ClicarBotaoName("Saída");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _driverService.ClicarBotaoName(PdvModel.AtalhoDoPdv);
            _driverService.ClicarBotaoName(PdvModel.AtalhoDeSairDoPdv);
        }

        public void SelecionarFormaDePagamento() => 
            _driverService.RealizarSelecaoDaFormaDePagamento(PdvModel.GridDeFormaDePagamento, 3);
    }
}
