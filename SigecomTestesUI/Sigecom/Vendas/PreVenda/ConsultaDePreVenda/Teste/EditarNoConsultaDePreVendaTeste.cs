using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Teste
{
    public class EditarNoConsultaDePreVendaTeste: BaseTestesComTelaAbertaNoFechar
    {
        [Test(Description = "Editar pré venda pela consulta de pré venda")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("Consulta de pré venda")]
        public void EditarPreVemdaPelaConsultaDePreVenda()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var editarNoConsultaDePreVendaPage = beginLifetimeScope.Resolve<Func<DriverService, EditarNoConsultaDePreVendaPage>>()(DriverService);
            editarNoConsultaDePreVendaPage.RealizarFluxoDeEditarNaConsultaDePreVenda();
        }
    }
}
