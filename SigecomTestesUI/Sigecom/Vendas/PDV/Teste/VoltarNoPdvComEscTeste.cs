using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Teste
{
    public class VoltarNoPdvComEscTeste:BaseTestes
    {
        [Test(Description = "Voltar itens no PDV com Esc")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("LancarItens")]
        [AllureSubSuite("PDV")]
        public void VoltarItensNoPdv()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var voltarNoPdvComEscPage = beginLifetimeScope.Resolve<Func<DriverService, VoltarNoPdvComEscPage>>()(DriverService);
            voltarNoPdvComEscPage.RealizarFluxoDeVoltarNoPdv();
        }
    }
}
