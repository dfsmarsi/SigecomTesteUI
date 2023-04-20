﻿using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Enum;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class LancarVendaNoCreditoPage: ILancarFormaDePagamentoPage
    {
        private readonly DriverService _driverService;

        public LancarVendaNoCreditoPage(DriverService driverService) => 
            _driverService = driverService;

        public void RealizarFluxoDeLancarVendaNoPdv(LancarVendaNaFormaDePagamentoPage lancarVendaNaFormaDePagamentoPage, FormaDePagamento formaDePagamento)
        {
            lancarVendaNaFormaDePagamentoPage.ClicarNaOpcaoDoMenu();
            lancarVendaNaFormaDePagamentoPage.ClicarNaOpcaoDoSubMenu();
            lancarVendaNaFormaDePagamentoPage.LancarProdutoPadrao();
            lancarVendaNaFormaDePagamentoPage.PagarPedido();
            SelecionarFormaDePagamento();
            _driverService.ClicarBotaoName(PdvModel.ElementoNameDoConfirmar);
            lancarVendaNaFormaDePagamentoPage.FecharTelaDoPdv();
        }

        public void SelecionarFormaDePagamento() => 
            _driverService.RealizarSelecaoDaFormaDePagamento(PdvModel.GridDeFormaDePagamento, 2);
    }
}
