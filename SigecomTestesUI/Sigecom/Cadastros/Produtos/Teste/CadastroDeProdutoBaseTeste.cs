using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using System;
using System.Collections.Generic;
using SigecomTestesUI.ControleDeInjecao;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste
{
    public class CadastroDeProdutoBaseTeste: BaseTestes
    {
        public void RetornarCadastroDeProduto(Dictionary<string, string> dadosDeProduto,
            out CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeProdutoPage =
                beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeProdutoPage>>();
            cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService, dadosDeProduto);
        }

        public void AdicionarUmNovoProdutoNaTelaDeCadastroDeProduto(CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            AbrirTelaDeCadastroDoProduto(cadastroDeProdutoPage);
            cadastroDeProdutoPage.ClicarNoBotaoNovo();
        }

        private static void PesquisarUmProdutoNaTelaDeCadastroDeProduto(CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            AbrirTelaDeCadastroDoProduto(cadastroDeProdutoPage);
            cadastroDeProdutoPage.ClicarNoAtalhoDePesquisar();
        }

        private static void AbrirTelaDeCadastroDoProduto(CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            cadastroDeProdutoPage.ClicarNaOpcaoDoMenu();
            cadastroDeProdutoPage.ClicarNaOpcaoDoSubMenu();
        }

        public void AtribuirDadosDoProdutoComImpostos(CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            cadastroDeProdutoPage.PreencherCamposDoProduto();
            cadastroDeProdutoPage.VerificarSePrecoDeVendaFoiCalculado();
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaImpostos);
            cadastroDeProdutoPage.PreencherCamposDeImpostos();
        }

        public void RealizarFluxoDePesquisaDoProduto(CadastroDeProdutoPage cadastroDeProdutoPage, Dictionary<string, string> dadosDeProduto)
        {
            PesquisarUmProdutoNaTelaDeCadastroDeProduto(cadastroDeProdutoPage);
            RetornarPesquisaDeProduto(out var pesquisaDeProdutoPage);
            pesquisaDeProdutoPage.PesquisarProduto(dadosDeProduto["Nome"]);
            var possuiProduto = pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(dadosDeProduto["NomeFinal"]);
            Assert.True(possuiProduto);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
            cadastroDeProdutoPage.FecharJanelaCadastroDeProdutoComEsc();
        }

        public void RetornarPesquisaDeProduto(out PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>();
            pesquisaDeProdutoPage = resolvePesquisaDeProdutoPage(DriverService);
        }
    }
}
