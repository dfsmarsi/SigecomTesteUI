using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Teste
{
    public class EdicaoDeProdutoSimplesTeste : BaseTestes
    {
        [Test(Description = "Editar produto simples possuindo somente campos obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Produto")]
        public void EditarProdutoSomenteCamposObrigatorios()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeProdutoPage =
                beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoPage.CadastroDeProdutoBasePage>>();
            var cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService);

            // Act
            cadastroDeProdutoPage.EditarProdutoNaTelaDeCadastroDeProduto(cadastroDeProdutoPage);
            cadastroDeProdutoPage.VerificarCamposDeProduto(TipoDeProduto.Produto);
            cadastroDeProdutoPage.PreencherCamposDoProdutoAoEditar(TipoDeProduto.Produto);
            cadastroDeProdutoPage.VerificarCamposDeProdutoEditado(TipoDeProduto.Produto);
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaImpostos);
            cadastroDeProdutoPage.VerificarCamposDeImpostos();
            cadastroDeProdutoPage.PreencherCamposDeImpostos();
            cadastroDeProdutoPage.Gravar();

            // Assert
            cadastroDeProdutoPage.RealizarFluxoDePesquisaDoProdutoParaOEditar(cadastroDeProdutoPage, TipoDeProduto.Produto);
        }
    }
}
