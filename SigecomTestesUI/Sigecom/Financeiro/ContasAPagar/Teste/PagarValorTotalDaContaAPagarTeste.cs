using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Teste
{
    public class PagarValorTotalDaContaAPagarTeste:BaseTestes
    {
        [Test(Description = "Pagar valor total")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("PagarValorTotal")]
        [AllureSubSuite("ContaAPagar")]
        public void PagarValorTotalNaContaAPagar()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var PagarValorTotalDaContaAPagarPage = beginLifetimeScope.Resolve<Func<DriverService, PagarValorTotalDaContaAPagarPage>>()(DriverService);
            PagarValorTotalDaContaAPagarPage.RealizarFluxoDePagarValorTotalNaContaAPagar();
        }
    }
}
