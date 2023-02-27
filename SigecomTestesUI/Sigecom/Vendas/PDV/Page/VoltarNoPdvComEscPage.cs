using System;
using Autofac;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class VoltarNoPdvComEscPage : PageObjectModel
    {
        public VoltarNoPdvComEscPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PdvModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PdvModel.BotaoSubMenu);

        public void RealizarFluxoDeVoltarNoPdv()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProdutoPadrao();
            PagarPedido();
            DriverService.DigitarNoCampoId(PdvModel.GridDeFormaDePagamento, "1");
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.ElementoTotalPagamento, "5", Keys.Enter);
            DriverService.DigitarNoCampoId(PdvModel.GridDeFormaDePagamento, "3");
            FecharTelaDeVendaComEsc();
        }

        private void LancarProdutoPadrao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(PdvModel.ElementoTelaDePdv);
        }

        private void PagarPedido() =>
            ClicarBotaoName(PdvModel.ElementoNamePagarPedido);

        private void FecharTelaDeVendaComEsc()
        {
            DriverService.FecharJanelaComEsc("Pdv");
            DriverService.FecharJanelaComEsc("Pdv");
            ClicarBotaoName(", Sim (ENTER)");
            ClicarBotaoName(PdvModel.AtalhoDoPdv);
            ClicarBotaoName(PdvModel.AtalhoDeSairDoPdv);
            ClicarBotaoName(", Sim (ENTER)");
        }

    }
}
