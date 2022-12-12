using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Teste
{
    public class EdicaoDeProdutoSimplesTeste : BaseTestes
    {
        [Test(Description = "Edição de produto simples possuindo somente campos obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("Produto")]
        public void EdicaoDeProdutoSomenteCamposObrigatorios()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveEdicaoDeProdutoBasePage = beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeProdutoBasePage>>();
            var edicaoDeProdutoBasePage = resolveEdicaoDeProdutoBasePage(DriverService);

            // Act
            edicaoDeProdutoBasePage.PesquisarProdutoQueSeraEditado(TipoDeProduto.Produto);
            edicaoDeProdutoBasePage.VerificarCamposDeProduto(TipoDeProduto.Produto);
            edicaoDeProdutoBasePage.PreencherCamposDoProdutoAoEditar(TipoDeProduto.Produto);
            edicaoDeProdutoBasePage.AcessarAba(CadastroDeProdutoModel.AbaImpostos);
            edicaoDeProdutoBasePage.VerificarCamposDeImpostos();
            edicaoDeProdutoBasePage.PreencherCamposDeImpostosAoEditar();
            edicaoDeProdutoBasePage.Gravar();

            // Assert
            edicaoDeProdutoBasePage.RealizarFluxoDePesquisaDoProdutoQueFoiEditado(TipoDeProduto.Produto);
            edicaoDeProdutoBasePage.VerificarCamposDeImpostosEditado();
            edicaoDeProdutoBasePage.AcessarAba(CadastroDeProdutoModel.AbaProduto);
            edicaoDeProdutoBasePage.VerificarCamposDeProdutoEditado(TipoDeProduto.Produto);
            edicaoDeProdutoBasePage.FecharJanelaCadastroDeProdutoComEsc();
        }
    }
}
