using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoTeste
{
    public class CadastroDeProdutoBalancaTeste: BaseTestes
    {
        [Test(Description = "Cadastro de produto de balança possuindo somente campos obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Produto")]
        public void CadastrarProdutoDeBalancaSomenteCamposObrigatorios()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeProdutoPage =
                beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoPage.CadastroDeProdutoBasePage>>();
            var cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService);
            cadastroDeProdutoPage.AdicionarUmNovoProdutoNaTelaDeCadastroDeProduto(cadastroDeProdutoPage);

            // Act
            cadastroDeProdutoPage.PreencherCamposDoProduto(TipoDeProduto.Balanca);
            cadastroDeProdutoPage.VerificarSePrecoDeVendaFoiCalculado();
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaImpostos);
            cadastroDeProdutoPage.PreencherCamposDeImpostos();
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaBalanca);
            cadastroDeProdutoPage.PreencherCamposDaAba(TipoDeProduto.Balanca);
            cadastroDeProdutoPage.Gravar();

            // Assert
            cadastroDeProdutoPage.RealizarFluxoDePesquisaDoProduto(cadastroDeProdutoPage, TipoDeProduto.Balanca);
        }
    }
}
