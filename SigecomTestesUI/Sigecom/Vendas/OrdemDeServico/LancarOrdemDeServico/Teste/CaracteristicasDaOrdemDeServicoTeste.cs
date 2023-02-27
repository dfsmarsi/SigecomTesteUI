using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Teste
{
    public class CaracteristicasDaOrdemDeServicoTeste: BaseTestes
    {
        [Test(Description = "Lancar características na ordem de serviço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Características")]
        [AllureSubSuite("OrdemDeServico")]
        public void LancarCaracteristicasNaOrdemDeServico()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var caracteristicasDaOrdemDeServicoPage = beginLifetimeScope.Resolve<Func<DriverService, CaracteristicasDaOrdemDeServicoPage>>()(DriverService);
            caracteristicasDaOrdemDeServicoPage.RealizarFluxoDeLancarCaracteristicasNaOrdemDeServico();
        }
    }
}
