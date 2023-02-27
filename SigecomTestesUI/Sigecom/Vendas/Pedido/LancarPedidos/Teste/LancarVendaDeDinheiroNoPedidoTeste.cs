using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Page;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Teste
{
    public class LancarVendaDeDinheiroNoPedidoTeste: BaseTestes
    {
        [Test(Description = "Lançar itens no dinheiro do PDV")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Lancar")]
        [AllureSubSuite("Pedido")]
        public void LancarItensNoDinheiroDinheiroDoPedido()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarVendaDeDinheiroNoPedidoPage = beginLifetimeScope.Resolve<Func<DriverService, LancarVendaDeDinheiroNoPedidoPage>>()(DriverService);
            lancarVendaDeDinheiroNoPedidoPage.RealizarFluxoDeLancarVendaDeDinheiroNoPedido();
        }
    }
}
