using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Teste
{
    public class DetalhesNaConsultaDePreVendaTeste: BaseTestesComTelaAbertaNoFechar
    {
        [Test(Description = "Detalhes da pré venda pela consulta de pré venda")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Detalhes")]
        [AllureSubSuite("Consulta de pré venda")]
        public void DetalhesDaPreVendaPelaConsultaDePreVenda()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var detalhesNaConsultaDePreVendaPage = beginLifetimeScope.Resolve<Func<DriverService, DetalhesNaConsultaDePreVendaPage>>()(DriverService);
            detalhesNaConsultaDePreVendaPage.RealizarFluxoDeDetalhesNaConsultaDePreVenda();
        }
    }
}
