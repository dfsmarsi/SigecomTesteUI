using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.Teste
{
    public class CadastroDeColaboradorJuridicoSimplesTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDoCliente = new Dictionary<string, string>
        {
            {"Nome","EMPRESA COLABORADOR TESTE SIMPLES"},
            {"Cnpj","39578222000121"},
            {"Cep","15700082"},
            {"Numero","623"}
        };

        [Test(Description = "Cadastro de colaborador jurídico somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Colaborador")]
        public void CadastrarClienteJuridicoSomenteCamposObrigatorios()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeColaboradorJuridicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeColaboradorJuridicoPage>>();
            var cadastroDeColaboradorJuridicoPage = resolveCadastroDeColaboradorJuridicoPage(DriverService, _dadosDoCliente);
            cadastroDeColaboradorJuridicoPage.AcessarTelaDeCadastroDeColaborador();

            // Act
            cadastroDeColaboradorJuridicoPage.PreencherCamposSimples();
            cadastroDeColaboradorJuridicoPage.GravarCadastro();

            // Assert
            cadastroDeColaboradorJuridicoPage.PesquisarColaboradorGravado(beginLifetimeScope);
        }
    }
}
