using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.Teste
{
    public class CadastroDeColaboradorFisicoSimplesTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDeColaborador = new Dictionary<string, string>
        {
            {"Nome","RONY RUSTICO SIMPLES"},
            {"Cpf","28061149001"},
            {"Cep","15700082"},
            {"Numero","333"}
        };

        [Test(Description = "Cadastro de Colaborador fisico somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("3")]
        [AllureTms("3")]
        [AllureOwner("Douglas")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Colaborador")]
        public void CadastrarColaboradorFisicoSomenteCamposObrigatorios()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeColaboradorPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeColaboradorFisicoPage>>();
            var cadastroDeColaboradorPage = resolveCadastroDeColaboradorPage(DriverService, _dadosDeColaborador);
            // Arange
            cadastroDeColaboradorPage.AcessarTelaDeCadastroDeColaborador();

            // Act
            cadastroDeColaboradorPage.PreencherCamposSimples();
            cadastroDeColaboradorPage.GravarCadastro();

            // Assert
            cadastroDeColaboradorPage.PesquisarColaboradorGravado(beginLifetimeScope);
        }
    }
}
