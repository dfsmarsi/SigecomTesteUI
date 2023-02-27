using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Devolucao.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Devolucao.Teste
{
    public class RemoverItemNaDevolucaoTeste: BaseTestes
    {
        [Test(Description = "Remover itens na devolução")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Remover")]
        [AllureSubSuite("Devolucao")]
        public void RemoverItensNaDevolucao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var removerItemNaDevolucaoPage = beginLifetimeScope.Resolve<Func<DriverService, RemoverItemNaDevolucaoPage>>()(DriverService);
            removerItemNaDevolucaoPage.RealizarFluxoDeRemoverItemNaDevolucao();
        }
    }
}
