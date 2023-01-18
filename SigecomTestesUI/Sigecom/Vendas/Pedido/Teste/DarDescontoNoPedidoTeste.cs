using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.Teste
{
    public class DarDescontoNoPedidoTeste: BaseTestes
    {
        [Test(Description = "Dar desconto nos itens no pedido")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Desconto")]
        [AllureSubSuite("Pedido")]
        public void DarDescontoNoPedido()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var darDescontoNoPedidoPage = beginLifetimeScope.Resolve<Func<DriverService, DarDescontoNoPedidoPage>>()(DriverService);
            darDescontoNoPedidoPage.RealizarFluxoDeDescontoNoItemDoPedido();
        }
    }
}
