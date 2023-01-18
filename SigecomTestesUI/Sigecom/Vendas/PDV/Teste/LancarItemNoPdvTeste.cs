using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Teste
{
    public class LancarItemNoPdvTeste: BaseTestes
    {
        [Test(Description = "Lançar itens no PDV")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Lancar")]
        [AllureSubSuite("PDV")]
        public void LancarItensNoPdv()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarItemNoPdvPage = beginLifetimeScope.Resolve<Func<DriverService, LancarItemNoPdvPage>>()(DriverService);
            lancarItemNoPdvPage.RealizarFluxoDeLancarItemNoPdv();
        }
    }
}
