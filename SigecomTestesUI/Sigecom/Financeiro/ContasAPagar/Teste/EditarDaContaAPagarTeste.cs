using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Teste
{
    public class EditarDaContaAPagarTeste:BaseTestes
    {
        [Test(Description = "Editar da conta a pagar")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("EditarDaContaAPagar")]
        [AllureSubSuite("ContaAPagar")]
        public void EditarDaContaAPagar()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var editarDaContaAPagarPage = beginLifetimeScope.Resolve<Func<DriverService, EditarDaContaAPagarPage>>()(DriverService);
            editarDaContaAPagarPage.RealizarFluxoDeEditarDaContaAPagar();
        }
    }
}
