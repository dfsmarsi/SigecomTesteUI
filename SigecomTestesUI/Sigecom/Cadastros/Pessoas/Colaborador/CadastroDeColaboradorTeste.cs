using System;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Pesquisa.PesquisaPessoa;
using System.Collections.Generic;
using Autofac;
using SigecomTestesUI.Services;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador
{
    public class CadastroDeColaboradorTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDeColaborador = new Dictionary<string, string>() {
            {"Nome","RONY RUSTICO"},
            {"Cpf","28061149001"},
            {"Cep","15700082"},
            {"Numero","333"}
        };

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
            var resolveCadastroDeColaboradorPage = _lifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeColaboradorPage>>();
            var cadastroDeColaboradorPage = resolveCadastroDeColaboradorPage(DriverService, _dadosDeColaborador);
            // Arange
            cadastroDeColaboradorPage.ClicarNaOpcaoDoMenu();
            cadastroDeColaboradorPage.ClicarNaOpcaoDoSubMenu();
            cadastroDeColaboradorPage.ClicarBotaoNovo();
            cadastroDeColaboradorPage.VerificarTipoPessoa();

            // Act
            cadastroDeColaboradorPage.PreencherCampos();
            cadastroDeColaboradorPage.GravarCadastro();

            // Assert
            cadastroDeColaboradorPage.ClicarBotaoPesquisar();
            var resolvePesquisaDePessoaPage = _lifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);
            pesquisaDePessoaPage.PesquisarPessoa("colaborador", _dadosDeColaborador["Nome"]);
            var existeClienteNaPesquisa = pesquisaDePessoaPage.VerificarSeExistePessoaNaGrid(_dadosDeColaborador["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            pesquisaDePessoaPage.FecharJanelaComEsc("colaborador");
            cadastroDeColaboradorPage.FecharJanelaCadastroColaboradorComEsc();
        }
    }
}
