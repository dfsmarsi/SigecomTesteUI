using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste
{
    public class CadastroDeProdutoGradeTeste: CadastroDeProdutoBaseTeste
    {
        [Test(Description = "Cadastro de Produto de Grade Somente Campos Obrigatorios")]
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
            AbrirTelaDeProdutoParaTeste(cadastroDeProdutoPage);

            // Act
            AtribuirDadosDoProdutoComImpostos(cadastroDeProdutoPage);
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaGrade);
            cadastroDeProdutoPage.PreencherCamposDaGrade();
            cadastroDeProdutoPage.Gravar();

            // Assert
            RealizarFluxoDePesquisaDoProduto(cadastroDeProdutoPage, dadosDeProdutoGrade);
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
                {"Cor", "Preto"}
            };
    }
}
