using System;
using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Page
{
    public class AlterarTabelaDePrecoDaPreVendaPage: PageObjectModel
    {
        public AlterarTabelaDePrecoDaPreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeAlterarTabelaDePrecoNaPreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProdutoPadrao();
            SelecionarItemComboBox(3);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Total"), LancarItemNaPreVendaModel.ValorUnitarioDoPrimeiroProdutoNoPreVenda);
            SelecionarItemComboBox(4);
            LancarProduto(LancarItemNaPreVendaModel.PesquisarItemIdDoSegundoProdutoNoPreVenda);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Total", "1"), LancarItemNaPreVendaModel.ValorUnitarioDoSegundoProdutoNoPreVenda);
            AvancarPreVenda();
            AvancarPreVenda();
            DriverService.RealizarSelecaoDaAcao(PreVendaModel.AcoesDaPreVenda, 2);
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.GridDeFormaDePagamento, 1);
            FecharTelaDePreVendaComEsc();
        }

        private void LancarProdutoPadrao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(PreVendaModel.ElementoTelaDePreVenda);
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(PreVendaModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void SelecionarItemComboBox(int posicao)
            => DriverService.SelecionarItemComboBoxSemEnter(PreVendaModel.ElementoDoComboDaTabelaDePreco, posicao);

        private void AvancarPreVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);

        private void FecharTelaDePreVendaComEsc() =>
            DriverService.FecharJanelaComEsc(PreVendaModel.ElementoTelaDePreVenda);
    }
}
