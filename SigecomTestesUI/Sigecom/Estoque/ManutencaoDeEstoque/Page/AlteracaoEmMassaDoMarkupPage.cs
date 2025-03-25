using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Page
{
    public class AlteracaoEmMassaDoMarkupPage: PageObjectModel
    {
        public AlteracaoEmMassaDoMarkupPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ManutencaoDeEstoqueModel.BotaoMenuEstoque);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ManutencaoDeEstoqueModel.BotaoSubMenu);

        public void RealizarFluxoDaAlteracaoEmMassaDoMarkupNaManutencaoDeEstoque()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(PesquisaDeProdutoModel.ElementoParametroDePesquisa,
                PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto, Keys.Enter);
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoDeAlteracaoEmMassa);

            // Act
            DriverService.TrocarJanela();
            const string acrescentarNoValor = "100";
            ClicarBotaoName(AlteracaoEmMassaModel.ElementoDeGroupButtomMarkup);
            DriverService.SelecionarItemComboBox(AlteracaoEmMassaModel.ElementoDoTipoDeAlteracao, 3);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(AlteracaoEmMassaModel.ElementoDoValorDaVendaPorcentagem, acrescentarNoValor, Keys.Enter);
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoConfirmar);
            DriverService.TrocarJanela();
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoSim);
            DriverService.TrocarJanela();
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoSim);

            // Assert
            DriverService.TrocarJanela();
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Markup"), $"{acrescentarNoValor},00%");
            FecharTelaDeManutencaoDeEstoqueComEsc();
        }

        private void FecharTelaDeManutencaoDeEstoqueComEsc() =>
            DriverService.FecharJanelaComEsc(ManutencaoDeEstoqueModel.ElementoTelaDeManutencaoDeEstoque);
    }
}
