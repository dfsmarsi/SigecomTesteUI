using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Teste
{
    public class FazerAcordoNaContasAReceberTeste:BaseTestes
    {
        [Test(Description = "Fazer acordo na conta a receber")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("FazerAcordoNaContasAReceber")]
        [AllureSubSuite("ContaAReceber")]
        public void FazerAcordoNaContasAReceber()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var fazerAcordoNaContasAReceberPage = beginLifetimeScope.Resolve<Func<DriverService, FazerAcordoNaContasAReceberPage>>()(DriverService);
            fazerAcordoNaContasAReceberPage.RealizarFluxoDeFazerAcordoNaContaAReceber();
        }
    }
}
