using System;
using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Interfaces;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Model;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page
{
    public class ReceberValorParcialDaContaAReceberPage:PageObjectModel
    {
        public ReceberValorParcialDaContaAReceberPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ContaAReceberModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ContaAReceberModel.BotaoSubMenu);

        public void RealizarFluxoDeReceberValorParcialNaContaAReceber()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAReceberModel.BotaoSubMenuDoReceber);

            // Act
            RealizarFluxoDeGerarContaAReceber();
            DriverService.CliqueNoElementoDaGridComVarios("Saldo", "R$22,11");
            ClicarBotaoName(ContaAReceberModel.BotaoDeReceber);
            DriverService.SelecionarItensDoDropDown(1);
            DriverService.RealizarSelecaoDaFormaDePagamentoSemEnter(ContaAReceberModel.ElementoDeFormaDePagamento, 1);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(ContaAReceberModel.ElementoDoTotalPago, "10,11", Keys.Enter);
            ClicarBotaoName(ContaAReceberModel.ParcialDoPagarConta);
            ClicarBotaoName(ContaAReceberModel.Sim);
            Assert.AreEqual(DriverService.VerificarSePossuiOValorNaGrid("Saldo", "R$12,00"), true);
            FecharTelaDeContaAReceberComEsc();

            // Assert
            ClicarNaOpcaoDoSubMenu();
            DriverService.SelecionarItensDoDropDown(2);
            Assert.AreEqual(DriverService.VerificarSePossuiOValorNaGrid("Valor pago", "R$10,11"), true);
            FecharTelaDeContasRecebidasComEsc();
        }

        private void RealizarFluxoDeGerarContaAReceber()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var contaBasePage = beginLifetimeScope.Resolve<Func<DriverService, IContaBasePage>>()(DriverService);
            contaBasePage.RealizarFluxoDeGerarContaAReceber("22,11");
        }

        private void FecharTelaDeContaAReceberComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAReceberModel.ElementoTelaDeContaReceber);

        private void FecharTelaDeContasRecebidasComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAReceberModel.ElementoTelaDeContaRecebidas);
    }
}
