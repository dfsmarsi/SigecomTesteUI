using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.Caixa.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.Caixa.Teste
{
    public class ReabrirCaixaTeste:BaseTestes
    {
        [Test(Description = "Reabrir caixa")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("ReabrirCaixa")]
        [AllureSubSuite("Caixa")]
        public void ReabrirCaixa()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var reabrirCaixaPage = beginLifetimeScope.Resolve<Func<DriverService, ReabrirCaixaPage>>()(DriverService);
            reabrirCaixaPage.RealizarFluxoDeReabrirCaixa();
        }
    }
}
