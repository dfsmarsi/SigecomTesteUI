using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Teste
{
    public class PesquisaDeProdutoPorCodigoDeBarrasTeste : BaseTestes
    {
        [Test(Description = "Pesquisa de Produto por código de barras")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Pesquisa")]
        [AllureSubSuite("Produto")]
        public void PesquisarProdutoPeloCodigoDeBarras()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var pesquisaDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>()(DriverService);

            // Act
            pesquisaDeProdutoPage.PesquisarComF9UmProdutoNaTelaPrincipal(beginLifetimeScope);
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(PesquisaDeProdutoInformacoesParaTesteModel.CodigoDeBarras);

            // Assert
            Assert.True(pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto));
            pesquisaDeProdutoPage.FecharJanelaComEsc();
        }
    }
}
