using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Teste
{
    public class ReceberValorTotalDaContaAReceberTeste:BaseTestes
    {
        [Test(Description = "Receber valor total")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("ReceberValorTotal")]
        [AllureSubSuite("ContaAReceber")]
        public void ReceberValorTotalNaContaAReceber()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var receberValorTotalDaContaAReceberPage = beginLifetimeScope.Resolve<Func<DriverService, ReceberValorTotalDaContaAReceberPage>>()(DriverService);
            receberValorTotalDaContaAReceberPage.RealizarFluxoDeReceberValorTotalNaContaAReceber();
        }
    }
}
