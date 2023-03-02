using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Teste
{
    public class ReceberValorParcialDaContaAReceberTeste:BaseTestes
    {
        [Test(Description = "Receber valor parcial")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("ReceberValorParcial")]
        [AllureSubSuite("ContaAReceber")]
        public void ReceberValorParcialNaContaAReceber()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var receberValorParcialDaContaAReceberPage = beginLifetimeScope.Resolve<Func<DriverService, ReceberValorParcialDaContaAReceberPage>>()(DriverService);
            receberValorParcialDaContaAReceberPage.RealizarFluxoDeReceberValorParcialNaContaAReceber();
        }
    }
}
