using System;
using Autofac;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Base.Model;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Base
{
    public class VendasBasePage:PageObjectModel, IVendasBasePage
    {
        public VendasBasePage(DriverService driver) : base(driver)
        {
        }

        public string LancarProdutoPadraoNaVenda(string nomeDaTela)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var pesquisaDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>()(DriverService);
            if (!pesquisaDeProdutoPage.PesquisarComF9UmProdutoNaTelaDeVenda(beginLifetimeScope, nomeDaTela)) return string.Empty;

            var idDoProduto = DriverService.PegarValorDaColunaDaGrid("Código");
            pesquisaDeProdutoPage.FecharJanelaComEsc();
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(VendasBaseModel.ElementoPesquisaDeProduto, idDoProduto, Keys.Enter);
            return idDoProduto;
        }

        public void LancarProdutosNaVenda(string nomeDaTela)
        {
            var idDoProduto = LancarProdutoPadraoNaVenda(nomeDaTela);
            LancarProduto(VendasBaseModel.PesquisarItem);
            LancarProduto(VendasBaseModel.PesquisarItemReferencia);
            LancarProduto(VendasBaseModel.PesquisarItemCodInterno);
            LancarProduto($"1*{idDoProduto}");
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(VendasBaseModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        public void AbrirOAtalhoParaSelecionarCliente()
        {
            ClicarBotaoName(VendasBaseModel.BotaoAtalhos);
            ClicarBotaoName(VendasBaseModel.AtalhoDeEditarCliente);
            SelecionarCliente();
        }

        private void SelecionarCliente()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>()(DriverService).PesquisarPessoaComConfirmar("cliente", "CLIENTE TESTE PESQUISA");
        }
    }
}
