using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Teste
{
    public class GerarOrdemDeServicoNaConsultaDeOrcamentoTeste: BaseTestes
    {
        [Test(Description = "Gerar ordem de serviço na consulta do orçamento")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("GerarOrdemDeServico")]
        [AllureSubSuite("ConsultaDoOrcamento")]
        public void GerarOrdemDeServicoNaConsultaDeOrcamento()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var gerarOrdemDeServicoNaConsultaDeOrcamentoPage = beginLifetimeScope.Resolve<Func<DriverService, GerarOrdemDeServicoNaConsultaDeOrcamentoPage>>()(DriverService);
            gerarOrdemDeServicoNaConsultaDeOrcamentoPage.RealizarFluxoDeGerarOrdemDeServicoNaConsultaDoOrcamento();
        }
    }
}
