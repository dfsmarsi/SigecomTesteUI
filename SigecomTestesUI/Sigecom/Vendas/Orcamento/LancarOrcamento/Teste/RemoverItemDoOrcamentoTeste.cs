using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Teste
{
    public class RemoverItemDoOrcamentoTeste:BaseTestes
    {
        [Test(Description = "Remover itens do orçamento")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Remover")]
        [AllureSubSuite("Orcamento")]
        public void RemoverItensDoOrcamento()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var removerItemDoOrcamentoPage = beginLifetimeScope.Resolve<Func<DriverService, RemoverItemDoOrcamentoPage>>()(DriverService);
            removerItemDoOrcamentoPage.RealizarFluxoDeRemoverItemNoOrcamento();
        }
    }
}
