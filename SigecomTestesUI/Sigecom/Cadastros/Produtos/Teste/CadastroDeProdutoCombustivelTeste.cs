using System;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using System.Collections.Generic;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste
{
    public class CadastroDeProdutoCombustivelTeste : BaseTestes
    {
        public void RetornarCadastroDeProduto(Dictionary<string, string> dadosDeProduto,
            out CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeProdutoPage =
                beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeProdutoPage>>();
            cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService, dadosDeProduto);
        }

        [Test(Description = "Cadastro de Produto de Combustivel Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Produto")]
        public void CadastrarProdutoDeCombustivelSomenteCamposObrigatorios()
        {
            // Arange
            var dadosDeProdutoDeCombustivel = AdicionandoInformacoesNecessariasParaOTeste();
            RetornarCadastroDeProduto(dadosDeProdutoDeCombustivel, out var cadastroDeProdutoPage);
            cadastroDeProdutoPage.AdicionarUmNovoProdutoNaTelaDeCadastroDeProduto(cadastroDeProdutoPage);

            // Act
            cadastroDeProdutoPage.PreencherCamposDoProduto(TipoDeProduto.Combustivel);
            cadastroDeProdutoPage.VerificarSePrecoDeVendaFoiCalculado();
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaImpostos);
            cadastroDeProdutoPage.PreencherCamposDeImpostos();
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaCombustivel);
            cadastroDeProdutoPage.PreencherCamposDaAba(TipoDeProduto.Combustivel);
            cadastroDeProdutoPage.Gravar();

            // Assert
            cadastroDeProdutoPage.RealizarFluxoDePesquisaDoProduto(cadastroDeProdutoPage, TipoDeProduto.Combustivel);
        }

        private static Dictionary<string, string> AdicionandoInformacoesNecessariasParaOTeste() =>
            new Dictionary<string, string>
            {
                {"Nome","PRODUTO COMBUSTIVEL"},
                {"Unidade", "UN"},
                {"CodigoInterno","int"},
                {"Categoria","COMBUSTIVEL"},
                {"Custo","5,00"},
                {"Markup","100,00"},
                {"PrecoVenda","10,00"},
                {"Referencia","ref"},
                {"NCM","22030000"},
                {"NomeFinal","PRODUTO COMBUSTIVEL"}
            };
    }
}
