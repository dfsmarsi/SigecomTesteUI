using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Page;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Teste
{
    public class LancarItensNaCondicionalTeste: BaseTestes
    {
        [Test(Description = "Lançar itens na Condicional")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Lancar")]
        [AllureSubSuite("Condicional")]
        public void LancarItensNaCondicional()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarItensNaCondicionalPage = beginLifetimeScope.Resolve<Func<DriverService, LancarItensNaCondicionalPage>>()(DriverService);
            lancarItensNaCondicionalPage.RealizarFluxoDeLancarItemNaCondicional();
        }
    }
}
