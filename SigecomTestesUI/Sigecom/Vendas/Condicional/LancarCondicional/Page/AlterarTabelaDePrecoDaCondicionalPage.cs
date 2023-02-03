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
            AcessarOpcaoMenu(CondicionalModel.BotaoMenuVendas);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CondicionalModel.BotaoSubMenu);

        public void RealizarFluxoDeAlterarTabelaDePrecoNaCondicional()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProdutoEAtribuirCliente();
            AlterarTabelaDePreco(3);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(CondicionalModel.CampoDaGridDeTotalDoProduto),
                LancarItensNaCondicionalModel.ValorUnitarioDoPrimeiroProdutoNaCondicional);
            AlterarTabelaDePreco(1);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(CondicionalModel.CampoDaGridDeTotalDoProduto),
                LancarItensNaCondicionalModel.ValorUnitarioDoPrimeiroProdutoNaCondicional);
            LancarProduto(LancarItensNaCondicionalModel.PesquisarItemIdDoSegundoProdutoNaCondicional);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao(CondicionalModel.CampoDaGridDeTotalDoProduto, "1"),
                LancarItensNaCondicionalModel.ValorUnitarioDoSegundoProdutoNaCondicional);
            AvancarNaCondicional();
            AvancarNaCondicional();
            DriverService.RealizarSelecaoDaAcao(CondicionalModel.AcoesDaCondicional, 2);
            FecharTelaDeCondicionalComEsc();
        }

        private void LancarProdutoEAtribuirCliente()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(CondicionalModel.ElementoTelaDeCondicional);
            vendasBasePage.AbrirOAtalhoParaSelecionarCliente();
        }

        private void AlterarTabelaDePreco(int posicao) =>
            DriverService.SelecionarItemComboBoxSemEnter(CondicionalModel.ElementoDoComboDaTabelaDePreco, posicao);

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(CondicionalModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarNaCondicional()
            => ClicarBotaoName(CondicionalModel.ElementoNameDoAvancar);

        private void FecharTelaDeCondicionalComEsc() =>
            DriverService.FecharJanelaComEsc(CondicionalModel.ElementoTelaDeCondicional);
    }
}
