using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.Teste
{
    public class CadastroDeFornecedorJuridicoCompletoTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDeFornecedor = new Dictionary<string, string>
        {
            {"Nome","EMPRESA FORNECEDOR TESTE COMPLETO"},
            {"Cnpj","25850870000180"},
            {"Ie","248005050206"},
            {"Suframa","12345678"},
            {"NomeFantasia","Teste"},
            {"Complemento","Centro"},
            {"Cep", "15700082"},
            {"Numero", "315"},
            {"Observacao","Teste"},
            {"ContatoPrimario","(11) 96405-6467"},
            {"ObservacaoContatoPrimario","Teste"},
            {"ContatoSecundario","teste@sistemasbr.net"},
            {"ObservacaoContatoSecundario","Teste"},
            {"AvisoDeVenda", "Aviso teste"}
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
            cadastroDeFornecedorJuridicoPage.GravarCadastro();

            // Assert
            cadastroDeFornecedorJuridicoPage.PesquisarFornecedorGravado(beginLifetimeScope);
        }
    }
}
