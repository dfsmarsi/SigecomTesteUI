using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Page;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Teste
{
    public class MarcarEntregaComFreteNaPreVendaTeste: BaseTestes
    {
        [Test(Description = "Marcar entrega com frete na pré venda")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Lancar")]
        [AllureSubSuite("Pré venda")]
        public void MarcarEntregaComFreteNaPreVenda()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var marcarEntregaComFreteNaPreVendaPage = beginLifetimeScope.Resolve<Func<DriverService, MarcarEntregaComFreteNaPreVendaPage>>()(DriverService);
            marcarEntregaComFreteNaPreVendaPage.RealizarFluxoDeMarcarEntregaComFrete();
        }
    }
}
