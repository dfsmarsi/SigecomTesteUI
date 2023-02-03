using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Teste
{
    public class GerarPreVendaFaturandoNaConsultaDeOrcamentoTeste: BaseTestes
    {
        [Test(Description = "Gerar pré venda faturando na consulta do orçamento")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("GerarPreVenda")]
        [AllureSubSuite("ConsultaDoOrcamento")]
        public void GerarPreVendaFaturandoNaConsultaDeOrcamento()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var preVendaFaturandoNaConsultaDeOrcamentoPage = beginLifetimeScope.Resolve<Func<DriverService, GerarPreVendaFaturandoNaConsultaDeOrcamentoPage>>()(DriverService);
            preVendaFaturandoNaConsultaDeOrcamentoPage.RealizarFluxoDeGerarPreVendaFaturandoNaConsultaDoOrcamento();
        }
    }
}
