using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Teste
{
    public class ReceberValorParcialComHaverDaContaAReceberTeste:BaseTestes
    {
        [Test(Description = "Receber valor parcial com haver")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("ReceberValorParcialComHaver")]
        [AllureSubSuite("ContaAReceber")]
        public void ReceberValorParcialComHaverNaContaAReceber()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var receberValorParcialComHaverDaContaAReceberPage = beginLifetimeScope.Resolve<Func<DriverService, ReceberValorParcialComHaverDaContaAReceberPage>>()(DriverService);
            receberValorParcialComHaverDaContaAReceberPage.RealizarFluxoDeReceberValorParcialComHaverNaContaAReceber();
        }
    }
}
