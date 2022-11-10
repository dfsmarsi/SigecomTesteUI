using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Pesquisa.PesquisaPessoa;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor
{
    public class CadastroDeFornecedorTeste : BaseTestes
    {
        private CadastroDeFornecedorPage _cadastroFornecedorPage;
        private PesquisaDePessoaPage _pesquisaPessoaPage;

        private readonly Dictionary<string, string> _dados = new Dictionary<string, string>
        {
            {"Nome","FORNECEDOR"},
            {"Cpf","31055577092"},
            { "Cep","15700082"},
            { "Numero","222"},
        };

        [Test(Description = "Cadastro de fornecedor somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("2")]
        [AllureTms("2")]
        [AllureOwner("Douglas")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Fornecedor")]
        public void CadastrarFornecedorSomenteCamposObrigatorios()
        {
            _cadastroFornecedorPage = new CadastroDeFornecedorPage(DriverService, _dados);
            // Arrange
            _cadastroFornecedorPage.ClicarNaOpcaoDoMenu();
            _cadastroFornecedorPage.ClicarNaOpcaoDoSubMenu();
            _cadastroFornecedorPage.ClicarBotaoNovo();
            _cadastroFornecedorPage.VerificarTipoPessoa();
            
            // Act
            _cadastroFornecedorPage.PreencherCampos();
            _cadastroFornecedorPage.GravarCadastro();
            
            // Assert
            _cadastroFornecedorPage.ClicarBotaoPesquisar();
            _pesquisaPessoaPage = new PesquisaDePessoaPage(DriverService);
            _pesquisaPessoaPage.PesquisarPessoa("fornecedor", _dados["Nome"]);
            var existeClienteNaPesquisa = _pesquisaPessoaPage.VerificarSeExistePessoaNaGrid(_dados["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            _pesquisaPessoaPage.FecharJanelaComEsc("fornecedor");
            _cadastroFornecedorPage.FecharJanelaCadastroFornecedorComEsc();
        }
    }
}
