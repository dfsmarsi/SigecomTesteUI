using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Teste
{
    public class EdicaoDeProdutoMedicamentoTeste : BaseTestes
    {
        [Test(Description = "Edição de produto medicamento")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("Produto")]
        public void EdicaoDeProdutoMedicamento()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveEdicaoDeProdutoBasePage = beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeProdutoBasePage>>();
            var edicaoDeProdutoBasePage = resolveEdicaoDeProdutoBasePage(DriverService);
            const TipoDeProduto tipoDeProduto = TipoDeProduto.Medicamento;

            // Act
            edicaoDeProdutoBasePage.PesquisarProdutoQueSeraEditado(tipoDeProduto);
            edicaoDeProdutoBasePage.VerificarCamposDoProduto(tipoDeProduto);
            edicaoDeProdutoBasePage.PreencherCamposDoProdutoAoEditar(tipoDeProduto);
            edicaoDeProdutoBasePage.AcessarAba(CadastroDeProdutoModel.AbaMedicamento);
            edicaoDeProdutoBasePage.VerificarCamposDaAba(tipoDeProduto);
            edicaoDeProdutoBasePage.PreencherCamposDaAbaAoEditar(tipoDeProduto);
            edicaoDeProdutoBasePage.Gravar();

            // Assert
            edicaoDeProdutoBasePage.RealizarFluxoDePesquisaDoProdutoQueFoiEditado(tipoDeProduto);
            edicaoDeProdutoBasePage.AcessarAba(CadastroDeProdutoModel.AbaMedicamento);
            edicaoDeProdutoBasePage.VerificarCamposDaAbaEditado(tipoDeProduto);
            edicaoDeProdutoBasePage.FecharJanelaCadastroDeProdutoComEsc();
        }
    }
}
