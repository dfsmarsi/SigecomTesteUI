using System;
using System.Collections.Generic;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.Teste
{
    public class CadastroDeClienteJuridicoCompletoTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDoCliente = new Dictionary<string, string>
        {
            {"Nome","EMPRESA TESTE COMPLETO"},
            {"Cnpf","77753844000138"},
            {"Ie","248005050206"},
            {"Suframa","5"},
            {"NomeFantasia","Teste"},
            {"Complemento","Centro"},
            {"Cep","15700082"},
            {"Numero","123"},
            {"Observacao","Teste"},
            {"ContatoPrimario","(11) 96405-6467"},
            {"ObservacaoContatoPrimario","Teste"},
            {"ContatoSecundario","teste@sistemasbr.net"},
            {"ObservacaoContatoSecundario","Teste"},
            {"AvisoDeVenda", "Aviso teste"}
        };

        [Test(Description = "Cadastro de cliente jurídico completo")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Cliente")]
        public void CadastrarClienteJuridicoCompleto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeClienteJuridicoPage>>();
            var cadastroDeClientePage = resolveCadastroDeProdutoPage(DriverService, _dadosDoCliente);
            // Arange
            cadastroDeClientePage.ClicarNaOpcaoDoMenu();
            cadastroDeClientePage.ClicarNaOpcaoDoSubMenu();
            cadastroDeClientePage.ClicarBotaoNovo();
            cadastroDeClientePage.VerificarTipoPessoa();

            // Act
            cadastroDeClientePage.PreencherCamposCompleto();
            cadastroDeClientePage.GravarCadastro();

            // Assert
            cadastroDeClientePage.ClicarBotaoPesquisar();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);
            pesquisaDePessoaPage.PesquisarPessoa("cliente", _dadosDoCliente["Nome"]);
            var existeClienteNaPesquisa = pesquisaDePessoaPage.VerificarSeExistePessoaNaGrid(_dadosDoCliente["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            pesquisaDePessoaPage.FecharJanelaComEsc("cliente");
            cadastroDeClientePage.FecharJanelaComEsc();
        }
    }
}
