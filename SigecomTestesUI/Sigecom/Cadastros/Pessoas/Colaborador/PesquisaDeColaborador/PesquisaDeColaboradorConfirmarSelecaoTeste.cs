using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Page;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.PesquisaDeColaborador.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.PesquisaDeColaborador
{
    public class PesquisaDeColaboradorConfirmarSelecaoTeste : BaseTestes
    {
        [Test(Description = "Pesquisa de colaborador confirmando a seleção")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Pesquisa")]
        [AllureSubSuite("Colaborador")]
        public void PesquisarColaboradorComConfirmarSelecao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);

            // Arange
            var resolveCadastroDeColaboradorFisicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeColaboradorFisicoPage>>();
            var cadastroDeColaboradorFisicoPage = resolveCadastroDeColaboradorFisicoPage(DriverService, new Dictionary<string, string>());
            cadastroDeColaboradorFisicoPage.AcessarTelaDeCadastroDeColaborador(false);

            // Act
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("colaborador", PesquisaDeColaboradorInformacoesParaTesteModel.NomeDaPessoa);

            // Assert
            Assert.True(pesquisaDePessoaPage.VerificarSeCarregouOsDadosDaPessoa(CadastroDeClienteModel.ElementoNome, PesquisaDeColaboradorInformacoesParaTesteModel.NomeDaPessoa));
            cadastroDeColaboradorFisicoPage.FecharJanelaCadastroColaboradorComEsc();
        }
    }
}
