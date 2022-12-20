using System;
using System.Collections.Generic;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Page;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Teste
{
    public class CadastroDeClienteFisicoSimplesTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDoCliente = new Dictionary<string, string>
        {
            {"Nome","JOAO PENCA SIMPLES"},
            {"Cpf","25535468070"},
            {"Cep","15700082"},
            {"Numero","123"}
        };

        [Test(Description = "Cadastro de cliente físico somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Douglas")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Cliente")]
        public void CadastrarClienteFisicoSomenteCamposObrigatorios()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeClienteFisicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeClienteFisicoPage>>();
            var cadastroDeClienteFisicoPage = resolveCadastroDeClienteFisicoPage(DriverService, _dadosDoCliente);
            // Arange
            cadastroDeClienteFisicoPage.AcessarTelaDeCadastroDeCliente(true);

            // Act
            cadastroDeClienteFisicoPage.PreencherCamposSimples();
            cadastroDeClienteFisicoPage.GravarCadastro();

            // Assert
            cadastroDeClienteFisicoPage.PesquisarClienteGravado(beginLifetimeScope);
        }
    }
}
