using System.Collections.Generic;
using NUnit.Allure.Attributes;
using NUnit.Framework;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos
{
    public class CadastroDeProdutoTeste : BaseTestes
    {
        private readonly CadastroDeProdutoPage _cadastroDeProdutoPage;
        private readonly Dictionary<string, string> _dadosProduto = new Dictionary<string, string>
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

        public CadastroDeProdutoTeste() => 
            _cadastroDeProdutoPage = new CadastroDeProdutoPage(DriverService, _dadosProduto);

        [Test(Description = "Cadastro de Produto Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Douglas")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Cliente")]
        public void CadastrarProdutoSomenteCamposObrigatorios()
        {
            // Arange
            _cadastroDeProdutoPage.ClicarNaOpcaoDoMenu();
            _cadastroDeProdutoPage.ClicarNaOpcaoDoSubMenu();
            _cadastroDeProdutoPage.ClicarNoBotaoNovo();

            // Act
            _cadastroDeProdutoPage.PreencherCamposDoProduto();
            _cadastroDeProdutoPage.VerificarSePrecoDeVendaFoiCalculado();
            // mudar para aba impostos
            _cadastroDeProdutoPage.AcessarAbaImpostos();
            // preencher impostos
            _cadastroDeProdutoPage.PreencherCamposDeImpostos();
            _cadastroDeProdutoPage.Gravar();

            // Assert
            // abrir tela de pesquisa
            // pesquisar produto
            // assert item da grid == PRODUTO
            // fechar tela de pesquisa
            // fechar tela de cadastro         
            _cadastroDeProdutoPage.FecharJanelaCadastroDeProdutoComEsc();
        }
    }
}
