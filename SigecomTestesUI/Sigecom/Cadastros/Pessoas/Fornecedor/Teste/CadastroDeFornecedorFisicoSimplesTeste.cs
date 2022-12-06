using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.Teste
{
    public class CadastroDeFornecedorFisicoSimplesTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDeFornecedor = new Dictionary<string, string>
        {
            {"Nome","FORNECEDOR SIMPLES"},
            {"Cpf","31055577092"},
            { "Cep","15700082"},
            { "Numero","222"}
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
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeFornecedorFisicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeFornecedorFisicoPage>>();
            var cadastroDeFornecedorFisicoPage = resolveCadastroDeFornecedorFisicoPage(DriverService, _dadosDeFornecedor);
            // Arrange
            cadastroDeFornecedorFisicoPage.AcessarTelaDeCadastroDeFornecedor();
            
            // Act
            cadastroDeFornecedorFisicoPage.PreencherCamposSimples();
            cadastroDeFornecedorFisicoPage.GravarCadastro();
            
            // Assert
            cadastroDeFornecedorFisicoPage.PesquisarFornecedorGravado(beginLifetimeScope);
        }
    }
}
