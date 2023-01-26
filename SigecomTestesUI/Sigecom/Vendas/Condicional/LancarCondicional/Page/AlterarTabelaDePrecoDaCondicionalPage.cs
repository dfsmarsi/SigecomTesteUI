using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Model;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
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
            var idDoProduto = CriarProdutoTeste();
            ClicarBotaoName(CondicionalModel.BotaoAtalhosCondicional);
            ClicarBotaoName(CondicionalModel.AtalhoDeEditarClienteDaCondicional);
            SelecionarCliente();
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

        private string CriarProdutoTeste()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var pesquisaDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>()(DriverService);
            var idDoProduto = pesquisaDeProdutoPage.PesquisarComF9UmProdutoNaTelaDeVenda(beginLifetimeScope, CondicionalModel.ElementoTelaDeCondicional)
                ? DriverService.PegarValorDaColunaDaGrid("Código")
                : pesquisaDeProdutoPage.CriarNovoProduto(beginLifetimeScope);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
            return idDoProduto;
        }

        private void SelecionarCliente()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>()(DriverService).PesquisarPessoaComConfirmar("cliente", "CLIENTE TESTE PESQUISA");
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(CondicionalModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarNaCondicional()
            => ClicarBotaoName(CondicionalModel.ElementoNameDoAvancar);

        private void FecharTelaDeCondicionalComEsc() =>
            DriverService.FecharJanelaComEsc(CondicionalModel.ElementoTelaDeCondicional);
    }
}
