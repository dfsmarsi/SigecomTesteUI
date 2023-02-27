using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Page;
using System;

namespace SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Teste
{
    public class AlteracaoEmMassaDoMarkupTeste:BaseTestes 
    {
        [Test(Description = "Alteração em massa do markup na manutenção de estoque")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("AlteracaoEmMassaDoMarkup")]
        [AllureSubSuite("ManutencaoDeEstoque")]
        public void AlteracaoEmMassaDoMarkupNaManutencaoDeEstoque()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var alteracaoEmMassaDoMarkupPage = beginLifetimeScope.Resolve<Func<DriverService, AlteracaoEmMassaDoMarkupPage>>()(DriverService);
            alteracaoEmMassaDoMarkupPage.RealizarFluxoDaAlteracaoEmMassaDoMarkupNaManutencaoDeEstoque();
        }
    }
}
