using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.Teste
{
    public class LancarItensNoPedidoTeste : BaseTestes
    {
        [Test(Description = "Lançar itens no pedido")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("LancarItens")]
        [AllureSubSuite("Pedido")]
        public void LancarItensNoPdv()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var itensNoPedidoPage = beginLifetimeScope.Resolve<Func<DriverService, LancarItensNoPedidoPage>>()(DriverService);
            itensNoPedidoPage.RealizarFluxoDeLancarItemNoPedido();
        }
    }
}
