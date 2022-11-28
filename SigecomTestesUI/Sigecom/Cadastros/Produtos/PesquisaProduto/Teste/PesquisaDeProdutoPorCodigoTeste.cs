using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Services;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Teste
{
    public class PesquisaDeProdutoPorCodigoTeste: PesquisaDeProdutoBaseTeste
    {
        [Test(Description = "Pesquisa de Produto por Códigos")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Pesquisa")]
        [AllureSubSuite("Produto")]
        public void PesquisarProdutoPeloCodigo()
        {
            var dadosDeProduto = AdicionandoInformacoesNecessariasParaOTeste();
            AbrirTelaDePesquisaDeProduto(dadosDeProduto, out var beginLifetimeScope);

            var resolvePesquisaDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>();
            var pesquisaDeProdutoPage = resolvePesquisaDeProdutoPage(DriverService);
            pesquisaDeProdutoPage.PesquisarProduto(dadosDeProduto["CodigoProduto"]);
            var possuiProduto = pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(dadosDeProduto["NomeFinal"]);
            Assert.True(possuiProduto);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
        }

        private static Dictionary<string, string> AdicionandoInformacoesNecessariasParaOTeste() =>
            new Dictionary<string, string>
            {
                {"CodigoProduto","1"},
                {"Nome","PRODUTO TESTE PESQUISA"},
                {"Unidade", "UN"},
                {"CodigoInterno","int"},
                {"Categoria","BALANCA"},
                {"Custo","5,00"},
                {"Markup","100,00"},
                {"PrecoVenda","10,00"},
                {"Referencia","ref"},
                {"NCM","22030000"},
                {"GasNacional","0"},
                {"GasImportado","0"},
                {"ValorPartida","0"},
                {"QtdeGasNatural","0"},
                {"NomeFinal","PRODUTO TESTE PESQUISA"}
            };
    }
}
