using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Teste
{
    public class LancarContaAvulsaDaContaAPagarTeste:BaseTestes
    {
        [Test(Description = "Lancar conta avulsa")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("LancarContaAvulsa")]
        [AllureSubSuite("ContaAPagar")]
        public void LancarContaAvulsaNaContaAPagar()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarContaAvulsaDaContaAPagarPage = beginLifetimeScope.Resolve<Func<DriverService, LancarContaAvulsaDaContaAPagarPage>>()(DriverService);
            lancarContaAvulsaDaContaAPagarPage.RealizarFluxoDeLancarContaAvulsaNaContaAPagar();
        }
    }
}
