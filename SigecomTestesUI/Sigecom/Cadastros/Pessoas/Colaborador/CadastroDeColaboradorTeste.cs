using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador
{
    public class CadastroDeColaboradorTeste : BaseTestes
    {
        private readonly CadastroDeColaboradorPage _cadastroColaboradorPage;
        private readonly PesquisaDePessoaPage _pesquisaPessoaPage;

        private readonly Dictionary<string, string> _dados = new Dictionary<string, string>() {
            {"Nome","RONY RUSTICO"},
            {"Cpf","28061149001"},
            {"Cep","15700082"},
            {"Numero","333"}
        };

        public CadastroDeColaboradorTeste()
        {
            _cadastroColaboradorPage = new CadastroDeColaboradorPage(DriverService, _dados);
            _pesquisaPessoaPage = new PesquisaDePessoaPage(DriverService);
        }

        [Test(Description = "Cadastro de Colaborador somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("3")]
        [AllureTms("3")]
        [AllureOwner("Douglas")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Colaborador")]
        public void CadastrarColaboradorSomenteCamposObrigatorios()
        {
            // Arange
            _cadastroColaboradorPage.ClicarNaOpcaoDoMenu();
            _cadastroColaboradorPage.ClicarNaOpcaoDoSubMenu();
            _cadastroColaboradorPage.ClicarBotaoNovo();
            _cadastroColaboradorPage.VerificarTipoPessoa();

            // Act
            _cadastroColaboradorPage.PreencherCampos();
            _cadastroColaboradorPage.GravarCadastro();

            // Assert
            _cadastroColaboradorPage.ClicarBotaoPesquisar();
            _pesquisaPessoaPage.PesquisarPessoa("colaborador", _dados["Nome"]);
            var existeClienteNaPesquisa = _pesquisaPessoaPage.VerificarSeExistePessoaNaGrid(_dados["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            _pesquisaPessoaPage.FecharJanelaComEsc("colaborador");
            _cadastroColaboradorPage.FecharJanelaCadastroColaboradorComEsc();
        }
    }
}
