using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Teste
{
    public class AbrirDetalhesDaContaAPagarTeste:BaseTestes
    {
        [Test(Description = "Abrir detalhes da conta")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("AbrirDetalhesDaConta")]
        [AllureSubSuite("ContaAPagar")]
        public void AbrirDetalhesDaContaNaContaAPagar()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var abrirDetalhesDaContaAPagarPage = beginLifetimeScope.Resolve<Func<DriverService, AbrirDetalhesDaContaAPagarPage>>()(DriverService);
            abrirDetalhesDaContaAPagarPage.RealizarFluxoDeAbrirDetalhesDaContaNaContaAPagar();
        }
    }
}
