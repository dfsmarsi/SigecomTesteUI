using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Page;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Teste
{
    public class LancarItensNaOrdemDeServicoTeste: BaseTestes
    {
        [Test(Description = "Lançar itens na ordem de serviços")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Lancar")]
        [AllureSubSuite("OrdemDeServico")]
        public void LancarItensNaOrdemDeServico()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarItensNaOrdemDeServicoPage = beginLifetimeScope.Resolve<Func<DriverService, LancarItensNaOrdemDeServicoPage>>()(DriverService);
            lancarItensNaOrdemDeServicoPage.RealizarFluxoDeLancarItensNaOrdemDeServico();
        }
    }
}
