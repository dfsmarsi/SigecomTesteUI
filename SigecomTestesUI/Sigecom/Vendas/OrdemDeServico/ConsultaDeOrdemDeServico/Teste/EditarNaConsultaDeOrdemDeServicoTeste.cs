using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.ConsultaDeOrdemDeServico.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.ConsultaDeOrdemDeServico.Teste
{
    public class EditarNaConsultaDeOrdemDeServicoTeste: BaseTestes
    {
        [Test(Description = "Editar da consulta de ordem de serviço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("ConsultaDaOrdemDeServico")]
        public void EditarNaConsultaDaOrdemDeServico()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var editarNaConsultaDeOrdemDeServicoPage = beginLifetimeScope.Resolve<Func<DriverService, EditarNaConsultaDeOrdemDeServicoPage>>()(DriverService);
            editarNaConsultaDeOrdemDeServicoPage.RealizarFluxoDeEditarNaConsultaDaOrdemDeServico();
        }
    }
}
