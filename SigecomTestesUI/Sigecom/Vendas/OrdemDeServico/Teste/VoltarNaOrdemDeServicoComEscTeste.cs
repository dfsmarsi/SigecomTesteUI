using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Teste
{
    public class VoltarNaOrdemDeServicoComEscTeste: BaseTestes
    {
        [Test(Description = "Voltar na ordem de serviço com esc")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Voltar")]
        [AllureSubSuite("OrdemDeServico")]
        public void VoltarNaOrdemDeServicoComEsc()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var voltarNaOrdemDeServicoComEscPage = beginLifetimeScope.Resolve<Func<DriverService, VoltarNaOrdemDeServicoComEscPage>>()(DriverService);
            voltarNaOrdemDeServicoComEscPage.RealizarFluxoDeVoltarNaOrdemDeServicoComEsc();
        }
    }
}
