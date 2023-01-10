using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.Page;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.Teste
{
    public class DarDescontoNaPreVendaTeste: BaseTestes
    {
        [Test(Description = "Dar desconto no item da pré venda")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Desconto")]
        [AllureSubSuite("Pré venda")]
        public void DarDescontoNoItemDaPreVenda()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var darDescontoNaPreVendaPage = beginLifetimeScope.Resolve<Func<DriverService, DarDescontoNaPreVendaPage>>()(DriverService);
            darDescontoNaPreVendaPage.RealizarFluxoDeDarDescontoNoItemDaPreVenda();
        }
    }
}
