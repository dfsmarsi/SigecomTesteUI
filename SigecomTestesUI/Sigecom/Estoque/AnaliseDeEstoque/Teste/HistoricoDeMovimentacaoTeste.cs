using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Estoque.AnaliseDeEstoque.Page;
using System;

namespace SigecomTestesUI.Sigecom.Estoque.AnaliseDeEstoque.Teste
{
    public class HistoricoDeMovimentacaoTeste: BaseTestesComTelaAbertaNoFechar
    {
        [Test(Description = "Historico de movimentação da analise de estoque")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("HistoricoDeMovimentacao")]
        [AllureSubSuite("AnaliseDeEstoque")]
        public void HistoricoDeMovimentacaoDaAnaliseDeEstoque()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var historicoDeMovimentacaoPage = beginLifetimeScope.Resolve<Func<DriverService, HistoricoDeMovimentacaoPage>>()(DriverService);
            historicoDeMovimentacaoPage.RealizarFluxoDeHistoricoDeMovimentacaoNaAnaliseDeEstoque();
        }
    }
}
