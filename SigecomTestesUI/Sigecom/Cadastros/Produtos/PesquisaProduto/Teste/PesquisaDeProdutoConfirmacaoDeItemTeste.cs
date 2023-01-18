using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Teste
{
    public class PesquisaDeProdutoConfirmacaoDeItemTeste : BaseTestes
    {
        [Test(Description = "Pesquisa de Produto para Confirmação de Item")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Pesquisa")]
        [AllureSubSuite("Produto")]
        public void PesquisarProdutoParaConfirmacaoDeItem()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>();
            var pesquisaDeProdutoPage = resolvePesquisaDeProdutoPage(DriverService);

            // Act
            pesquisaDeProdutoPage.PesquisarComF9UmProdutoNaTelaDeCadastroDeProduto(beginLifetimeScope, out var cadastroDeProdutoPage);
            pesquisaDeProdutoPage.PesquisarProdutoDoConfirmacaoDeItem(PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto);
            
            // Assert
            Assert.True(pesquisaDeProdutoPage.VerificarSeCarregouOsDadosDoProduto());
            cadastroDeProdutoPage.GravarAoEditarEFecharATela();
        }
    }
}
