using System.Collections.Generic;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Pesquisa.PesquisaProduto;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos
{
    public class CadastroDeProdutoTeste : BaseTestes
    {
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

        private CadastroDeProdutoPage _cadastroDeProdutoPage;
        private PesquisaDeProdutoPage _pesquisaDeProdutoPage; 

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
            _cadastroDeProdutoPage.ClicarNaOpcaoDoPesquisar();
            _pesquisaDeProdutoPage = new PesquisaDeProdutoPage(DriverService);
            _pesquisaDeProdutoPage.PesquisarProduto(_dadosProduto["Nome"]);
            var possuiProduto = _pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(_dadosProduto["Nome"]);
            Assert.True(possuiProduto);
            _pesquisaDeProdutoPage.FecharJanelaComEsc();
            _cadastroDeProdutoPage.FecharJanelaCadastroDeProdutoComEsc();     
        }
    }
}
