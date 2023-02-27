using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Teste
{
    public class EditarNaConsultaDeCondicionalTeste: BaseTestes
    {
        [Test(Description = "Editar na consulta de condicional")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("ConsultaDeCondicional")]
        public void EditarNaConsultaDeCondicional()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var editarNaConsultaDeCondicionalPage = beginLifetimeScope.Resolve<Func<DriverService, EditarNaConsultaDeCondicionalPage>>()(DriverService);
            editarNaConsultaDeCondicionalPage.RealizarFluxoDeAlterarCondicionalNaConsulta();
        }
    }
}
