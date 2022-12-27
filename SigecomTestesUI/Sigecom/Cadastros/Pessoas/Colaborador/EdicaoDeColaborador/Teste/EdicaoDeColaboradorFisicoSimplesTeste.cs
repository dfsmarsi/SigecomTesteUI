using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Enum;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Teste
{
    public class EdicaoDeColaboradorFisicoSimplesTeste : BaseTestes
    {
        [Test(Description = "Edição de colaborador físico somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("Colaborador")]
        public void EdicaoDeColaboradorFisicoSimples()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveEdicaoDeColaboradorBasePage = beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeColaboradorBasePage>>();
            var edicaoDeColaboradorBasePage = resolveEdicaoDeColaboradorBasePage(DriverService);
            edicaoDeColaboradorBasePage.RealizarFluxoDaEdicaoDeColaborador(ClassificacaoDePessoa.FisicaSimples);
        }
    }
}
