using Autofac;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Model;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Model;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Page
{
    public class ComprarTodosNaConsultaDeCondicionalPage: PageObjectModel
    {
        public ComprarTodosNaConsultaDeCondicionalPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
    AcessarOpcaoMenu(ConsultaDeCondicionalModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDeCondicionalModel.BotaoSubMenu);

        public void RealizarFluxoDeCompraTodosNaConsultaDeCondicional()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            var idDoProduto = CriarProdutoTeste();
            RealizarOFluxoDeGerarCondicionalNaConsulta(idDoProduto);
            EsperarAcaoEmSegundos(1);
            RealizarOCompraTodosNaConsulta();
            FecharTelaDeCondicionalComEsc();
        }

        private void RealizarOFluxoDeGerarCondicionalNaConsulta(string idDoProduto)
        {
            ClicarBotaoName(ConsultaDeCondicionalModel.BotaoDaNovaCondicional);
            ClicarBotaoName(CondicionalModel.BotaoAtalhosCondicional);
            ClicarBotaoName(CondicionalModel.AtalhoDeEditarClienteDaCondicional);
            SelecionarCliente();
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CondicionalModel.ElementoPesquisaDeProduto,
                idDoProduto, Keys.Enter);
            DriverService.EditarItensNaGridComDuploClickComTab(CondicionalModel.CampoDaGridDeQuantidadeDoProduto,
                LancarItensNaCondicionalModel.QuantidadeDeProduto);
            AvancarNaCondicional();
            AvancarNaCondicional();
            DriverService.RealizarSelecaoDaAcao(CondicionalModel.AcoesDaCondicional, 2);
        }

        private string CriarProdutoTeste()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var pesquisaDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>()(DriverService);
            return pesquisaDeProdutoPage.PesquisarComF9UmProdutoNaTelaDeVenda(beginLifetimeScope, CondicionalModel.ElementoTelaDeCondicional)
                ? DriverService.PegarValorDaColunaDaGrid("Código")
                : pesquisaDeProdutoPage.CriarNovoProduto(beginLifetimeScope);
        }

        private void RealizarOCompraTodosNaConsulta()
        {
            ClicarBotaoName(ConsultaDeCondicionalModel.BotaoDeComprarTodosCondicional);
            DriverService.RealizarSelecaoDaFormaDePagamento(CondicionalModel.GridDeFormaDePagamento, 1);
        }

        private void SelecionarCliente()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>()(DriverService).PesquisarPessoaComConfirmar("cliente", "CLIENTE TESTE PESQUISA");
        }

        private void AvancarNaCondicional()
            => ClicarBotaoName(CondicionalModel.ElementoNameDoAvancar);

        private void FecharTelaDeCondicionalComEsc() =>
            DriverService.FecharJanelaComEsc(ConsultaDeCondicionalModel.ElementoTelaDeCondicional);
    }
}
