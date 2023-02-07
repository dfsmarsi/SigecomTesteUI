using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
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
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(FiltroDaAnaliseDeEstoqueModel.FiltroDeProduto, FiltroDaAnaliseDeEstoqueModel.CodigoIdDoProduto, Keys.Enter);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Descrição"), FiltroDaAnaliseDeEstoqueModel.NomeDoProduto);
            ClicarBotaoName(FiltroDaAnaliseDeEstoqueModel.BotaoDeLimparFiltro);

            DriverService.DigitarNoCampoComTeclaDeAtalhoId(FiltroDaAnaliseDeEstoqueModel.FiltroDeProduto, FiltroDaAnaliseDeEstoqueModel.CodigoInternoDoProduto, Keys.Enter);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Descrição"), FiltroDaAnaliseDeEstoqueModel.NomeDoProduto);
            ClicarBotaoName(FiltroDaAnaliseDeEstoqueModel.BotaoDeLimparFiltro);

            DriverService.DigitarNoCampoComTeclaDeAtalhoId(FiltroDaAnaliseDeEstoqueModel.FiltroDeProduto, FiltroDaAnaliseDeEstoqueModel.CodigoDeBarrasDoProduto, Keys.Enter);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Descrição"), FiltroDaAnaliseDeEstoqueModel.NomeDoProduto);
            ClicarBotaoName(FiltroDaAnaliseDeEstoqueModel.BotaoDeLimparFiltro);

            // Assert
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(FiltroDaAnaliseDeEstoqueModel.FiltroDaReferencia, FiltroDaAnaliseDeEstoqueModel.ReferenciaDoProduto, Keys.Enter);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Descrição"), FiltroDaAnaliseDeEstoqueModel.NomeDoProduto);
            FecharTelaDeAnaliseDeEstoqueComEsc();
        }

        private void FecharTelaDeAnaliseDeEstoqueComEsc() =>
            DriverService.FecharJanelaComEsc(AnaliseDeEstoqueModel.ElementoTelaDeAnaliseDeEstoque);
    }
}
