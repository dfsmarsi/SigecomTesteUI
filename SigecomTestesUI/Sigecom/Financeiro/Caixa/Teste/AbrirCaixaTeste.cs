using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.Caixa.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.Caixa.Teste
{
    public class AbrirCaixaTeste: BaseTestes
    {
        [Test(Description = "Abrir caixa")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("AbrirCaixa")]
        [AllureSubSuite("Caixa")]
        public void AbrirCaixa()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var abrirCaixaPage = beginLifetimeScope.Resolve<Func<DriverService, AbrirCaixaPage>>()(DriverService);
            abrirCaixaPage.RealizarFluxoDeAbrirCaixa();
        }
    }
}
