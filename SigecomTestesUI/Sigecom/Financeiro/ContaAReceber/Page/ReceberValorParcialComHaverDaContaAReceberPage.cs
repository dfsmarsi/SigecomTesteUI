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
    public class ReceberValorParcialComHaverDaContaAReceberPage:PageObjectModel
    {
        public ReceberValorParcialComHaverDaContaAReceberPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ContaAReceberModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ContaAReceberModel.BotaoSubMenu);

        public void RealizarFluxoDeReceberValorParcialComHaverNaContaAReceber()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAReceberModel.BotaoSubMenuDoReceber);

            // Act
            RealizarFluxoDeGerarContaAReceber();
            DriverService.ClicarBotaoName("Filtro");
            DriverService.DigitarNoCampoId("periodoComboBoxEdit", "p");
            DriverService.DigitarNoCampoId("cbxCriterioValor", "ig");
            DriverService.DigitarNoCampoId("txtValor", "20,22");
            DriverService.ClicarBotaoName(", Filtrar");
            DriverService.CliqueNoElementoDaGridComVarios("Saldo", "R$20,22");
            ClicarBotaoName(ContaAReceberModel.BotaoDeReceber);
            DriverService.SelecionarItensDoDropDown(1);
            DriverService.RealizarSelecaoDaFormaDePagamentoSemEnter(ContaAReceberModel.ElementoDeFormaDePagamento, 5);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(ContaAReceberModel.ElementoDoTotalPago, "10,00", Keys.Enter);
            ClicarBotaoName(ContaAReceberModel.ParcialDoPagarConta);
            DriverService.TrocarJanela();
            ClicarBotaoName(ContaAReceberModel.Sim);
            DriverService.TrocarJanela();
            ClicarBotaoName(ContaAReceberModel.Nao);
            DriverService.TrocarJanela();
            DriverService.ClicarBotaoName(", Limpar");
            DriverService.DigitarNoCampoId("periodoComboBoxEdit", "p");
            DriverService.DigitarNoCampoId("cbxCriterioValor", "ig");
            DriverService.DigitarNoCampoId("txtValor", "10,22");
            DriverService.ClicarBotaoName(", Filtrar");
            Assert.AreEqual(DriverService.VerificarSePossuiOValorNaGrid("Saldo", "R$10,22"), true);
            FecharTelaDeContaAReceberComEsc();

            // Assert
            ClicarNaOpcaoDoSubMenu();
            DriverService.SelecionarItensDoDropDown(2);
            Assert.AreEqual(DriverService.VerificarSePossuiOValorNaGrid("Valor pago", "R$0,00"), true);
            FecharTelaDeContasRecebidasComEsc();
        }

        private void RealizarFluxoDeGerarContaAReceber()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var contaBasePage = beginLifetimeScope.Resolve<Func<DriverService, IContaBasePage>>()(DriverService);
            contaBasePage.RealizarFluxoDeGerarContaAReceberComHaver("20,22", ContaAReceberModel.NumeroDocumentoContaRecebimentoParcialComHaver);
        }

        private void FecharTelaDeContaAReceberComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAReceberModel.ElementoTelaDeContaReceber);

        private void FecharTelaDeContasRecebidasComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAReceberModel.ElementoTelaDeContaRecebidas);
    }
}
