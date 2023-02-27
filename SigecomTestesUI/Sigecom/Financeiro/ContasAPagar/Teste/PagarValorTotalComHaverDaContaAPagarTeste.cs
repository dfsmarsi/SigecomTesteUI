using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Teste
{
    public class PagarValorTotalComHaverDaContaAPagarTeste:BaseTestes
    {
        [Test(Description = "Pagar valor total com haver")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("PagarValorTotalComHaver")]
        [AllureSubSuite("ContaAPagar")]
        public void PagarValorTotalComHaverNaContaAPagar()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var pagarValorTotalComHaverDaContaAPagarPage = beginLifetimeScope.Resolve<Func<DriverService, PagarValorTotalComHaverDaContaAPagarPage>>()(DriverService);
            pagarValorTotalComHaverDaContaAPagarPage.RealizarFluxoDePagarValorTotalComHaverNaContaAPagar();
        }
    }
}
