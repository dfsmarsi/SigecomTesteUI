using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Page;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Teste
{
    public class VoltarNoPedidoComEscTeste: BaseTestes
    {
        [Test(Description = "Voltar no pedido com Esc")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Voltar")]
        [AllureSubSuite("Pedido")]
        public void VoltarNoPedidoComEsc()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var voltarNoPedidoComEscPage = beginLifetimeScope.Resolve<Func<DriverService, VoltarNoPedidoComEscPage>>()(DriverService);
            voltarNoPedidoComEscPage.RealizarFluxoDeVoltarNoPedido();
        }
    }
}
