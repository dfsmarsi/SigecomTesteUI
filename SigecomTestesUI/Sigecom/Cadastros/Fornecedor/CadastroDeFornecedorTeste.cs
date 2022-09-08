using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.PesquisaPessoa;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Fornecedor
{
    public class CadastroDeFornecedorTeste : BaseTestes
    {
        private readonly CadastroDeFornecedorPage _cadastroFornecedorPage;
        private readonly PesquisaDePessoaPage _pesquisaPessoaPage;

        private Dictionary<string, string> _dados = new Dictionary<string, string>() {
            {"Nome","FORNECEDOR"},
            {"Cpf","31055577092"},
            { "Cep","15700082"},
            { "Numero","222"},
        };

        public CadastroDeFornecedorTeste()
        {
            _cadastroFornecedorPage = new CadastroDeFornecedorPage(DriverService, _dados);
            _pesquisaPessoaPage = new PesquisaDePessoaPage(DriverService);
        }

        [Test]
        public void CadastrarFornecedorSomenteCamposObrigatorios()
        {
            // Arrange
            _cadastroFornecedorPage.AbrirCadastroFornecedor();
            _cadastroFornecedorPage.ClicarBotaoNovo();
            _cadastroFornecedorPage.VerificarTipoPessoa();
            
            // Act
            _cadastroFornecedorPage.PreencherCampos();
            _cadastroFornecedorPage.GravarCadastro();
            
            // Assert
            _cadastroFornecedorPage.ClicarBotaoPesquisar();
            _pesquisaPessoaPage.PesquisarPessoa("fornecedor", _dados["Nome"]);
            var existeClienteNaPesquisa = _pesquisaPessoaPage.VerificarSeExistePessoaNaGrid(_dados["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            _pesquisaPessoaPage.FecharJanelaComEsc("fornecedor");
            _cadastroFornecedorPage.FecharJanelaCadastroFornecedorComEsc();
        }
    }
}
