using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Compra.Xml.Page;
using System;

namespace SigecomTestesUI.Sigecom.Compra.Xml.Teste
{
    public class CompraXmlCompletaTeste: BaseTestes
    {
        [Test(Description = "Compra Xml completa")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("CompraXml")]
        [AllureSubSuite("Compra")]
        public void CompraXmlCompleta()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var compraXmlCompletaPage = beginLifetimeScope.Resolve<Func<DriverService, CompraXmlCompletaPage>>()(DriverService);
            compraXmlCompletaPage.RealizarFluxoDaCompraXml();
        }
    }
}
