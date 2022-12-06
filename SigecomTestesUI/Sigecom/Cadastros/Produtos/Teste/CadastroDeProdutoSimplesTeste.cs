using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste
{
    public class CadastroDeProdutoSimplesTeste: BaseTestes
    {
        [Test(Description = "Cadastro de produto possuindo somente campos obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Douglas")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Produto")]
        public void CadastrarProdutoSomenteCamposObrigatorios()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeProdutoPage =
                beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoPage>>();
            var cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService);

            // Act
            cadastroDeProdutoPage.AdicionarUmNovoProdutoNaTelaDeCadastroDeProduto(cadastroDeProdutoPage);
            cadastroDeProdutoPage.PreencherCamposDoProduto(TipoDeProduto.Produto);
            cadastroDeProdutoPage.VerificarSePrecoDeVendaFoiCalculado();
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaImpostos);
            cadastroDeProdutoPage.PreencherCamposDeImpostos();
            cadastroDeProdutoPage.Gravar();

            // Assert
            cadastroDeProdutoPage.RealizarFluxoDePesquisaDoProduto(cadastroDeProdutoPage, TipoDeProduto.Produto);
        }
    }
}
