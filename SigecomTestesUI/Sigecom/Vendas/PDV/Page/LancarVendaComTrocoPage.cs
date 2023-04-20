using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using System;
using System.Threading;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class LancarVendaComTrocoPage: PageObjectModel
    {
        public LancarVendaComTrocoPage(DriverService driver) : base(driver)
        {
        }

        internal void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PdvModel.BotaoMenuCadastro);

        internal void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PdvModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarVendaNoPdv()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProdutoPadrao();
            PagarPedido();
            SelecionarFormaDePagamento();
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.ElementoTotalPagamento, LancarItemNoPdvModel.ValorTotalParaVoltarTroco, Keys.Enter);
            FecharTelaDoPdv();
        }

        private void LancarProdutoPadrao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(PdvModel.ElementoTelaDePdv);
        }

        internal void PagarPedido() =>
            ClicarBotaoName(PdvModel.ElementoNamePagarPedido);

        public void SelecionarFormaDePagamento() =>
            DriverService.DigitarNoCampoId(PdvModel.GridDeFormaDePagamento, "1");

        private void FecharTelaDoPdv()
        {
            EsperarAcaoEmSegundos(3);
            DriverService.FecharJanelaComEscId("scProdutos");
        }
    }
}
