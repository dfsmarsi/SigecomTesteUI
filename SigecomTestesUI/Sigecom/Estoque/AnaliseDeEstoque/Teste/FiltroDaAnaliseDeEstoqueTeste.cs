using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Estoque.AnaliseDeEstoque.Page;
using System;

namespace SigecomTestesUI.Sigecom.Estoque.AnaliseDeEstoque.Teste
{
    public class FiltroDaAnaliseDeEstoqueTeste: BaseTestes
    {
        [Test(Description = "Filtro da analise de estoque")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Filtrar")]
        [AllureSubSuite("AnaliseDeEstoque")]
        public void FiltroDaAnaliseDeEstoque()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var filtroDaAnaliseDeEstoquePage = beginLifetimeScope.Resolve<Func<DriverService, FiltroDaAnaliseDeEstoquePage>>()(DriverService);
            filtroDaAnaliseDeEstoquePage.RealizarFluxoDeFiltrarProdutoNaAnaliseDeEstoque();
        }
    }
}
