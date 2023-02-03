using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Teste
{
    public class GerarPreVendaGravandoNaConsultaDeOrcamentoTeste: BaseTestes
    {
        [Test(Description = "Gerar pré venda na consulta do orçamento")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("GerarPreVenda")]
        [AllureSubSuite("ConsultaDoOrcamento")]
        public void GerarPreVendaGravandoNaConsultaDeOrcamento()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var gerarPreVendaNaConsultaDeOrcamentoPage = beginLifetimeScope.Resolve<Func<DriverService, GerarPreVendaGravandoNaConsultaDeOrcamentoPage>>()(DriverService);
            gerarPreVendaNaConsultaDeOrcamentoPage.RealizarFluxoDeGerarPreVendaGravandoNaConsultaDoOrcamento();
        }
    }
}
