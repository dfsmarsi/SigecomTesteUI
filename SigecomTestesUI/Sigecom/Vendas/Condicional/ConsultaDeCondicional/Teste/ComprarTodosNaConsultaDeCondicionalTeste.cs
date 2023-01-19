using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Teste
{
    public class ComprarTodosNaConsultaDeCondicionalTeste: BaseTestes
    {
        [Test(Description = "Comprar todos na consulta de condicional")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("ComprarTodos")]
        [AllureSubSuite("ConsultaDeCondicional")]
        public void ComprarTodosNaConsultaDeCondicional()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var comprarTodosNaConsultaDeCondicionalPage = beginLifetimeScope.Resolve<Func<DriverService, ComprarTodosNaConsultaDeCondicionalPage>>()(DriverService);
            comprarTodosNaConsultaDeCondicionalPage.RealizarFluxoDeCompraTodosNaConsultaDeCondicional();
        }
    }
}
