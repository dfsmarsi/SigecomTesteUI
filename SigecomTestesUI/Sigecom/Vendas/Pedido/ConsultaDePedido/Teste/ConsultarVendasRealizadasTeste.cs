using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Pedido.ConsultaDePedido.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.ConsultaDePedido.Teste
{
    public class ConsultarVendasRealizadasTeste: BaseTestes
    {
        [Test(Description = "Consultar vendas realizadas na consulta de pedido")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("ConsultarVendasRealizadas")]
        [AllureSubSuite("ConsultaDePedido")]
        public void ConsultarVendasRealizadasNaConsultaDePedido()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var consultarVendasRealizadasPage = beginLifetimeScope.Resolve<Func<DriverService, ConsultarVendasRealizadasPage>>()(DriverService);
            consultarVendasRealizadasPage.RealizarFluxoDeConsultarVendasRealizadas();
        }
    }
}
