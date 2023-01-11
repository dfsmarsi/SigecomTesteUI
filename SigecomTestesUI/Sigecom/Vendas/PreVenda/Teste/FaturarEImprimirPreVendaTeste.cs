using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.Teste
{
    public class FaturarEImprimirPreVendaTeste:BaseTestes
    {
        [Test(Description = "Faturar e imprimir a pré venda")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Faturar")]
        [AllureSubSuite("Pré venda")]
        public void FaturarEImprimirAPreVenda()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var faturarEImprimirPreVendaPage = beginLifetimeScope.Resolve<Func<DriverService, FaturarEImprimirPreVendaPage>>()(DriverService);
            faturarEImprimirPreVendaPage.RealizarFluxoDeFaturarEImprimir();
        }
    }
}
