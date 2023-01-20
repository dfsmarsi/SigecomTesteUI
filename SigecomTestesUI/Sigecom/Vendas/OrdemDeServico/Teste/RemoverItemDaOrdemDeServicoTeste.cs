using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Teste
{
    public class RemoverItemDaOrdemDeServicoTeste: BaseTestes
    {
        [Test(Description = "Remover itens da ordem de serviço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Remover")]
        [AllureSubSuite("OrdemDeServico")]
        public void RemoverItensDoOrdemDeServico()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var removerItemDaOrdemDeServicoPage = beginLifetimeScope.Resolve<Func<DriverService, RemoverItemDaOrdemDeServicoPage>>()(DriverService);
            removerItemDaOrdemDeServicoPage.RealizarFluxoDeRemoverItemNaOrdemDeServico();
        }
    }
}
