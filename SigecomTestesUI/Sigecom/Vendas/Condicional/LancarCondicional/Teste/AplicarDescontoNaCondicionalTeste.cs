using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Teste
{
    public class AplicarDescontoNaCondicionalTeste: BaseTestes
    {
        [Test(Description = "Dar desconto nos itens da condicional")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Desconto")]
        [AllureSubSuite("Condicional")]
        public void AplicarDescontoNaCondicional()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var aplicarDescontoNaCondicionalPage = beginLifetimeScope.Resolve<Func<DriverService, AplicarDescontoNaCondicionalPage>>()(DriverService);
            aplicarDescontoNaCondicionalPage.RealizarFluxoDeAplicarDescontoNaCondicional();
        }
    }
}
