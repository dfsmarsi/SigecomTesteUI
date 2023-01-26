using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using System;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Page;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Teste
{
    public class AlterarTabelaDePrecoNoOrcamentoTeste: BaseTestes
    {
        [Test(Description = "Alterar tabela de preço no orçamento")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("TabelaDePreco")]
        [AllureSubSuite("Orcamento")]
        public void AlterarTabelaDePrecoNoOrcamento()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var alterarTabelaDePrecoNoOrcamentoPage = beginLifetimeScope.Resolve<Func<DriverService, AlterarTabelaDePrecoNoOrcamentoPage>>()(DriverService);
            alterarTabelaDePrecoNoOrcamentoPage.RealizarFluxoDeAlterarTabelaDePrecoNoOrcamento();
        }
    }
}
