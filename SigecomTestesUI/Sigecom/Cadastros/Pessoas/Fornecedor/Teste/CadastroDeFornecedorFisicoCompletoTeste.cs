using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.Teste
{
    public class CadastroDeFornecedorFisicoCompletoTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDeFornecedor = new Dictionary<string, string>
        {
            {"Nome", "FORNECEDOR COMPLETO"},
            {"Cpf", "22177882052"},
            {"Rg", "331281855"},
            {"Apelido", "Teste"},
            {"DataNascimento", "04081668"},
            {"Complemento", "Centro"},
            {"Cep", "15700082"},
            {"Numero", "222"},
            {"Observacao", "Teste"},
            {"ContatoPrimario", "(11) 96405-6467"},
            {"ObservacaoContatoPrimario", "Teste"},
            {"ContatoSecundario", "teste@sistemasbr.net"},
            {"ObservacaoContatoSecundario", "Teste"}
        };

        [Test(Description = "Cadastro de fornecedor fisico completo")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("2")]
        [AllureTms("2")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Fornecedor")]
        public void CadastrarFornecedorFisicoCompleto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeFornecedorPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeFornecedorFisicoPage>>();
            var cadastroDeFornecedorPage = resolveCadastroDeFornecedorPage(DriverService, _dadosDeFornecedor);
            // Arrange
            cadastroDeFornecedorPage.AcessarTelaDeCadastroDeFornecedor();

            // Act
            cadastroDeFornecedorPage.PreencherCamposCompleto();
            cadastroDeFornecedorPage.GravarCadastro();

            // Assert
            cadastroDeFornecedorPage.PesquisarFornecedorGravado(beginLifetimeScope);
        }
    }
}
