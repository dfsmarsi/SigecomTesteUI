using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Page;
using System;

namespace SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Teste
{
    public class AlteracaoEmMassaDoCustoTeste:BaseTestes
    {
        [Test(Description = "Alteração em massa do custo na manutenção de estoque")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("AlteracaoEmMassaDoCusto")]
        [AllureSubSuite("ManutencaoDeEstoque")]
        public void AlteracaoEmMassaDoCustoNaManutencaoDeEstoque()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var alteracaoEmMassaDoCustoPage = beginLifetimeScope.Resolve<Func<DriverService, AlteracaoEmMassaDoCustoPage>>()(DriverService);
            alteracaoEmMassaDoCustoPage.RealizarFluxoDaAlteracaoEmMassaDoCustoNaManutencaoDeEstoque();
        }
    }
}
