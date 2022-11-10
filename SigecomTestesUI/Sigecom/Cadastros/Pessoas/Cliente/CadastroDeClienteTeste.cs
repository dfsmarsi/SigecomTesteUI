using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Pesquisa.PesquisaPessoa;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente
{
    public class CadastroDeClienteTeste : BaseTestes
    {
        private CadastroDeClientePage _cadastroClientePage;
        private PesquisaDePessoaPage _pesquisaPessoaPage;

        private readonly Dictionary<string, string> _dados = new Dictionary<string, string>
        {
            {"Nome","JOAO PENCA"},
            {"Cpf","43671566051"},
            {"Cep","15700082"},
            {"Numero","123"}
        };

        [Test(Description = "Cadastro de cliente somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Douglas")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Cliente")]
        public void CadastrarClienteSomenteCamposObrigatorios()
        {
            _cadastroClientePage = new CadastroDeClientePage(DriverService, _dados);
            // Arange
            _cadastroClientePage.ClicarNaOpcaoDoMenu();
            _cadastroClientePage.ClicarNaOpcaoDoSubMenu();
            _cadastroClientePage.ClicarBotaoNovo();
            _cadastroClientePage.VerificarTipoPessoa();

            // Act
            _cadastroClientePage.PreencherCampos();
            _cadastroClientePage.GravarCadastro();

            // Assert
            _cadastroClientePage.ClicarBotaoPesquisar();
            _pesquisaPessoaPage = new PesquisaDePessoaPage(DriverService);
            _pesquisaPessoaPage.PesquisarPessoa("cliente", _dados["Nome"]);
            var existeClienteNaPesquisa = _pesquisaPessoaPage.VerificarSeExistePessoaNaGrid(_dados["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            _pesquisaPessoaPage.FecharJanelaComEsc("cliente");
            _cadastroClientePage.FecharJanelaComEsc();
        }
    }
}
