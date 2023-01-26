using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Teste
{
    public class VoltarNoOrcamentoComEscTeste: BaseTestes
    {
        [Test(Description = "Voltar no orçamento com esc")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Voltar")]
        [AllureSubSuite("Orcamento")]
        public void VoltarNoOrcamentoComEsc()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var voltarNoOrcamentoComEscPage = beginLifetimeScope.Resolve<Func<DriverService, VoltarNoOrcamentoComEscPage>>()(DriverService);
            voltarNoOrcamentoComEscPage.RealizarFluxoDeVoltarNoOrcamentoComEsc();
        }
    }
}
