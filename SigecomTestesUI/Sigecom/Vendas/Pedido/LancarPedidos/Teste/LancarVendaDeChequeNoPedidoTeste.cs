using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Page;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Teste
{
    public class LancarVendaDeChequeNoPedidoTeste: BaseTestes
    {
        [Test(Description = "Lançar venda do cheque no pedido")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Lancar")]
        [AllureSubSuite("Pedido")]
        public void LancarVendaDoChequeNoPedido()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarVendaDeChequeNoPedidoPage = beginLifetimeScope.Resolve<Func<DriverService, LancarVendaDeChequeNoPedidoPage>>()(DriverService);
            lancarVendaDeChequeNoPedidoPage.RealizarFluxoDeLancarVendaDeChequeNoPedido();
        }
    }
}
