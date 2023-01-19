using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.Teste
{
    public class RemoverItemDoPedidoTeste : BaseTestes
    {
        [Test(Description = "Remover itens do Pedido")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Remover")]
        [AllureSubSuite("Pedido")]
        public void RemoverItensDoPedido()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var removerItemDoPedidoPage = beginLifetimeScope.Resolve<Func<DriverService, RemoverItemDoPedidoPage>>()(DriverService);
            removerItemDoPedidoPage.RealizarFluxoDeRemoverItemDoPedido();
        }
    }
}
