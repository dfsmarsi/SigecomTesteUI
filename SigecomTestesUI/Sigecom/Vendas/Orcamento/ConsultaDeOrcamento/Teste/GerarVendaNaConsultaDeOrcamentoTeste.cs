using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Teste
{
    public class GerarVendaNaConsultaDeOrcamentoTeste: BaseTestes
    {
        [Test(Description = "Gerar venda da consulta do orçamento")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("GerarVenda")]
        [AllureSubSuite("ConsultaDoOrcamento")]
        public void GerarVendaNaConsultaDoOrcamento()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var gerarVendaNaConsultaDeOrcamentoPage = beginLifetimeScope.Resolve<Func<DriverService, GerarVendaNaConsultaDeOrcamentoPage>>()(DriverService);
            gerarVendaNaConsultaDeOrcamentoPage.RealizarFluxoDeGerarVendaNaConsultaDoOrcamento();
        }
    }
}
