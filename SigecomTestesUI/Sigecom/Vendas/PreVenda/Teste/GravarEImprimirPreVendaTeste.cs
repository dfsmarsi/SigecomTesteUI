using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.Teste
{
    public class GravarEImprimirPreVendaTeste: BaseTestes
    {
        [Test(Description = "Gravar e imprimir a pré venda")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Lancar")]
        [AllureSubSuite("Pré venda")]
        public void GravarEImprimirAPreVenda()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var gravarEImprimirPreVendaPage = beginLifetimeScope.Resolve<Func<DriverService, GravarEImprimirPreVendaPage>>()(DriverService);
            gravarEImprimirPreVendaPage.RealizarFluxoDeGravarEImprimir();
        }
    }
}
