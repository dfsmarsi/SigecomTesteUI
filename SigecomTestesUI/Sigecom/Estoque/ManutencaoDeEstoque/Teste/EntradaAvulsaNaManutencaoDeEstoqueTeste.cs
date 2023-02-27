using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Page;
using System;

namespace SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Teste
{
    public class EntradaAvulsaNaManutencaoDeEstoqueTeste: BaseTestes
    {
        [Test(Description = "Entrada avulsa na manutenção de estoque")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("EntradaAvulsa")]
        [AllureSubSuite("ManutencaoDeEstoque")]
        public void EntradaAvulsaNaManutencaoDeEstoque()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var entradaAvulsaNaManutencaoDeEstoquePage = beginLifetimeScope.Resolve<Func<DriverService, EntradaAvulsaNaManutencaoDeEstoquePage>>()(DriverService);
            entradaAvulsaNaManutencaoDeEstoquePage.RealizarFluxoDeEntradaAvulsaNaManutencaoDeEstoque();
        }
    }
}
