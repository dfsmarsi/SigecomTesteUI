using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Page;
using System;

namespace SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Teste
{
    public class AlteracaoEmMassaPrincipalTeste: BaseTestes
    {
        [Test(Description = "Alteração em massa principal na manutenção de estoque")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("AlteracaoEmMassaPrincipal")]
        [AllureSubSuite("ManutencaoDeEstoque")]
        public void AlteracaoEmMassaPrincipalNaManutencaoDeEstoque()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var alteracaoEmMassaPrincipalPage = beginLifetimeScope.Resolve<Func<DriverService, AlteracaoEmMassaPrincipalPage>>()(DriverService);
            alteracaoEmMassaPrincipalPage.RealizarFluxoDaAlteracaoEmMassaPrincipalNaManutencaoDeEstoque();
        }
    }
}
