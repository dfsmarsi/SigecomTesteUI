using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.PesquisaPessoa;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Colaborador
{
    public class CadastroDeColaboradorTeste : BaseTestes
    {
        private readonly CadastroDeColaboradorPage _cadastroColaboradorPage;
        private readonly PesquisaDePessoaPage _pesquisaPessoaPage;

        private Dictionary<string, string> _dados = new Dictionary<string, string>() {
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

        [Test]
        public void CadastrarColaboradorSomenteCamposObrigatorios()
        {
            // Arange
            _cadastroColaboradorPage.AbrirCadastroColaborador();
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
