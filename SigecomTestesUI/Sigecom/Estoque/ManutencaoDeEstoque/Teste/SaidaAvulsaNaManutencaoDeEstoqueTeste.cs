using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Page;
using System;

namespace SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Teste
{
    public class SaidaAvulsaNaManutencaoDeEstoqueTeste : BaseTestes
    {
        [Test(Description = "Saida avulsa na manutenção de estoque")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("SaidaAvulsa")]
        [AllureSubSuite("ManutencaoDeEstoque")]
        public void SaidaAvulsaNaManutencaoDeEstoque()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var saidaAvulsaNaManutencaoDeEstoquePage = beginLifetimeScope.Resolve<Func<DriverService, SaidaAvulsaNaManutencaoDeEstoquePage>>()(DriverService);
            saidaAvulsaNaManutencaoDeEstoquePage.RealizarFluxoDeSaidaAvulsaNaManutencaoDeEstoque();
        }
    }
}
