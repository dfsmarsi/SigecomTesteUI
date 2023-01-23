using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Teste
{
    public class CadastrarObjetoTeste: BaseTestes
    {
        [Test(Description = "Cadastrar objeto na ordem de serviço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Objeto")]
        [AllureSubSuite("OrdemDeServico")]
        public void CadastrarObjetoNaOrdemDeServico()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var cadastrarObjetoPage = beginLifetimeScope.Resolve<Func<DriverService, CadastrarObjetoPage>>()(DriverService);
            cadastrarObjetoPage.RealizarFluxoDeCadastrarObjetoNaOrdemDeServico();
        }
    }
}
