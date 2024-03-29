﻿using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page
{
    public class EstornarContaRecebidaPage:PageObjectModel
    {
        public EstornarContaRecebidaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ContaAReceberModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ContaAReceberModel.BotaoSubMenu);

        public void RealizarFluxoDeEstornarContaRecebida()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.SelecionarItensDoDropDown(2);
            DriverService.ClicarBotaoName("Filtro");
            DriverService.DigitarNoCampoId("periodoComboBoxEdit", "p");
            DriverService.DigitarNoCampoId("txtDataInicio", "09032023");
            DriverService.DigitarNoCampoId("txtDataFim", "09032023");
            DriverService.ClicarBotaoName(", Filtrar");

            // Act
            DriverService.CliqueNoElementoDaGridComVarios("Valor pago", "R$31,33");
            ClicarBotaoName(ContaAReceberModel.BotaoDeEstornar);
            ClicarBotaoName(ContaAReceberModel.Estornar);
            FecharTelaDeContasRecebidasComEsc();

            // Assert
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAReceberModel.BotaoSubMenuDoReceber);
            DriverService.ClicarBotaoName("Filtro");
            DriverService.DigitarNoCampoId("txtDataInicio", "09032023");
            DriverService.DigitarNoCampoId("txtDataFim", "09032023");
            DriverService.ClicarBotaoName(", Filtrar");
            Assert.AreEqual(DriverService.VerificarSePossuiOValorNaGrid("Saldo", "R$31,33"), true);
            FecharTelaDeContaAReceberComEsc();
        }

        private void FecharTelaDeContaAReceberComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAReceberModel.ElementoTelaDeContaReceber);

        private void FecharTelaDeContasRecebidasComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAReceberModel.ElementoTelaDeContaRecebidas);
    }
}
