using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Teste
{
    public class AlterarTabelaDePrecoDaCondicionalTeste:BaseTestes
    {
        [Test(Description = "Alterar tabela de preço da condicional")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("TabelaDePreco")]
        [AllureSubSuite("Condicional")]
        public void AlterarTabelaDePrecoDaCondicional()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var alterarTabelaDePrecoDaCondicionalPage = beginLifetimeScope.Resolve<Func<DriverService, AlterarTabelaDePrecoDaCondicionalPage>>()(DriverService);
            alterarTabelaDePrecoDaCondicionalPage.RealizarFluxoDeAlterarTabelaDePrecoNaCondicional();
        }
    }
}
