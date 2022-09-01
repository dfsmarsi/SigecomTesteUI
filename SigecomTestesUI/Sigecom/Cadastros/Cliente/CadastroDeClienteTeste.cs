using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.PesquisaPessoa;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Cliente
{
    public class CadastroDeClienteTeste : BaseTestes
    {
        private readonly CadastroDeClientePage _cadastroClientePage;
        private readonly PesquisaDePessoaPage _pesquisaPessoaPage;

        private Dictionary<string, string> _dados = new Dictionary<string, string>() {
            {"Nome","JOAO PENCA"},
            {"Cpf","43671566051"},
            {"Cep","15700082"},
            {"Numero","123"},
        };

        public CadastroDeClienteTeste()
        {
            _cadastroClientePage = new CadastroDeClientePage(DriverService, _dados);
            _pesquisaPessoaPage = new PesquisaDePessoaPage(DriverService);
        }

        //[Test]
        public void CadastrarClienteSomenteCamposObrigatorios()
        {
            // Arange
            _cadastroClientePage.AbrirCadastroCliente();
            _cadastroClientePage.ClicarBotaoNovo();
            _cadastroClientePage.VerificarTipoPessoa();

            //// Act
            _cadastroClientePage.PreencherCampos();
            _cadastroClientePage.GravarCadastro();

            // Assert
            _cadastroClientePage.ClicarBotaoPesquisar();
            _pesquisaPessoaPage.PesquisarPessoa("cliente", _dados["Nome"]);
            var existeClienteNaPesquisa = _pesquisaPessoaPage.VerificarSeExistePessoaNaGrid(_dados["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            _pesquisaPessoaPage.FecharJanelaComEsc("cliente");
            _cadastroClientePage.FecharJanelaComEsc();
        }
    }
}
