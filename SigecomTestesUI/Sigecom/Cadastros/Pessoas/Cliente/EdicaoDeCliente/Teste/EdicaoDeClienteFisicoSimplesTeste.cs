using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Teste
{
    public class EdicaoDeClienteFisicoSimplesTeste : BaseTestes
    {
        [Test(Description = "Edição de cliente físico somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("Cliente")]
        public void EdicaoDeClienteFisicoSimples()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeClienteFisicoPage = beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeClienteBasePage>>();
            var edicaoDeClienteBasePage = resolveCadastroDeClienteFisicoPage(DriverService);
            edicaoDeClienteBasePage.PesquisarProdutoQueSeraEditado();

            // Act
            edicaoDeClienteBasePage.VerificarInformacoesDoCliente();
            edicaoDeClienteBasePage.PreencherAsInformacoesDaPessoasNaEdicao();
            edicaoDeClienteBasePage.Gravar();

            // Assert
            edicaoDeClienteBasePage.FluxoDePesquisaDaPessoaEditado();
            edicaoDeClienteBasePage.VerificarDadosDaPessoaEditados();
            edicaoDeClienteBasePage.FecharJanelaCadastroDeClienteComEsc();
        }
    }
}
