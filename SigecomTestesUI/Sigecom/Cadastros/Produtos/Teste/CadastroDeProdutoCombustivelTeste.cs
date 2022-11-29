using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste
{
    public class CadastroDeProdutoCombustivelTeste : CadastroDeProdutoBaseTeste
    {
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
            var dadosDeProdutoDeCombustivel = AdicionandoInformacoesNecessariasParaOTeste();
            // Arange
            RetornarCadastroDeProduto(dadosDeProdutoDeCombustivel, out var cadastroDeProdutoPage);
            AdicionarUmNovoProdutoNaTelaDeCadastroDeProduto(cadastroDeProdutoPage);

            // Act
            AtribuirDadosDoProdutoComImpostos(cadastroDeProdutoPage);
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaCombustivel);
            cadastroDeProdutoPage.PreencherCamposDeCombustivel();
            cadastroDeProdutoPage.Gravar();

            // Assert
            RealizarFluxoDePesquisaDoProduto(cadastroDeProdutoPage, dadosDeProdutoDeCombustivel);
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
