using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using SigecomTestesUI.Sigecom.Estoque.AnaliseDeEstoque.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Estoque.AnaliseDeEstoque.Page
{
    public class HistoricoDeMovimentacaoPage: PageObjectModel
    {
        public HistoricoDeMovimentacaoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(AnaliseDeEstoqueModel.BotaoMenuEstoque);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(AnaliseDeEstoqueModel.BotaoSubMenu);

        public void RealizarFluxoDeHistoricoDeMovimentacaoNaAnaliseDeEstoque()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoName(AnaliseDeEstoqueModel.BotaoDeManutencaoDeEstoque);

            // Act
            Assert.AreEqual(DriverService.ObterValorElementoName(PesquisaDeProdutoModel.TelaPesquisaDeProdutoPrefixo), PesquisaDeProdutoModel.TelaPesquisaDeProdutoPrefixo);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(PesquisaDeProdutoModel.ElementoParametroDePesquisa,
                PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto, Keys.Enter);

            // Assert
            Assert.AreEqual(DriverService.ObterValorElementoName(AnaliseDeEstoqueModel.BotaoDeManutencaoDeEstoque), AnaliseDeEstoqueModel.BotaoDeManutencaoDeEstoque);
        }
    }
}
