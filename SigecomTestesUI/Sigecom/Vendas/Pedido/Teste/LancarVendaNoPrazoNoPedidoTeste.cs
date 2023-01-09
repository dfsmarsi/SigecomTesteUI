using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.Teste
{
    public class LancarVendaNoPrazoNoPedidoTeste: BaseTestes
    {
        [Test(Description = "Lançar venda do prazo no pedido")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("LancarVenda")]
        [AllureSubSuite("Pedido")]
        public void LancarVendaDoPrazoNoPedido()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var voltarNoPedidoComEscPage = beginLifetimeScope.Resolve<Func<DriverService, LancarVendaNoPrazoNoPedidoPage>>()(DriverService);
            voltarNoPedidoComEscPage.RealizarFluxoDeLancarVendaDePrazoNoPedido();
        }
    }
}
