using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Teste
{
    public class EditarNaConsultaDeOrcamentoTeste: BaseTestes
    {
        [Test(Description = "Editar da consulta do orçamento")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("ConsultaDoOrcamento")]
        public void EditarNaConsultaDoOrcamento()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var consultaDeOrdemDeServicoPage = beginLifetimeScope.Resolve<Func<DriverService, EditarNaConsultaDeOrcamentoPage>>()(DriverService);
            consultaDeOrdemDeServicoPage.RealizarFluxoDeEditarNaConsultaDoOrcamento();
        }
    }
}
