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
            LancarProdutoEAtribuirCliente();
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(CondicionalModel.CampoDaGridDeQuantidadeDoProduto), LancarItensNaCondicionalModel.QuantidadeDeProduto);
            AvancarNaCondicional();
            DriverService.DigitarNoCampoId(CondicionalModel.ElementoDeObservação, LancarItensNaCondicionalModel.Observacao);
            AvancarNaCondicional();
            DriverService.RealizarSelecaoDaAcao(CondicionalModel.AcoesDaCondicional, 2);
            FecharTelaDeCondicionalComEsc();
        }

        private void LancarProdutoEAtribuirCliente()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            var idDoProduto = vendasBasePage.LancarProdutoPadraoNaVenda();
            LancarProduto(LancarItensNaCondicionalModel.PesquisarItem);
            LancarProduto(LancarItensNaCondicionalModel.PesquisarItemReferencia);
            LancarProduto(LancarItensNaCondicionalModel.PesquisarItemCodInterno);
            LancarProduto($"1*{idDoProduto}");
            vendasBasePage.AbrirOAtalhoParaSelecionarCliente();
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(CondicionalModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarNaCondicional()
            => ClicarBotaoName(CondicionalModel.ElementoNameDoAvancar);

        private void FecharTelaDeCondicionalComEsc() =>
            DriverService.FecharJanelaComEsc(CondicionalModel.ElementoTelaDeCondicional);
    }
}
