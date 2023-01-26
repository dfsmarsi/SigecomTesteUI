using Autofac;
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
    public class VoltarNaCondicionalComEscPage: PageObjectModel
    {
        public VoltarNaCondicionalComEscPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CondicionalModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CondicionalModel.BotaoSubMenu);

        public void RealizarFluxoDeVoltarNaCondicionalComEsc()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            var idDoProduto = CriarProdutoTeste();
            ClicarBotaoName(CondicionalModel.BotaoAtalhosCondicional);
            ClicarBotaoName(CondicionalModel.AtalhoDeEditarClienteDaCondicional);
            SelecionarCliente();
            LancarProduto(idDoProduto);
            AvancarNaCondicional();
            AvancarNaCondicional();
            FecharTelaDeCondicionalComEsc();
            FecharTelaDeCondicionalComEsc();
            FecharTelaDeCondicionalComEsc();
            ClicarBotaoName(CondicionalModel.ElementoNameDoSim);
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
