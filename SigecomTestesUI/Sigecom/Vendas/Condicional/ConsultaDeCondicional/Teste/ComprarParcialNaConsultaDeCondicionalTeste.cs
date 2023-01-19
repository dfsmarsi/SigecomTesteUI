using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Teste
{
    public class ComprarParcialNaConsultaDeCondicionalTeste: BaseTestes
    {
        [Test(Description = "Comprar parcial na consulta de condicional")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("ComprarParcial")]
        [AllureSubSuite("ConsultaDeCondicional")]
        public void CompraParcialNaConsultaDeCondicional()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var comprarParcialNaConsultaDeCondicionalPage = beginLifetimeScope.Resolve<Func<DriverService, ComprarParcialNaConsultaDeCondicionalPage>>()(DriverService);
            comprarParcialNaConsultaDeCondicionalPage.RealizarFluxoDeCompraParcialNaConsultaDeCondicional();
        }
    }
}
