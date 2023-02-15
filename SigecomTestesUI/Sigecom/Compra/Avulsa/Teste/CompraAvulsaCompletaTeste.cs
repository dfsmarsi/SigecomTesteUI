using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Compra.Avulsa.Page;
using System;

namespace SigecomTestesUI.Sigecom.Compra.Avulsa.Teste
{
    public class CompraAvulsaCompletaTeste:BaseTestes
    {
        [Test(Description = "Compra avulsa completa")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("CompraAvulsa")]
        [AllureSubSuite("Compra")]
        public void CompraAvulsaCompleta()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var compraAvulsaCompletaPage = beginLifetimeScope.Resolve<Func<DriverService, CompraAvulsaCompletaPage>>()(DriverService);
            compraAvulsaCompletaPage.RealizarFluxoDaCompraAvulsa();
        }
    }
}
