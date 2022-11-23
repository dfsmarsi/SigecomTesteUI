using System.Collections.Generic;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste.Interfaces;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste
{
    public class CadastroDeProdutoNormalTeste : BaseTestes
    {
        private readonly ICadastroDeProdutoBaseTeste _cadastroDeProdutoBaseTeste;
        public CadastroDeProdutoNormalTeste(ICadastroDeProdutoBaseTeste cadastroDeProdutoBaseTeste) =>
            _cadastroDeProdutoBaseTeste = cadastroDeProdutoBaseTeste;

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
            var dadosDeProduto = AdicionandoInformacoesNecessariasParaOTeste();
            // Arange
            _cadastroDeProdutoBaseTeste.RetornarCadastroDeProduto(dadosDeProduto, out var cadastroDeProdutoPage);
            _cadastroDeProdutoBaseTeste.AbrirTelaDeProdutoParaTeste(cadastroDeProdutoPage);

            // Act
            _cadastroDeProdutoBaseTeste.AtribuirDadosDoProdutoComImpostos(cadastroDeProdutoPage);
            cadastroDeProdutoPage.Gravar();

            // Assert
            _cadastroDeProdutoBaseTeste.RealizarFluxoDePesquisaDoProduto(cadastroDeProdutoPage, dadosDeProduto);
        }

        private static Dictionary<string, string> AdicionandoInformacoesNecessariasParaOTeste() =>
            new Dictionary<string, string>
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
    }
}
