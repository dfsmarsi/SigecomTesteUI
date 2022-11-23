using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste
{
    public class CadastroDeProdutoBaseTeste: BaseTestes
    {
        public void RetornarCadastroDeProduto(Dictionary<string, string> dadosDeProduto,
            out CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            var resolveCadastroDeProdutoPage =
                _lifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeProdutoPage>>();
            cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService, dadosDeProduto);
        }

        public void AbrirTelaDeProdutoParaTeste(CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            cadastroDeProdutoPage.ClicarNaOpcaoDoMenu();
            cadastroDeProdutoPage.ClicarNaOpcaoDoSubMenu();
            cadastroDeProdutoPage.ClicarNoBotaoNovo();
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
            cadastroDeProdutoPage.ClicarNaOpcaoDoPesquisar();
            var resolvePesquisaDeProdutoPage = _lifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>();
            var pesquisaDeProdutoPage = resolvePesquisaDeProdutoPage(DriverService);
            pesquisaDeProdutoPage.PesquisarProduto(dadosDeProduto["Nome"]);
            var possuiProduto = pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(dadosDeProduto["Nome"]);
            Assert.True(possuiProduto);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
            cadastroDeProdutoPage.FecharJanelaCadastroDeProdutoComEsc();
        }
    }
}
