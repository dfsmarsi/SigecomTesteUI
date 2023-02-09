using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Page;

namespace SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Teste
{
    public class AlteracaoEmMassaDaVendaTeste: BaseTestes
    {
        [Test(Description = "Alteração em massa da venda na manutenção de estoque")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("AlteracaoEmMassaDaVenda")]
        [AllureSubSuite("ManutencaoDeEstoque")]
        public void AlteracaoEmMassaDaVendaNaManutencaoDeEstoque()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var alteracaoEmMassaDaVendaPage = beginLifetimeScope.Resolve<Func<DriverService, AlteracaoEmMassaDaVendaPage>>()(DriverService);
            alteracaoEmMassaDaVendaPage.RealizarFluxoDaAlteracaoEmMassaDaVendaNaManutencaoDeEstoque();
        }
    }
}
