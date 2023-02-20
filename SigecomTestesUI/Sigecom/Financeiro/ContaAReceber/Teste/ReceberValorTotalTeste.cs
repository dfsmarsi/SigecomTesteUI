using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Teste
{
    public class ReceberValorTotalTeste:BaseTestes
    {
        [Test(Description = "Receber valor total")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("ReceberValorTotal")]
        [AllureSubSuite("ContaAReceber")]
        public void ReceberValorTotal()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var receberValorTotalPage = beginLifetimeScope.Resolve<Func<DriverService, ReceberValorTotalPage>>()(DriverService);
            receberValorTotalPage.RealizarFluxoDeReceberValorTotalNaContaAReceber();
        }
    }
}
