using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Teste
{
    public class AbrirDetalhesDaContaAReceberTeste: BaseTestes
    {
        [Test(Description = "Abrir detalhes da conta")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("AbrirDetalhesDaConta")]
        [AllureSubSuite("ContaAReceber")]
        public void AbrirDetalhesDaConta()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var abrirDetalhesDaContaPage = beginLifetimeScope.Resolve<Func<DriverService, AbrirDetalhesDaContaAReceberPage>>()(DriverService);
            abrirDetalhesDaContaPage.RealizarFluxoDeAbrirDetalhesDaContaNaContaAReceber();
        }
    }
}
