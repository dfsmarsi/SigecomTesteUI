using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.Teste
{
    public class CadastroDeColaboradorJuridicoCompletoTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDoCliente = new Dictionary<string, string>
        {
            {"Nome", "FABIANO HENRIQUE DE MORAIS FONSECA 04184783090"},
            {"Cnpj", "39578222000121"},
            {"NomeFantasia","SALGADINHOS DA VERA."},
            {"Cep","92440-304"},
            {"Endereco", "QUADRA F QUATRO B"},
            {"Numero","23"},
            {"Bairro","GUAJUVIRAS"},
            {"Observacao",@"SITUAÇÃO: ATIVA
                            PORTE: MICRO EMPRESA
                            CAPITAL SOCIAL: R$ 1000.00
                            CNAE: 56.20-1-04 - FORNECIMENTO DE ALIMENTOS PREPARADOS PREPONDERANTEMENTE PARA CONSUMO DOMICILIAR
                            NATUREZA JURÍDICA: 213-5 - EMPRESÁRIO (INDIVIDUAL)"},
            {"DataAdmissao", "01/01/1998"},
            {"EmailFuncionario", "teste@sistemasbr.net"},
            {"DiaPagamento", "07"},
            {"Salario", "800,00"},
            {"TelefoneFuncionario", "(11)96405-6467"},
            {"Cargo", "TESTER"}
        };

        [Test(Description = "Cadastro de colaborador jurídico completo")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Colaborador")]
        public void CadastrarClienteJuridicoCompleto()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeColaboradorJuridicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeColaboradorJuridicoPage>>();
            var cadastroDeColaboradorJuridicoPage = resolveCadastroDeColaboradorJuridicoPage(DriverService, _dadosDoCliente);
            cadastroDeColaboradorJuridicoPage.AcessarTelaDeCadastroDeColaborador();

            // Act
            cadastroDeColaboradorJuridicoPage.PreencherCamposCompleto();
            cadastroDeColaboradorJuridicoPage.VerificarCamposDoCarregados();
            cadastroDeColaboradorJuridicoPage.GravarCadastro();

            // Assert
            cadastroDeColaboradorJuridicoPage.PesquisarColaboradorGravado(beginLifetimeScope);
        }
    }
}
