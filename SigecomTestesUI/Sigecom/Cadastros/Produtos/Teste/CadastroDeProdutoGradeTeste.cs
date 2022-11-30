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
    public class CadastroDeProdutoGradeTeste: BaseTestes
    {
        public void RetornarCadastroDeProduto(Dictionary<string, string> dadosDeProduto,
            out CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeProdutoPage =
                beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeProdutoPage>>();
            cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService, dadosDeProduto);
        }

        [Test(Description = "Cadastro de produto de grade possuindo somente campos obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Produto")]
        public void CadastrarProdutoDeGradeSomenteCamposObrigatorios()
        {
            var dadosDeProdutoGrade = AdicionandoInformacoesNecessariasParaOTeste();
            // Arange
            RetornarCadastroDeProduto(dadosDeProdutoGrade, out var cadastroDeProdutoPage);
            cadastroDeProdutoPage.AdicionarUmNovoProdutoNaTelaDeCadastroDeProduto(cadastroDeProdutoPage);

            // Act
            cadastroDeProdutoPage.PreencherCamposDoProduto(TipoDeProduto.Grade);
            cadastroDeProdutoPage.VerificarSePrecoDeVendaFoiCalculado();
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaImpostos);
            cadastroDeProdutoPage.PreencherCamposDeImpostos();
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaGrade);
            cadastroDeProdutoPage.PreencherCamposDaAba(TipoDeProduto.Grade);
            cadastroDeProdutoPage.Gravar();

            // Assert
            cadastroDeProdutoPage.RealizarFluxoDePesquisaDoProduto(cadastroDeProdutoPage, TipoDeProduto.Grade);
        }

        private static Dictionary<string, string> AdicionandoInformacoesNecessariasParaOTeste() =>
            new Dictionary<string, string>
            {
                {"Nome", "PRODUTO GRADE"},
                {"Unidade", "UN"},
                {"CodigoInterno", "int"},
                {"Categoria", "GRADE"},
                {"Custo", "5,00"},
                {"Markup", "100,00"},
                {"PrecoVenda", "10,00"},
                {"Referencia", "ref"},
                {"NCM", "22030000"},
                {"Código de barras", "0000010"},
                {"Tamanho", "G"},
                {"Cor", "PRETO"},
                {"NomeFinal", "PRODUTO GRADE G PRETO"}
            };
    }
}
