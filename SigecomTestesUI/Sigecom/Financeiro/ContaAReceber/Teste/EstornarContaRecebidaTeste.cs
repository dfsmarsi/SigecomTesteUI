﻿using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Teste
{
    public class EstornarContaRecebidaTeste:BaseTestes
    {
        [Test(Description = "Estornar conta a receber")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("EstornarDaContaAReceber")]
        [AllureSubSuite("ContaAReceber")]
        public void EstornarContaRecebida()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var estornarDaContaAReceberPage = beginLifetimeScope.Resolve<Func<DriverService, EstornarContaRecebidaPage>>()(DriverService);
            estornarDaContaAReceberPage.RealizarFluxoDeEstornarContaRecebida();
        }
    }
}
