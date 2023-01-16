﻿using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Model;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page
{
    public class EditarNoConsultaDePreVendaPage:PageObjectModel
    {
        public EditarNoConsultaDePreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDePreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDePreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeEditarNaConsultaDePreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoName(ConsultaDePreVendaModel.BotaoDaEditarPreVenda);
            DriverService.DigitarNoCampoName(PreVendaModel.CampoDaGridDeValorUnitarioDoProduto, PreVendaModel.ValorUnitarioNaPreVenda);
            AvancarVenda();
            AvancarVenda();
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.AcoesDaPreVenda, 2);
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.GridDeFormaDePagamento, 1);
        }

        private void AvancarVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);
    }
}
