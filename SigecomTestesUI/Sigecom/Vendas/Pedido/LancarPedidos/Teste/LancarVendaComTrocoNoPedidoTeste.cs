using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Page;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Teste
{
    public class LancarVendaComTrocoNoPedidoTeste: BaseTestes
    {
        [Test(Description = "Lançar venda com troco no pedido")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Lancar")]
        [AllureSubSuite("Pedido")]
        public void LancarVendaComTrocoNoPedido()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarVendaComTrocoNoPedidoPage = beginLifetimeScope.Resolve<Func<DriverService, LancarVendaComTrocoNoPedidoPage>>()(DriverService);
            lancarVendaComTrocoNoPedidoPage.RealizarFluxoDeLancarVendaComTrocoNoPedido();
        }
    }
}
