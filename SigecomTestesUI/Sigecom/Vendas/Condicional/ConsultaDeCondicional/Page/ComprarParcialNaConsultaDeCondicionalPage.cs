using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Model;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Model;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Page;
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
            var condicionalBasePage = beginLifetimeScope.Resolve<Func<DriverService, CondicionalBasePage>>()(DriverService);
            RealizarOFluxoDeGerarCondicionalNaConsulta(condicionalBasePage.RetornarIdDoProduto(), condicionalBasePage);
            EsperarAcaoEmSegundos(1);
            RealizarOCompraParcialNaConsulta();
            FecharTelaDeCondicionalComEsc();
        }

        private void RealizarOFluxoDeGerarCondicionalNaConsulta(string idDoProduto, CondicionalBasePage condicionalBasePage)
        {
            ClicarBotaoName(ConsultaDeCondicionalModel.BotaoDaNovaCondicional);
            condicionalBasePage.AbrirOAtalhoParaSelecionarCliente();
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
