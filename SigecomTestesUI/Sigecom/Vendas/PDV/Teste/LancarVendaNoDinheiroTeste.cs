using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Enum;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Teste
{
    public class LancarVendaNoDinheiroTeste: BaseTestes
    {
        [Test(Description = "Lançar itens no dinheiro no PDV")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Lancar")]
        [AllureSubSuite("PDV")]
        public void LancarItensNoDinheiroDoPdv()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarVendaNaFormaDePagamentoPage = beginLifetimeScope.Resolve<Func<DriverService, LancarVendaNaFormaDePagamentoPage>>()(DriverService);
            lancarVendaNaFormaDePagamentoPage.RealizarFluxoDeLancarVendaNoPdv(FormaDePagamento.Dinheiro);
        }
    }
}
