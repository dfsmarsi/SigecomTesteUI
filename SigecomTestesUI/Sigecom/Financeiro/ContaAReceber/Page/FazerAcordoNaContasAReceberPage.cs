using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Interfaces;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page
{
    public class FazerAcordoNaContasAReceberPage:PageObjectModel
    {
        public FazerAcordoNaContasAReceberPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ContaAReceberModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ContaAReceberModel.BotaoSubMenu);

        public void RealizarFluxoDeFazerAcordoNaContaAReceber()
        {
            // Arange
            var dataVencimento = DateTime.Now.ToString("dd/MM/yyyy");

            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAReceberModel.BotaoSubMenuDoReceber);
            DriverService.ClicarBotaoName("Filtro");
            DriverService.DigitarNoCampoId("periodoComboBoxEdit", "p");
            DriverService.DigitarNoCampoId("txtDataInicio", "16042023");
            DriverService.DigitarNoCampoId("txtDataFim", "16042023");
            DriverService.ClicarBotaoName(", Filtrar");

            // Act
            DriverService.CliqueNoElementoDaGridComVarios("Saldo", "R$22,11");
            ClicarBotaoName(ContaAReceberModel.BotaoDeAcordo);
            ClicarBotaoName(ContaAReceberModel.Avançar);
            ClicarBotaoName(ContaAReceberModel.ConcluirDoAcordo);
            EsperarAcaoEmSegundos(2);
            DriverService.TrocarJanela();
            ClicarBotaoName("Saída");

            // Assert
            DriverService.ClicarBotaoName(", Limpar");
            DriverService.DigitarNoCampoComTeclaDeAtalhoId("tipoDaDataLookUpEdit", "Lançamento", Keys.Enter);
            DriverService.DigitarNoCampoId("txtDataInicio", dataVencimento);
            DriverService.DigitarNoCampoId("txtDataFim", dataVencimento);
            DriverService.DigitarNoCampoId("cbxCriterioValor", "ig");
            DriverService.DigitarNoCampoId("txtValor", "22,11");
            DriverService.ClicarBotaoName(", Filtrar");
            var posicao = DriverService.RetornarPosicaoDoRegistroDesejado("Saldo", "R$22,11");
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Parcela", posicao.ToString()), "A-1/1");
            FecharTelaDeContaAReceberComEsc();
        }

        private void FecharTelaDeContaAReceberComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAReceberModel.ElementoTelaDeContaReceber);
    }
}
