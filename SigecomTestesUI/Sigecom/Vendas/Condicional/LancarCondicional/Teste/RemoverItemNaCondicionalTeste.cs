using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Teste
{
    public class RemoverItemNaCondicionalTeste: BaseTestes
    {
        [Test(Description = "Remover itens da condicional")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Remover")]
        [AllureSubSuite("Condicional")]
        public void RemoverItensDoCondicional()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var removerItemDaCondicionalPage = beginLifetimeScope.Resolve<Func<DriverService, RemoverItemDaCondicionalPage>>()(DriverService);
            removerItemDaCondicionalPage.RealizarFluxoDeRemoverItemDaCondicional();
        }
    }
}
