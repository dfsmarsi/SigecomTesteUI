using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.Teste
{
    public class LancarItensNaPreVendaTeste: BaseTestes
    {
        [Test(Description = "Lançar itens na pré venda")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Lancar")]
        [AllureSubSuite("Pré venda")]
        public void LancarItensNaPreVenda()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarItensNaPreVendaPage = beginLifetimeScope.Resolve<Func<DriverService, LancarItensNaPreVendaPage>>()(DriverService);
            lancarItensNaPreVendaPage.RealizarFluxoDeLancarItemNaPreVenda();
        }
    }
}
