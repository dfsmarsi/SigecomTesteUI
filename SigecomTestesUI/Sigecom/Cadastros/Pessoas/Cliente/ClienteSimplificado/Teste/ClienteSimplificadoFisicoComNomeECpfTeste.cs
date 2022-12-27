using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Enum;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Teste
{
    public class ClienteSimplificadoFisicoComNomeECpfTeste : BaseTestes
    {
        [Test(Description = "Cadastro de cliente simplificado fisíco com nome e cpf")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("ClienteSimplificado")]
        public void CadastrarClienteSimplificadoFisicoComNomeECpf()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveClienteSimplificadoBasePage = beginLifetimeScope.Resolve<Func<DriverService, ClienteSimplificadoBasePage>>();
            var clienteSimplificadoBasePage = resolveClienteSimplificadoBasePage(DriverService);
            clienteSimplificadoBasePage.RealizarFluxoDeCadastroDeClienteSimplificado(TipoDeClienteSimplificado.FisicoComNomeECpf);
        }
    }
}
