using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Teste
{
    public class AplicarDescontoNaOrdemDeServicoTeste: BaseTestes
    {
        [Test(Description = "Aplicar desconto na ordem de serviço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Desconto")]
        [AllureSubSuite("OrdemDeServico")]
        public void AplicarDescontoNaOrdemDeServico()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var aplicarDescontoNaOrdemDeServicoPage = beginLifetimeScope.Resolve<Func<DriverService, AplicarDescontoNaOrdemDeServicoPage>>()(DriverService);
            aplicarDescontoNaOrdemDeServicoPage.RealizarFluxoDeLancarItensNaOrdemDeServico();
        }
    }
}
