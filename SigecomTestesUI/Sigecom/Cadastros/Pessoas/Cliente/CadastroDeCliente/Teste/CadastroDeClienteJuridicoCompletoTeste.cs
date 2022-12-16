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
    public class CadastroDeClienteJuridicoCompletoTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDoCliente = new Dictionary<string, string>
        {
            {"Nome","VENTURINI - FLORENCIO INDUSTRIA E COM DE BEBIDAS LTDA"},
            {"Cnpj","53765640000159"},
            {"NomeFantasia","REFRIGERANTES SABORAKI"},
            {"Cep","15708-030"},
            {"Endereco", "RUA SILVIO ALVES BALBINO"},
            {"Numero","251"},
            {"Bairro","PARQUE INDUSTRIAL II"},
            {"ContatoPrimario","(11) 96405-6467"},
            {"ContatoSecundario","teste@sistemasbr.net"}
        };

        [Test(Description = "Cadastro de cliente jurídico completo")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Cliente")]
        public void CadastrarClienteJuridicoCompleto()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeClienteJuridicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeClienteJuridicoPage>>();
            var cadastroDeClienteJuridicoPage = resolveCadastroDeClienteJuridicoPage(DriverService, _dadosDoCliente);
            cadastroDeClienteJuridicoPage.AcessarTelaDeCadastroDeCliente();

            // Act
            cadastroDeClienteJuridicoPage.PreencherCamposCompleto();
            cadastroDeClienteJuridicoPage.VerificarCamposDoCarregados();
            cadastroDeClienteJuridicoPage.GravarCadastro();

            // Assert
            cadastroDeClienteJuridicoPage.PesquisarClienteGravado(beginLifetimeScope);
        }
    }
}
