﻿using System;
using System.Collections.Generic;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Page;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Teste
{
    public class CadastroDeClienteJuridicoSimplesTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDoCliente = new Dictionary<string, string>
        {
            {"Nome","EMPRESA CLIENTE TESTE SIMPLES"},
            {"Cep","15700082"},
            {"Numero","123"}
        };

        [Test(Description = "Cadastro de cliente jurídico somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Cliente")]
        public void CadastrarClienteJuridicoSomenteCamposObrigatorios()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeClienteJuridicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeClienteJuridicoPage>>();
            var cadastroDeClienteJuridicoPage = resolveCadastroDeClienteJuridicoPage(DriverService, _dadosDoCliente);
            cadastroDeClienteJuridicoPage.AcessarTelaDeCadastroDeCliente();

            // Act
            cadastroDeClienteJuridicoPage.PreencherCamposSimples();
            cadastroDeClienteJuridicoPage.GravarCadastro();

            // Assert
            cadastroDeClienteJuridicoPage.PesquisarClienteGravado(beginLifetimeScope);
        }
    }
}
