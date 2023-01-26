using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Teste
{
    public class AplicarDescontoNoOrcamentoTeste: BaseTestes
    {
        [Test(Description = "Aplicar desconto na orçamento")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Desconto")]
        [AllureSubSuite("Orcamento")]
        public void AplicarDescontoNoOrcamento()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var aplicarDescontoNoOrcamentoPage = beginLifetimeScope.Resolve<Func<DriverService, AplicarDescontoNoOrcamentoPage>>()(DriverService);
            aplicarDescontoNoOrcamentoPage.RealizarFluxoDeAplicarDescontoNoOrcamento();
        }
    }
}
