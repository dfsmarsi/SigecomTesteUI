using System;
using Autofac;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Page
{
    public class VoltarNaPreVendaComEscPage: PageObjectModel
    {
        public VoltarNaPreVendaComEscPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeVoltarNaPreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProdutoPadrao();
            AvancarPreVenda();
            AvancarPreVenda();
            SelecionarAcaoDaPreVenda();
            DriverService.RealizarSelecaoDaFormaDePagamentoSemEnter(PreVendaModel.GridDeFormaDePagamento, 1);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PreVendaModel.ElementoTotalPagamento, "5", Keys.Enter);
            DriverService.RealizarSelecaoDaFormaDePagamentoSemEnter(PreVendaModel.GridDeFormaDePagamento, 3);
            FecharTelaDePreVendaComEsc();
        }

        private void LancarProdutoPadrao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(PreVendaModel.ElementoTelaDePreVenda);
        }

        private void AvancarPreVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);

        private void SelecionarAcaoDaPreVenda() => 
            DriverService.RealizarSelecaoDaAcao(PreVendaModel.AcoesDaPreVenda, 2);

        private void FecharTelaDePreVendaComEsc()
        {
            FecharJanelaComEsc();
            FecharJanelaComEsc();
            DriverService.TrocarJanela();
            ClicarBotaoName(", Sim (ENTER)");
            DriverService.TrocarJanela();
            FecharJanelaComEsc();
            FecharJanelaComEsc();
            FecharJanelaComEsc();
            DriverService.TrocarJanela();
            DriverService.RealizarAcaoDaTeclaDeAtalhoNaTelaId("PerguntaMensagemView", Keys.Enter);
            DriverService.TrocarJanela();
        }

        private void FecharJanelaComEsc() => 
            DriverService.FecharJanelaComEsc(PreVendaModel.ElementoTelaDePreVenda);
    }
}
