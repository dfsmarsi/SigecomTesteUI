using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Teste
{
    public class ReceberValorParcialTeste:BaseTestes
    {
        [Test(Description = "Receber valor parcial")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("ReceberValorParcial")]
        [AllureSubSuite("ContaAReceber")]
        public void ReceberValorParcial()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var receberValorParcialPage = beginLifetimeScope.Resolve<Func<DriverService, ReceberValorParcialPage>>()(DriverService);
            receberValorParcialPage.RealizarFluxoDeReceberValorParcialNaContaAReceber();
        }
    }
}
