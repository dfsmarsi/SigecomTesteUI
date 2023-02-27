using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Page;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Teste
{
    public class AlterarTabelaDePrecoDoPedidoTeste:BaseTestes
    {
        [Test(Description = "Alterar tabela de preço no pedido")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Alterar")]
        [AllureSubSuite("Pedido")]
        public void AlterarTabelaDePrecoNoPedido()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var alterarTabelaDePrecoDoPedidoPage = beginLifetimeScope.Resolve<Func<DriverService, AlterarTabelaDePrecoDoPedidoPage>>()(DriverService);
            alterarTabelaDePrecoDoPedidoPage.RealizarFluxoDeAlterarTabelaDePrecoNoPedido();
        }
    }
}
