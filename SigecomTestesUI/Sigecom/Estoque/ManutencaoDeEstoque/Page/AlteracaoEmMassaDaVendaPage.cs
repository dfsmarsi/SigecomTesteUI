using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Page
{
    public class AlteracaoEmMassaDaVendaPage: PageObjectModel
    {
        public AlteracaoEmMassaDaVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ManutencaoDeEstoqueModel.BotaoMenuEstoque);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ManutencaoDeEstoqueModel.BotaoSubMenu);

        public void RealizarFluxoDaAlteracaoEmMassaDaVendaNaManutencaoDeEstoque()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(PesquisaDeProdutoModel.ElementoParametroDePesquisa,
                PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto, Keys.Enter);
            var pegarValorDaColunaDaGrid = Convert.ToInt32(DriverService.PegarValorDaColunaDaGrid("Preço venda").Replace(",00", ""));
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoDeAlteracaoEmMassa);

            // Act
            DriverService.TrocarJanela();
            const string acrescentarNoValor = "1";
            DriverService.SelecionarItemComboBox(AlteracaoEmMassaModel.ElementoDoTipoDeAlteracao, 1);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(AlteracaoEmMassaModel.ElementoDoValorDaVenda, acrescentarNoValor, Keys.Enter);
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoConfirmar);
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoSim);
            DriverService.TrocarJanela();
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoSim);

            // Assert
            DriverService.TrocarJanela();
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Preço venda"), SomarValorDaVenda(pegarValorDaColunaDaGrid, acrescentarNoValor));
            FecharTelaDeManutencaoDeEstoqueComEsc();
        }

        private static string SomarValorDaVenda(int valorOriginal, string acrescentarNoValor) =>
            $"{valorOriginal + Convert.ToInt32(acrescentarNoValor)},00";

        private void FecharTelaDeManutencaoDeEstoqueComEsc() =>
            DriverService.FecharJanelaComEsc(ManutencaoDeEstoqueModel.ElementoTelaDeManutencaoDeEstoque);
    }
}
