using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Teste
{
    public class DarDescontoNoPdvTeste: BaseTestes
    {
        [Test(Description = "Dar desconto no produto no PDV")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Desconto")]
        [AllureSubSuite("PDV")]
        public void DarDescontoNoProdutoDoPdv()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var darDescontoNoPdvPage = beginLifetimeScope.Resolve<Func<DriverService, DarDescontoNoPdvPage>>()(DriverService);
            darDescontoNoPdvPage.RealizarFluxoDeDarDescontoAoProduto();
        }
    }
}
