using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.Teste
{
    public class RemoverItemDaPreVendaTeste: BaseTestes
    {
        [Test(Description = "Remover itens na pré venda")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Remover")]
        [AllureSubSuite("Pré venda")]
        public void RemoverItensNaPreVenda()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var removerItemDaPreVendaPage = beginLifetimeScope.Resolve<Func<DriverService, RemoverItemDaPreVendaPage>>()(DriverService);
            removerItemDaPreVendaPage.RealizarFluxoDeRemoverItemNaPreVenda();
        }
    }
}
