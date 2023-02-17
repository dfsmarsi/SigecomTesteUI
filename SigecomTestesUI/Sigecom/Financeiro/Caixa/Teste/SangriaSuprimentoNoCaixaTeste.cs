using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.Caixa.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.Caixa.Teste
{
    public class SangriaSuprimentoNoCaixaTeste:BaseTestes
    {
        [Test(Description = "Sangria e suprimento na caixa")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("SangriaSuprimento")]
        [AllureSubSuite("Caixa")]
        public void SangriaSuprimentoNoCaixa()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var sangriaSuprimentoNoCaixaPage = beginLifetimeScope.Resolve<Func<DriverService, SangriaSuprimentoNoCaixaPage>>()(DriverService);
            sangriaSuprimentoNoCaixaPage.RealizarFluxoDeSangriaSuprimento();
        }
    }
}
