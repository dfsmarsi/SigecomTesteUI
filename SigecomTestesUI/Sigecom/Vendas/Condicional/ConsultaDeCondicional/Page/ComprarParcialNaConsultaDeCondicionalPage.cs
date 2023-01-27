using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Model;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Page
{
    public class ComprarParcialNaConsultaDeCondicionalPage: PageObjectModel
    {
        public ComprarParcialNaConsultaDeCondicionalPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDeCondicionalModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDeCondicionalModel.BotaoSubMenu);

        public void RealizarFluxoDeCompraParcialNaConsultaDeCondicional()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            var idDoProduto = vendasBasePage.RetornarIdDoProduto();
            RealizarOFluxoDeGerarCondicionalNaConsulta(idDoProduto, vendasBasePage);
            EsperarAcaoEmSegundos(1);
            RealizarOCompraParcialNaConsulta();
            FecharTelaDeCondicionalComEsc();
        }

        private void RealizarOFluxoDeGerarCondicionalNaConsulta(string idDoProduto, IVendasBasePage vendasBasePage)
        {
            ClicarBotaoName(ConsultaDeCondicionalModel.BotaoDaNovaCondicional);
            vendasBasePage.AbrirOAtalhoParaSelecionarCliente();
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CondicionalModel.ElementoPesquisaDeProduto, idDoProduto, Keys.Enter);
            DriverService.EditarItensNaGridComDuploClickComTab(CondicionalModel.CampoDaGridDeQuantidadeDoProduto, LancarItensNaCondicionalModel.QuantidadeDeProduto);
            AvancarNaCondicional();
            AvancarNaCondicional();
            DriverService.RealizarSelecaoDaAcao(CondicionalModel.AcoesDaCondicional, 2);
        }

        private void RealizarOCompraParcialNaConsulta()
        {
            ClicarBotaoName(ConsultaDeCondicionalModel.BotaoDeComprarParcialCondicional);
            Assert.Greater(DriverService.ObterValorElementoName(ConsultaDeCondicionalModel.CampoQuantidadeCondicional),
                DriverService.ObterValorElementoName(ConsultaDeCondicionalModel.CampoQuantidadeComprada));
            DriverService.EditarItensNaGridComDuploClickComTab(ConsultaDeCondicionalModel.CampoQuantidadeComprada,
                LancarItensNaCondicionalModel.QuantidadeCompradaParaCompraParcial);
            Assert.Greater(DriverService.ObterValorElementoName(ConsultaDeCondicionalModel.CampoQuantidadeCondicional),
                DriverService.ObterValorElementoName(ConsultaDeCondicionalModel.CampoQuantidadeComprada));
            AvancarNaCondicional();
            AvancarNaCondicional();
            DriverService.RealizarSelecaoDaFormaDePagamento(CondicionalModel.GridDeFormaDePagamento, 1);
        }

        private void AvancarNaCondicional()
            => ClicarBotaoName(CondicionalModel.ElementoNameDoAvancar);

        private void FecharTelaDeCondicionalComEsc() =>
            DriverService.FecharJanelaComEsc(ConsultaDeCondicionalModel.ElementoTelaDeCondicional);
    }
}
