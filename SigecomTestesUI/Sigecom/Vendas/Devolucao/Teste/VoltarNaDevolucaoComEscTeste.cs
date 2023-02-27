using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Devolucao.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Devolucao.Teste
{
    public class VoltarNaDevolucaoComEscTeste: BaseTestes
    {
        [Test(Description = "Voltar na devolucao com Esc")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Voltar")]
        [AllureSubSuite("Devolucao")]
        public void VoltarNaDevolucaoComEsc()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var voltarNaDevolucaoComEscPage = beginLifetimeScope.Resolve<Func<DriverService, VoltarNaDevolucaoComEscPage>>()(DriverService);
            voltarNaDevolucaoComEscPage.RealizarFluxoDeVoltarNaDevolucaoComEsc();
        }
    }
}
