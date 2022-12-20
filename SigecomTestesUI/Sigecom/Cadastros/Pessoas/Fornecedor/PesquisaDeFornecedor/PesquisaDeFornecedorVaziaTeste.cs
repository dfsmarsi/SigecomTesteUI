using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Page;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.PesquisaDeFornecedor
{
    public class PesquisaDeFornecedorVaziaTeste : BaseTestes
    {
        [Test(Description = "Pesquisa de fornecedor vazia")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Pesquisa")]
        [AllureSubSuite("Fornecedor")]
        public void PesquisarFornecedorComCampoVazio()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);

            // Arange
            var resolveCadastroDeFornecedorFisicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeFornecedorFisicoPage>>();
            var cadastroDeFornecedorFisicoPage = resolveCadastroDeFornecedorFisicoPage(DriverService, new Dictionary<string, string>());
            cadastroDeFornecedorFisicoPage.AcessarTelaDeCadastroDeFornecedorEPesquisar();

            // Act
            pesquisaDePessoaPage.PesquisarPessoa("fornecedor", "");

            // Assert
            Assert.True(pesquisaDePessoaPage.VerificarSeExisteQualquerPessoaNaGrid());
            pesquisaDePessoaPage.FecharJanelaComEsc("fornecedor");
            cadastroDeFornecedorFisicoPage.FecharJanelaCadastroFornecedorComEsc();
        }
    }
}
