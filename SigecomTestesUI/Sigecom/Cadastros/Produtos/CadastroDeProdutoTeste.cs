using NUnit.Allure.Attributes;
using NUnit.Framework;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos
{
    public class CadastroDeProdutoTeste : BaseTestes
    {
        private CadastroDeProdutoPage _cadastroDeProdutoPage;

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
            _cadastroDeProdutoPage = new CadastroDeProdutoPage(DriverService);
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
