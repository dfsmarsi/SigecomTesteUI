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
    public class CadastroDeClienteFisicoCompletoTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDoCliente = new Dictionary<string, string>
        {
            {"Nome","JOAO PENCA COMPLETO"},
            {"Cpf","43671566051"},
            {"Rg","331281855"},
            {"Apelido","Teste"},
            {"DataNascimento","04081668"},
            {"Profissao","Tester"},
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

        [Test(Description = "Cadastro de cliente físico completo")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Douglas")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Cliente")]
        public void CadastrarClienteFisicoCompleto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeClienteFisicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeClienteFisicoPage>>();
            var cadastroDeClienteFisicoPage = resolveCadastroDeClienteFisicoPage(DriverService, _dadosDoCliente);
            // Arange
            cadastroDeClienteFisicoPage.AcessarTelaDeCadastroDeCliente();

            // Act
            cadastroDeClienteFisicoPage.PreencherCamposCompleto();
            cadastroDeClienteFisicoPage.GravarCadastro();

            // Assert
            cadastroDeClienteFisicoPage.PesquisarClienteGravado(beginLifetimeScope);
        }
    }
}
