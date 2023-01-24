using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Teste
{
    public class LancarItensNoOrcamentoTeste: BaseTestes
    {
        [Test(Description = "Lançar itens no orçamento")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Lancar")]
        [AllureSubSuite("Orçamento")]
        public void LancarItensNoOrcamento()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarItensNoOrcamentoPage = beginLifetimeScope.Resolve<Func<DriverService, LancarItensNoOrcamentoPage>>()(DriverService);
            lancarItensNoOrcamentoPage.RealizarFluxoDeLancarItensNoOrcamento();
        }
    }
}
