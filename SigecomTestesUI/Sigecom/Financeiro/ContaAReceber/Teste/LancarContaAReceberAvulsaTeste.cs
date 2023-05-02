using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Teste
{
    public class LancarContaAReceberAvulsaTeste: BaseTestes
    {
        [Test(Description = "Lancar conta avulsa")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("LancarContaAvulsa")]
        [AllureSubSuite("ContaAReceber")]
        public void LancarContaAReceberAvulsa()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarContaAvulsaDaContaAReceberPage = beginLifetimeScope.Resolve<Func<DriverService, LancarContaAReceberAvulsaPage>>()(DriverService);
            lancarContaAvulsaDaContaAReceberPage.RealizarFluxoDeLancarContaAReceberAvulsa();
        }
    }
}
