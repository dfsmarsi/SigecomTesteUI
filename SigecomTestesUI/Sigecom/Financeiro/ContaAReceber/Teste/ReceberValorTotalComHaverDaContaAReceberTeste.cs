using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Teste
{
    public class ReceberValorTotalComHaverDaContaAReceberTeste:BaseTestes
    {
        [Test(Description = "Receber valor total com haver")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("ReceberValorTotalComHaver")]
        [AllureSubSuite("ContaAReceber")]
        public void ReceberValorTotalComHaverNaContaAReceber()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var receberValorTotalComHaverDaContaAReceberPage = beginLifetimeScope.Resolve<Func<DriverService, ReceberValorTotalComHaverDaContaAReceberPage>>()(DriverService);
            receberValorTotalComHaverDaContaAReceberPage.RealizarFluxoDeReceberValorTotalComHaverNaContaAReceber();
        }
    }
}
