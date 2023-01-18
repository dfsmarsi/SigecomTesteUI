using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.Teste
{
    public class LancarVendaDeBancoNoPedidoTeste: BaseTestes
    {
        [Test(Description = "Lançar itens no banco do PDV")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Lancar")]
        [AllureSubSuite("Pedido")]
        public void LancarItensNoBancoDoPedido()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarVendaDeBancoNoPedidoPage = beginLifetimeScope.Resolve<Func<DriverService, LancarVendaDeBancoNoPedidoPage>>()(DriverService);
            lancarVendaDeBancoNoPedidoPage.RealizarFluxoDeLancarVendaDeBancoNoPedido();
        }
    }
}
