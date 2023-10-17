using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Page
{
    public class EntradaAvulsaNaManutencaoDeEstoquePage: PageObjectModel
    {
        public EntradaAvulsaNaManutencaoDeEstoquePage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ManutencaoDeEstoqueModel.BotaoMenuEstoque);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ManutencaoDeEstoqueModel.BotaoSubMenu);

        public void RealizarFluxoDeEntradaAvulsaNaManutencaoDeEstoque()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(PesquisaDeProdutoModel.ElementoParametroDePesquisa,
                PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto, Keys.Enter);
            var pegarValorDaColunaDaGrid = DriverService.PegarValorDaColunaDaGrid(ManutencaoDeEstoqueModel.CampoEstoqueDaGrid);
            var valorOriginal = Convert.ToInt32(pegarValorDaColunaDaGrid.Replace(",00", ""));
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoDeEntradaAvulsa);

            // Act
            const string acrescentarNaQuantidade = "1";
            DriverService.EditarItensNaGridComDuploClickComEnter(ManutencaoDeEstoqueModel.CampoQuantidadeDaGrid, acrescentarNaQuantidade);
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoConfirmar);
            DriverService.TrocarJanela();
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoSim);
            DriverService.TrocarJanela();
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoDeFiltrar);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(PesquisaDeProdutoModel.ElementoParametroDePesquisa,
                PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto, Keys.Enter);

            // Assert
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(ManutencaoDeEstoqueModel.CampoEstoqueDaGrid), SomarValorDoEstoque(valorOriginal, acrescentarNaQuantidade));
            FecharTelaDeManutencaoDeEstoqueComEsc();
        }

        private static string SomarValorDoEstoque(int valorOriginal, string acrescentarNaQuantidade) =>
            $"{valorOriginal + Convert.ToInt32(acrescentarNaQuantidade)},00";

        private void FecharTelaDeManutencaoDeEstoqueComEsc() =>
            DriverService.FecharJanelaComEsc(ManutencaoDeEstoqueModel.ElementoTelaDeManutencaoDeEstoque);
    }
}
