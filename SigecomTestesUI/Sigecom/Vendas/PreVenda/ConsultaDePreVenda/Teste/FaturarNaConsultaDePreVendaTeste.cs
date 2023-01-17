using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Teste
{
    public class FaturarNaConsultaDePreVendaTeste: BaseTestesComTelaAbertaNoFechar
    {
        [Test(Description = "Faturar pré venda pela consulta de pré venda")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Faturar")]
        [AllureSubSuite("Consulta de pré venda")]
        public void FaturarPreVendaPelaConsultaDePreVenda()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var faturarNaConsultaDePreVendaPage = beginLifetimeScope.Resolve<Func<DriverService, FaturarNaConsultaDePreVendaPage>>()(DriverService);
            faturarNaConsultaDePreVendaPage.RealizarFluxoDeFaturarNaConsultaDePreVenda();
        }
    }
}
