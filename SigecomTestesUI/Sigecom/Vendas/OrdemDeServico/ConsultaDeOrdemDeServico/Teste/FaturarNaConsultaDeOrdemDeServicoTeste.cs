using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.ConsultaDeOrdemDeServico.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.ConsultaDeOrdemDeServico.Teste
{
    public class FaturarNaConsultaDeOrdemDeServicoTeste: BaseTestes
    {
        [Test(Description = "Faturar da consulta de ordem de serviço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Faturar")]
        [AllureSubSuite("OrdemDeServico")]
        public void FaturarNaConsultaDaOrdemDeServico()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var faturarNaConsultaDeOrdemDeServicoPage = beginLifetimeScope.Resolve<Func<DriverService, FaturarNaConsultaDeOrdemDeServicoPage>>()(DriverService);
            faturarNaConsultaDeOrdemDeServicoPage.RealizarFluxoDeFaturarNaConsultaDaOrdemDeServico();
        }
    }
}
