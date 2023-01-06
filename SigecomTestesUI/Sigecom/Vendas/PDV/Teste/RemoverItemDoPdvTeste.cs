using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Teste
{
    public class RemoverItemDoPdvTeste: BaseTestes
    {
        [Test(Description = "Remover itens do PDV")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("RemoverItens")]
        [AllureSubSuite("PDV")]
        public void RemoverItensDoPdv()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var removerItemDoPdvPage = beginLifetimeScope.Resolve<Func<DriverService, RemoverItemDoPdvPage>>()(DriverService);
            removerItemDoPdvPage.RealizarFluxoDeRemoverItemNoPdv();
        }
    }
}
