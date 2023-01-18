using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Teste
{
    public class AlterarTabelaDePrecoDoPdvTeste: BaseTestes
    {
        [Test(Description = "Alterar tabela de preço no pdv")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Alterar")]
        [AllureSubSuite("PDV")]
        public void AlterarTabelaDePrecoNoPdv()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var alterarTabelaDePrecoDoPdvPage = beginLifetimeScope.Resolve<Func<DriverService, AlterarTabelaDePrecoDoPdvPage>>()(DriverService);
            alterarTabelaDePrecoDoPdvPage.RealizarFluxoDeAlterarTabelaDePrecoNoPdv();
        }
    }
}
