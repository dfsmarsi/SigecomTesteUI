﻿using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.Teste
{
    public class CadastroDeClienteJuridicoCompletoTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDoCliente = new Dictionary<string, string>
        {
            {"Nome","EMPRESA TESTE COMPLETO"},
            {"Cnpj","77753844000138"},
            {"Ie","248005050206"},
            {"Suframa","12345678"},
            {"NomeFantasia","Teste"},
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
            cadastroDeClienteJuridicoPage.GravarCadastro();

            // Assert
            cadastroDeClienteJuridicoPage.PesquisarClienteGravado(beginLifetimeScope);
        }
    }
}
