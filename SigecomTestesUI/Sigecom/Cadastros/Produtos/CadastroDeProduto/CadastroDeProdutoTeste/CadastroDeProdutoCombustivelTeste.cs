using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoTeste
{
    public class CadastroDeProdutoCombustivelTeste : BaseTestes
    {
        [Test(Description = "Cadastro de produto de combustível possuindo somente campos obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Produto")]
        public void CadastrarProdutoDeCombustivelSomenteCamposObrigatorios()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeProdutoPage =
                beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoPage.CadastroDeProdutoBasePage>>();
            var cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService);
            cadastroDeProdutoPage.RealizarFluxoDeCadastrarProduto(TipoDeProduto.Combustivel, CadastroDeProdutoModel.AbaCombustivel);
        }
    }
}
