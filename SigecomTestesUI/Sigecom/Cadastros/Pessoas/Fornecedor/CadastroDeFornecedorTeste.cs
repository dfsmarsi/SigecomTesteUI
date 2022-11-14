using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Pesquisa.PesquisaPessoa;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor
{
    public class CadastroDeFornecedorTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDeFornecedor = new Dictionary<string, string>
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
            var resolveCadastroDeFornecedorPage = _lifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeFornecedorPage>>();
            var cadastroDeFornecedorPage = resolveCadastroDeFornecedorPage(DriverService, _dadosDeFornecedor);
            // Arrange
            cadastroDeFornecedorPage.ClicarNaOpcaoDoMenu();
            cadastroDeFornecedorPage.ClicarNaOpcaoDoSubMenu();
            cadastroDeFornecedorPage.ClicarBotaoNovo();
            cadastroDeFornecedorPage.VerificarTipoPessoa();
            
            // Act
            cadastroDeFornecedorPage.PreencherCampos();
            cadastroDeFornecedorPage.GravarCadastro();
            
            // Assert
            cadastroDeFornecedorPage.ClicarBotaoPesquisar(); 
            var resolvePesquisaDePessoaPage = _lifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);
            pesquisaDePessoaPage.PesquisarPessoa("fornecedor", _dadosDeFornecedor["Nome"]);
            var existeClienteNaPesquisa = pesquisaDePessoaPage.VerificarSeExistePessoaNaGrid(_dadosDeFornecedor["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            pesquisaDePessoaPage.FecharJanelaComEsc("fornecedor");
            cadastroDeFornecedorPage.FecharJanelaCadastroFornecedorComEsc();
        }
    }
}
