using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos
{
    public class CadastroDeProdutoTeste : BaseTestes
    {
        public CadastroDeProdutoPage AbrirTelaDeProduto(Dictionary<string, string> dadosDeProduto)
        {
            var resolveCadastroDeProdutoPage =
                _lifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeProdutoPage>>();
            var cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService, dadosDeProduto);

            cadastroDeProdutoPage.ClicarNaOpcaoDoMenu();
            cadastroDeProdutoPage.ClicarNaOpcaoDoSubMenu();
            cadastroDeProdutoPage.ClicarNoBotaoNovo();
            return cadastroDeProdutoPage;
        }

        public void AtribuirDadosDoProdutoComImpostos(CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            cadastroDeProdutoPage.PreencherCamposDoProduto();
            cadastroDeProdutoPage.VerificarSePrecoDeVendaFoiCalculado();
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaImpostos);
            cadastroDeProdutoPage.PreencherCamposDeImpostos();
        }

        public void RealizarFluxoDePesquisaDoProduto(CadastroDeProdutoPage cadastroDeProdutoPage, Dictionary<string, string> dadosDeProdutoBalanca)
        {
            cadastroDeProdutoPage.ClicarNaOpcaoDoPesquisar();
            var resolvePesquisaDeProdutoPage = _lifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>();
            var pesquisaDeProdutoPage = resolvePesquisaDeProdutoPage(DriverService);
            pesquisaDeProdutoPage.PesquisarProduto(dadosDeProdutoBalanca["Nome"]);
            var possuiProduto = pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(dadosDeProdutoBalanca["Nome"]);
            Assert.True(possuiProduto);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
            cadastroDeProdutoPage.FecharJanelaCadastroDeProdutoComEsc();
        }
        [Test(Description = "Cadastro de Produto Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Douglas")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Produto")]
        public void CadastrarProdutoSomenteCamposObrigatorios()
        {
            var dadosDeProduto = new Dictionary<string, string>
            {
                {"Nome","PRODUTO"},
                {"Unidade", "UN"},
                {"CodigoInterno","int"},
                {"Categoria","PRODUTO"},
                {"Custo","5,00"},
                {"Markup","100,00"},
                {"PrecoVenda","10,00"},
                {"Referencia","ref"},
                {"NCM","22030000"}
            };
            // Arange
            var cadastroDeProdutoPage = AbrirTelaDeProduto(dadosDeProduto);

            // Act
            AtribuirDadosDoProdutoComImpostos(cadastroDeProdutoPage);
            cadastroDeProdutoPage.Gravar();

            // Assert
            RealizarFluxoDePesquisaDoProduto(cadastroDeProdutoPage, dadosDeProduto);
        }

        [Test(Description = "Cadastro de Produto de Balanca Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Produto")]
        public void CadastrarProdutoDeBalancaSomenteCamposObrigatorios()
        {
            var dadosDeProdutoBalanca = new Dictionary<string, string>
            {
                {"Nome","PRODUTO BALANCA"},
                {"Unidade", "UN"},
                {"CodigoInterno","int"},
                {"Categoria","BALANCA"},
                {"Custo","5,00"},
                {"Markup","100,00"},
                {"PrecoVenda","10,00"},
                {"Referencia","ref"},
                {"NCM","22030000"},
                {"Balanca","000003"}
            };
            // Arange
            var cadastroDeProdutoPage = AbrirTelaDeProduto(dadosDeProdutoBalanca);

            // Act
            AtribuirDadosDoProdutoComImpostos(cadastroDeProdutoPage);
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaBalanca);
            cadastroDeProdutoPage.PreencherCamposDaBalanca();
            cadastroDeProdutoPage.Gravar();

            // Assert
            RealizarFluxoDePesquisaDoProduto(cadastroDeProdutoPage, dadosDeProdutoBalanca);
        }
    }
}
