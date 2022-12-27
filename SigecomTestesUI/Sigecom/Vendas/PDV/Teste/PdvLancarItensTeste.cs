using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Teste
{
    public class PdvLancarItensTeste: BaseTestes
    {
        [Test(Description = "Lançar itens no PDV")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("LancarItens")]
        [AllureSubSuite("PDV")]
        public void EditarTabelaDePrecoComProdutoEspecifico()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarItensNoPdvPage = beginLifetimeScope.Resolve<Func<DriverService, LancarItensNoPdvPage>>()(DriverService);
            lancarItensNoPdvPage.RealizarFluxoDeLancarItemNoPdv();
        }
    }
}
