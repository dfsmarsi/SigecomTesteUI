using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Teste
{
    public class ClonarNaConsultaDePreVendaTeste: BaseTestesComTelaAbertaNoFechar
    {
        [Test(Description = "Clonar pré venda pela consulta de pré venda")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Clonar")]
        [AllureSubSuite("Consulta de pré venda")]
        public void ClonarPreVendaPelaConsultaDePreVenda()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var clonarNaConsultaDePreVendaPage = beginLifetimeScope.Resolve<Func<DriverService, ClonarNaConsultaDePreVendaPage>>()(DriverService);
            clonarNaConsultaDePreVendaPage.RealizarFluxoDeClonarNaConsultaDePreVenda();
        }
    }
}
