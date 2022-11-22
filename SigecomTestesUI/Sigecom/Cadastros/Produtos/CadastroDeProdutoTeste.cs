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
        private void RetornarCadastroDeProduto(Dictionary<string, string> dadosDeProduto,
            out CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            var resolveCadastroDeProdutoPage =
                _lifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeProdutoPage>>();
            cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService, dadosDeProduto);
        }

        public static void AbrirTelaDeProdutoParaTeste(CadastroDeProdutoPage cadastroDeProdutoPage)
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
            RetornarCadastroDeProduto(dadosDeProduto, out var cadastroDeProdutoPage);
            AbrirTelaDeProdutoParaTeste(cadastroDeProdutoPage);

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
            RetornarCadastroDeProduto(dadosDeProdutoBalanca, out var cadastroDeProdutoPage);
            AbrirTelaDeProdutoParaTeste(cadastroDeProdutoPage);

            // Act
            AtribuirDadosDoProdutoComImpostos(cadastroDeProdutoPage);
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaBalanca);
            cadastroDeProdutoPage.PreencherCamposDaBalanca();
            cadastroDeProdutoPage.Gravar();

            // Assert
            RealizarFluxoDePesquisaDoProduto(cadastroDeProdutoPage, dadosDeProdutoBalanca);
        }

        [Test(Description = "Cadastro de Produto de Balanca Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Produto")]
        public void CadastrarProdutoDeGradeSomenteCamposObrigatorios()
        {
            var dadosDeProdutoGrade = new Dictionary<string, string>
            {
                {"Nome","PRODUTO GRADE"},
                {"Unidade", "UN"},
                {"CodigoInterno","int"},
                {"Categoria","GRADE"},
                {"Custo","5,00"},
                {"Markup","100,00"},
                {"PrecoVenda","10,00"},
                {"Referencia","ref"},
                {"NCM","22030000"},
                {"Código de barras","0000010"},
                {"Tamanho","G"},
                {"Cor","Preto"}
            };
            // Arange
            RetornarCadastroDeProduto(dadosDeProdutoGrade, out var cadastroDeProdutoPage);
            AbrirTelaDeProdutoParaTeste(cadastroDeProdutoPage);

            // Act
            AtribuirDadosDoProdutoComImpostos(cadastroDeProdutoPage);
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaGrade);
            cadastroDeProdutoPage.PreencherCamposDaGrade();
            cadastroDeProdutoPage.Gravar();

            // Assert
            RealizarFluxoDePesquisaDoProduto(cadastroDeProdutoPage, dadosDeProdutoGrade);
        }
    }
}
