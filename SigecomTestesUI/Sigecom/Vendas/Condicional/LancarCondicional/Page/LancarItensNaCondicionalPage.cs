using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Page
{
    public class LancarItensNaCondicionalPage: PageObjectModel
    {
        public LancarItensNaCondicionalPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CondicionalModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CondicionalModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarItemNaCondicional()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var condicionalBasePage = beginLifetimeScope.Resolve<Func<DriverService, CondicionalBasePage>>()(DriverService);
            condicionalBasePage.AbrirOAtalhoParaSelecionarCliente();
            var idDoProduto = condicionalBasePage.RetornarIdDoProduto();
            LancarProduto(LancarItensNaCondicionalModel.PesquisarItem);
            LancarProduto(idDoProduto);
            LancarProduto(LancarItensNaCondicionalModel.PesquisarItemReferencia);
            LancarProduto(LancarItensNaCondicionalModel.PesquisarItemCodInterno);
            LancarProduto($"1*{idDoProduto}");
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(CondicionalModel.CampoDaGridDeQuantidadeDoProduto), LancarItensNaCondicionalModel.QuantidadeDeProduto);
            AvancarNaCondicional();
            DriverService.DigitarNoCampoId(CondicionalModel.ElementoDeObservação, LancarItensNaCondicionalModel.Observacao);
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
