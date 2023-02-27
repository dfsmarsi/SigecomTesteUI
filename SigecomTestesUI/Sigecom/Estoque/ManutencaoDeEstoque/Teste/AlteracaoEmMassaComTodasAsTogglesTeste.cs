using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Page;
using System;

namespace SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Teste
{
    public class AlteracaoEmMassaComTodasAsTogglesTeste: BaseTestes
    {
        [Test(Description = "Alteração em massa com todas as toggles na manutenção de estoque")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("AlteracaoEmMassaComTodasAsToggles")]
        [AllureSubSuite("ManutencaoDeEstoque")]
        public void AlteracaoEmMassaComTodasAsTogglesNaManutencaoDeEstoque()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var alteracaoEmMassaComTodasAsTogglesPage = beginLifetimeScope.Resolve<Func<DriverService, AlteracaoEmMassaComTodasAsTogglesPage>>()(DriverService);
            alteracaoEmMassaComTodasAsTogglesPage.RealizarFluxoDaAlteracaoEmMassaComTodasAsTogglesNaManutencaoDeEstoque();
        }
    }
}
