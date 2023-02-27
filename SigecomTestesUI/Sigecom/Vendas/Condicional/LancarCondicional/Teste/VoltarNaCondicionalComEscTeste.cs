using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Teste
{
    public class VoltarNaCondicionalComEscTeste: BaseTestes
    {
        [Test(Description = "Voltar na condicional com Esc")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Voltar")]
        [AllureSubSuite("Condicional")]
        public void VoltarNaCondicionalComEsc()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var voltarNaCondicionalComEscPage = beginLifetimeScope.Resolve<Func<DriverService, VoltarNaCondicionalComEscPage>>()(DriverService);
            voltarNaCondicionalComEscPage.RealizarFluxoDeVoltarNaCondicionalComEsc();
        }
    }
}
