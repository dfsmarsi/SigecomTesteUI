using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Teste
{
    public class EdicaoDeFornecedorFisicoCompletoTeste: BaseTestes
    {
        [Test(Description = "Edição de fornecedor físico somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("Fornecedor")]
        public void EdicaoDeFornecedorFisicoSimples()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveEdicaoDeFornecedorBasePage = beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeFornecedorBasePage>>();
            var edicaoDeFornecedorBasePage = resolveEdicaoDeFornecedorBasePage(DriverService);
            edicaoDeFornecedorBasePage.RealizarFluxoDaEdicaoDeFornecedor(ClassificacaoDePessoa.FisicaCompleta);
        }
    }
}
