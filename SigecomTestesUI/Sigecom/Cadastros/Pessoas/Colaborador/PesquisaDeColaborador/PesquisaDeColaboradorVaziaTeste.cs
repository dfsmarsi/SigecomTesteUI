using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Page;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.PesquisaDeColaborador
{
    public class PesquisaDeColaboradorVaziaTeste:BaseTestes
    {
        [Test(Description = "Pesquisa de colaborador vazia")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Pesquisa")]
        [AllureSubSuite("Colaborador")]
        public void PesquisarColaboradorComCampoVazio()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);

            // Arange
            var resolveCadastroDeColaboradorFisicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeColaboradorFisicoPage>>();
            var cadastroDeColaboradorFisicoPage = resolveCadastroDeColaboradorFisicoPage(DriverService, new Dictionary<string, string>());
            cadastroDeColaboradorFisicoPage.AcessarTelaDeCadastroDeColaboradorEPesquisar();

            // Act
            pesquisaDePessoaPage.PesquisarPessoa("colaborador", "");

            // Assert
            Assert.True(pesquisaDePessoaPage.VerificarSeExisteQualquerPessoaNaGrid());
            pesquisaDePessoaPage.FecharJanelaComEsc("colaborador");
            cadastroDeColaboradorFisicoPage.FecharJanelaCadastroColaboradorComEsc();
        }
    }
}
