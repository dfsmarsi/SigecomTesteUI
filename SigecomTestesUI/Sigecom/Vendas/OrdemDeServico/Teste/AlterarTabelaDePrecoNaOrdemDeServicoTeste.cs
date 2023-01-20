using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Teste
{
    public class AlterarTabelaDePrecoNaOrdemDeServicoTeste: BaseTestes
    {
        [Test(Description = "Alterar tabela de preço na ordem de serviço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("TabelaDePreco")]
        [AllureSubSuite("OrdemDeServico")]
        public void AlterarTabelaDePrecoNaOrdemDeServico()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var alterarTabelaDePrecoNaOrdemDeServicoPage = beginLifetimeScope.Resolve<Func<DriverService, AlterarTabelaDePrecoNaOrdemDeServicoPage>>()(DriverService);
            alterarTabelaDePrecoNaOrdemDeServicoPage.RealizarFluxoDeAlterarTabelaDePrecoNaOrdemDeServico();
        }
    }
}
