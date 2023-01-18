using System;
using System.Collections.Generic;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Page;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Teste
{
    public class CadastroDeFornecedorJuridicoCompletoTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDeFornecedor = new Dictionary<string, string>
        {
            {"Nome","PAMELA TABATA TUGERA DOS REIS 31130435814"},
            {"Cnpj","16716114000172"},
            {"NomeFantasia","MARIA BELLE"},
            {"Cep","08545-240"},
            {"Endereco", "RUA DUÍLIO DAINEZI"},
            {"Numero","224"},
            {"Bairro","JARDIM SÃO JOÃO"}
        };

        [Test(Description = "Cadastro de fornecedor júridico completo")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("3")]
        [AllureTms("3")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Fornecedor")]
        public void CadastrarFornecedorJuridicoCompleto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeFornecedorJuridicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeFornecedorJuridicoPage>>();
            var cadastroDeFornecedorJuridicoPage = resolveCadastroDeFornecedorJuridicoPage(DriverService, _dadosDeFornecedor);
            // Arange
            cadastroDeFornecedorJuridicoPage.AcessarTelaDeCadastroDeFornecedor();

            // Act
            cadastroDeFornecedorJuridicoPage.PreencherCamposCompleto();
            cadastroDeFornecedorJuridicoPage.VerificarCamposDoCarregados();
            cadastroDeFornecedorJuridicoPage.GravarCadastro();

            // Assert
            cadastroDeFornecedorJuridicoPage.PesquisarFornecedorGravado(beginLifetimeScope);
        }
    }
}
