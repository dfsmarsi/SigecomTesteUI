using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Teste
{
    public class PagarValorParcialComHaverDaContaAPagarTeste:BaseTestes
    {
        [Test(Description = "Pagar valor Parcial com haver")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("PagarValorParcialComHaver")]
        [AllureSubSuite("ContaAPagar")]
        public void PagarValorParcialComHaverNaContaAPagar()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var pagarValorParcialComHaverDaContaAPagarPage = beginLifetimeScope.Resolve<Func<DriverService, PagarValorParcialComHaverDaContaAPagarPage>>()(DriverService);
            pagarValorParcialComHaverDaContaAPagarPage.RealizarFluxoDePagarValorParcialComHaverNaContaAPagar();
        }
    }
}
