using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Teste
{
    public class PagarValorParcialDaContaAPagarTeste:BaseTestes
    {
        [Test(Description = "PAgar valor parcial")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("PagarValorParcial")]
        [AllureSubSuite("ContaAReceber")]
        public void PagarValorParcialDaContaAPagar()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var pagarValorParcialDaContaAPagarPage = beginLifetimeScope.Resolve<Func<DriverService, PagarValorParcialDaContaAPagarPage>>()(DriverService);
            pagarValorParcialDaContaAPagarPage.RealizarFluxoDePagarValorParcialNaContaAPagar();
        }
    }
}
