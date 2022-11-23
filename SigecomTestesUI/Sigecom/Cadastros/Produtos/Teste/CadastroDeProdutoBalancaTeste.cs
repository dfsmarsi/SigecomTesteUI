using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using System.Collections.Generic;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste.Interfaces;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste
{
    public class CadastroDeProdutoBalancaTeste
    {
        private readonly ICadastroDeProdutoBaseTeste _cadastroDeProdutoBaseTeste;
        public CadastroDeProdutoBalancaTeste(ICadastroDeProdutoBaseTeste cadastroDeProdutoBaseTeste) => 
            _cadastroDeProdutoBaseTeste = cadastroDeProdutoBaseTeste;

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
            var dadosDeProdutoBalanca = AdicionandoInformacoesNecessariasParaOTeste();
            // Arange
            _cadastroDeProdutoBaseTeste.RetornarCadastroDeProduto(dadosDeProdutoBalanca, out var cadastroDeProdutoPage);
            _cadastroDeProdutoBaseTeste.AbrirTelaDeProdutoParaTeste(cadastroDeProdutoPage);

            // Act
            _cadastroDeProdutoBaseTeste.AtribuirDadosDoProdutoComImpostos(cadastroDeProdutoPage);
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaBalanca);
            cadastroDeProdutoPage.PreencherCamposDaBalanca();
            cadastroDeProdutoPage.Gravar();

            // Assert
            _cadastroDeProdutoBaseTeste.RealizarFluxoDePesquisaDoProduto(cadastroDeProdutoPage, dadosDeProdutoBalanca);
        }

        private static Dictionary<string, string> AdicionandoInformacoesNecessariasParaOTeste() =>
            new Dictionary<string, string>
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
    }
}
