using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.Teste
{
    public class AlterarTabelaDePrecoDaPreVendaTeste: BaseTestes
    {
        [Test(Description = "Alterar tabela de preço na pré venda")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Alterar")]
        [AllureSubSuite("Pedido")]
        public void AlterarTabelaDePrecoNaPreVenda()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var alterarTabelaDePrecoDaPreVendaTeste = beginLifetimeScope.Resolve<Func<DriverService, AlterarTabelaDePrecoDaPreVendaPage>>()(DriverService);
            alterarTabelaDePrecoDaPreVendaTeste.RealizarFluxoDeAlterarTabelaDePrecoNaPreVenda();
        }
    }
}
