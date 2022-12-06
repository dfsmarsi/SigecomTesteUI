using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.Teste
{
    public class CadastroDeColaboradorJuridicoCompletoTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDoCliente = new Dictionary<string, string>
        {
            {"Nome", "EMPRESA COLABORADOR TESTE COMPLETO"},
            {"Cnpj", "28406678000198"},
            {"Ie","248005050206"},
            {"Suframa","12345678"},
            {"NomeFantasia","Teste"},
            {"Complemento","Centro"},
            {"Cep", "15700082"},
            {"Numero", "623"},
            {"Observacao","Teste"},
            {"ContatoPrimario","(11) 96405-6467"},
            {"ObservacaoContatoPrimario","Teste"},
            {"ContatoSecundario","teste@sistemasbr.net"},
            {"ObservacaoContatoSecundario","Teste"},
            {"AvisoDeVenda", "Aviso teste"}
        };

        [Test(Description = "Cadastro de colaborador jurídico completo")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Colaborador")]
        public void CadastrarClienteJuridicoCompleto()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeColaboradorJuridicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeColaboradorJuridicoPage>>();
            var cadastroDeColaboradorJuridicoPage = resolveCadastroDeColaboradorJuridicoPage(DriverService, _dadosDoCliente);
            cadastroDeColaboradorJuridicoPage.AcessarTelaDeCadastroDeColaborador();

            // Act
            cadastroDeColaboradorJuridicoPage.PreencherCamposCompleto();
            cadastroDeColaboradorJuridicoPage.GravarCadastro();

            // Assert
            cadastroDeColaboradorJuridicoPage.PesquisarColaboradorGravado(beginLifetimeScope);
        }
    }
}
