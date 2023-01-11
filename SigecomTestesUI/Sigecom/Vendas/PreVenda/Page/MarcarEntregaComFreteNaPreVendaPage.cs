using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.Page
{
    public class MarcarEntregaComFreteNaPreVendaPage: PageObjectModel
    {
        public MarcarEntregaComFreteNaPreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeMarcarEntregaComFrete()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoName(PreVendaModel.BotaoAtalhosPreVenda);
            ClicarBotaoName(PreVendaModel.AtalhoDeEditarClienteDaPreVenda);
            SelecionarCliente();
            LancarProduto(LancarItemNaPreVendaModel.PesquisarItemId);
            AvancarVenda();
            ClicarBotaoName(PreVendaModel.ElementoNameSelecionar);
            DriverService.DarDuploCliqueNoBotaoId(PreVendaModel.ElementoDeTaxaEntrega);
            DriverService.DigitarNoCampoId(PreVendaModel.ElementoDeTaxaEntrega, LancarItemNaPreVendaModel.LancarValorDaEntrega);
            AvancarVenda();
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.AcoesDaPreVenda, 4);
            Assert.AreEqual(DriverService.ObterValorElementoId(PreVendaModel.ValorTotalParaPagarAoFaturar), LancarItemNaPreVendaModel.ValorTotalComFrete);
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.GridDeFormaDePagamento, 1);
            FecharTelaDeVendaComEsc();
        }

        private void SelecionarCliente()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>()(DriverService).PesquisarPessoaComConfirmar("cliente", "CLIENTE TESTE PESQUISA");
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(PreVendaModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);

        private void FecharTelaDeVendaComEsc() =>
            DriverService.FecharJanelaComEsc(PreVendaModel.ElementoTelaDePreVenda);
    }
}
