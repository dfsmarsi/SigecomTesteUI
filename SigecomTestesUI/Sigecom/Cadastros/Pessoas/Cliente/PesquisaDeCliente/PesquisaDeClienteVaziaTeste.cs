using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Page;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.PesquisaDeCliente
{
    public class PesquisaDeClienteVaziaTeste:BaseTestes
    {
        [Test(Description = "Pesquisa de cliente vazia")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Pesquisa")]
        [AllureSubSuite("Cliente")]
        public void PesquisarClienteComCampoVazio()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);
        
            // Arange
            var resolveCadastroDeCliente = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeClienteFisicoPage>>();
            var cadastroDeCliente = resolveCadastroDeCliente(DriverService, new Dictionary<string, string>());
            cadastroDeCliente.AcessarTelaDeCadastroDeCliente(false);

            // Act
            pesquisaDePessoaPage.PesquisarPessoa("cliente", "");

            // Assert
            Assert.True(pesquisaDePessoaPage.VerificarSeExisteQualquerPessoaNaGrid());
            pesquisaDePessoaPage.FecharJanelaComEsc("cliente");
            cadastroDeCliente.FecharJanelaComEsc();
        }
    }
}
