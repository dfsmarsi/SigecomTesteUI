using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Page
{
    public class AlterarTabelaDePrecoDaCondicionalPage: PageObjectModel
    {
        public AlterarTabelaDePrecoDaCondicionalPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CondicionalModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CondicionalModel.BotaoSubMenu);

        public void RealizarFluxoDeAlterarTabelaDePrecoNaCondicional()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            var idDoProduto = vendasBasePage.RetornarIdDoProduto();
            vendasBasePage.AbrirOAtalhoParaSelecionarCliente();
            LancarProduto(idDoProduto);
            DriverService.SelecionarItemComboBoxSemEnter(CondicionalModel.ElementoDoComboDaTabelaDePreco, 3);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(CondicionalModel.CampoDaGridDeTotalDoProduto),
                LancarItensNaCondicionalModel.ValorUnitarioDoPrimeiroProdutoNaCondicional);
            DriverService.SelecionarItemComboBoxSemEnter(CondicionalModel.ElementoDoComboDaTabelaDePreco, 1);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(CondicionalModel.CampoDaGridDeTotalDoProduto),
                LancarItensNaCondicionalModel.ValorUnitarioDoPrimeiroProdutoNaCondicional);
            LancarProduto(LancarItensNaCondicionalModel.PesquisarItemIdDoSegundoProdutoNaCondicional);
            Assert.AreEqual(
                DriverService.PegarValorDaColunaDaGridNaPosicao(CondicionalModel.CampoDaGridDeTotalDoProduto, "1"),
                LancarItensNaCondicionalModel.ValorUnitarioDoSegundoProdutoNaCondicional);
            AvancarNaCondicional();
            AvancarNaCondicional();
            DriverService.RealizarSelecaoDaAcao(CondicionalModel.AcoesDaCondicional, 2);
            FecharTelaDeCondicionalComEsc();
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(CondicionalModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarNaCondicional()
            => ClicarBotaoName(CondicionalModel.ElementoNameDoAvancar);

        private void FecharTelaDeCondicionalComEsc() =>
            DriverService.FecharJanelaComEsc(CondicionalModel.ElementoTelaDeCondicional);
    }
}
