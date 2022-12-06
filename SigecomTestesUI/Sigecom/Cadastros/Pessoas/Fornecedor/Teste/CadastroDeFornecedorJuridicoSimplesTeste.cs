using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.Teste
{
    public class CadastroDeFornecedorJuridicoSimplesTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDeFornecedor = new Dictionary<string, string>
        {
            {"Nome","EMPRESA FORNECEDOR TESTE SIMPLES"},
            {"Cnpj","25841943000178"},
            {"Cep","15700082"},
            {"Numero","333"}
        };

        [Test(Description = "Cadastro de fornecedor júridico somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("3")]
        [AllureTms("3")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Fornecedor")]
        public void CadastrarFornecedorJuridicoSomenteCamposObrigatorios()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeFornecedorJuridicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeFornecedorJuridicoPage>>();
            var cadastroDeFornecedorJuridicoPage = resolveCadastroDeFornecedorJuridicoPage(DriverService, _dadosDeFornecedor);
            // Arange
            cadastroDeFornecedorJuridicoPage.AcessarTelaDeCadastroDeFornecedor();

            // Act
            cadastroDeFornecedorJuridicoPage.PreencherCamposSimples();
            cadastroDeFornecedorJuridicoPage.GravarCadastro();

            // Assert
            cadastroDeFornecedorJuridicoPage.PesquisarFornecedorGravado(beginLifetimeScope);
        }
    }
}
