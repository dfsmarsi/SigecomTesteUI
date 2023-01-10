using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.Teste
{
    public class VoltarNaPreVendaComEscTeste: BaseTestes
    {
        [Test(Description = "Voltar na pré venda com esc")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Voltar")]
        [AllureSubSuite("Pré venda")]
        public void VoltarNaPreVendaComEsc()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var voltarNaPreVendaComEscPage = beginLifetimeScope.Resolve<Func<DriverService, VoltarNaPreVendaComEscPage>>()(DriverService);
            voltarNaPreVendaComEscPage.RealizarFluxoDeVoltarNaPreVenda();
        }
    }
}
