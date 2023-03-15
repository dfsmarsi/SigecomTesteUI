using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using SigecomTestesUI.Sigecom.Estoque.AnaliseDeEstoque.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Estoque.AnaliseDeEstoque.Page
{
    public class FiltroDaAnaliseDeEstoquePage: PageObjectModel
    {
        public FiltroDaAnaliseDeEstoquePage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(AnaliseDeEstoqueModel.BotaoMenuEstoque);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(AnaliseDeEstoqueModel.BotaoSubMenu);

        public void RealizarFluxoDeFiltrarProdutoNaAnaliseDeEstoque()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();

            // Act
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(FiltroDaAnaliseDeEstoqueModel.FiltroDeProduto, PesquisaDeProdutoInformacoesParaTesteModel.PesquisarItemId, Keys.Enter);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Descrição"), PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto);
            ClicarBotaoName(FiltroDaAnaliseDeEstoqueModel.BotaoDeLimparFiltro);

            DriverService.DigitarNoCampoComTeclaDeAtalhoId(FiltroDaAnaliseDeEstoqueModel.FiltroDeProduto, PesquisaDeProdutoInformacoesParaTesteModel.CodigoInternoDoProduto, Keys.Enter);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Descrição"), PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto);
            ClicarBotaoName(FiltroDaAnaliseDeEstoqueModel.BotaoDeLimparFiltro);

            DriverService.DigitarNoCampoComTeclaDeAtalhoId(FiltroDaAnaliseDeEstoqueModel.FiltroDeProduto, PesquisaDeProdutoInformacoesParaTesteModel.CodigoDeBarras, Keys.Enter);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Descrição"), PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto);
            ClicarBotaoName(FiltroDaAnaliseDeEstoqueModel.BotaoDeLimparFiltro);

            // Assert
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(FiltroDaAnaliseDeEstoqueModel.FiltroDaReferencia, PesquisaDeProdutoInformacoesParaTesteModel.ReferenciaDoProduto, Keys.Enter);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Descrição"), PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto);
            FecharTelaDeAnaliseDeEstoqueComEsc();
        }

        private void FecharTelaDeAnaliseDeEstoqueComEsc() =>
            DriverService.FecharJanelaComEsc(AnaliseDeEstoqueModel.ElementoTelaDeAnaliseDeEstoque);
    }
}
