﻿using System;
using System.Collections.Generic;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Page;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Teste
{
    public class CadastroDeColaboradorFisicoCompletoTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDeColaborador = new Dictionary<string, string>
        {
            {"Nome", "RONY RUSTICO COMPLETO"},
            {"Cpf", "45941011008"},
            {"Rg", "331281855"},
            {"Apelido", "Teste"},
            {"DataNascimento", "04081668"},
            {"Complemento", "Centro"},
            {"Cep", "15700082"},
            {"Numero", "333"},
            {"Observacao", "Teste"},
            {"ContatoPrimario", "(11) 96405-6467"},
            {"ObservacaoContatoPrimario", "Teste"},
            {"ContatoSecundario", "teste@sistemasbr.net"},
            {"ObservacaoContatoSecundario", "Teste"},
            {"DataAdmissao", "01/01/1998"},
            {"EmailFuncionario", "teste@sistemasbr.net"},
            {"DiaPagamento", "07"},
            {"Salario", "800,00"},
            {"TelefoneFuncionario", "(11)96405-6467"},
            {"Cargo", "TESTER"}
        };

        [Test(Description = "Cadastro de colaborador físico completo")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("3")]
        [AllureTms("3")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Colaborador")]
        public void CadastrarColaboradorFisicoCompleto()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeColaboradorPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeColaboradorFisicoPage>>();
            var cadastroDeColaboradorPage = resolveCadastroDeColaboradorPage(DriverService, _dadosDeColaborador);
            cadastroDeColaboradorPage.AcessarTelaDeCadastroDeColaborador(true);

            // Act
            cadastroDeColaboradorPage.PreencherCamposCompleto();
            cadastroDeColaboradorPage.GravarCadastro();

            // Assert
            cadastroDeColaboradorPage.PesquisarColaboradorGravado(beginLifetimeScope);
        }
    }
}
