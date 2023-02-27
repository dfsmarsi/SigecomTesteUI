using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Teste
{
    public class EstornarDaContaAPagarTeste:BaseTestes
    {
        [Test(Description = "Estornar conta a pagar")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("EstornarDaContaAPagar")]
        [AllureSubSuite("ContaAPagar")]
        public void EstornarDaContaAPagar()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var estornarDaContaAPagarPage = beginLifetimeScope.Resolve<Func<DriverService, EstornarDaContaAPagarPage>>()(DriverService);
            estornarDaContaAPagarPage.RealizarFluxoDeEstornarNaContaAPagar();
        }
    }
}
