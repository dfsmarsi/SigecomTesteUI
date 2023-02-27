using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Teste
{
    public class EstornarNaConsultaDePreVendaTeste: BaseTestesComTelaAbertaNoFechar
    {
        [Test(Description = "Estornar pré venda pela consulta de pré venda")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Estornar")]
        [AllureSubSuite("Consulta de pré venda")]
        public void EstornarPreVendaPelaConsultaDePreVenda()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var estornarNaConsultaDePreVendaPage = beginLifetimeScope.Resolve<Func<DriverService, EstornarNaConsultaDePreVendaPage>>()(DriverService);
            estornarNaConsultaDePreVendaPage.RealizarFluxoDeEstornarNaConsultaDePreVenda();
        }
    }
}
