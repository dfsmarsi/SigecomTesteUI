using System;
using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Interfaces;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Model;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page
{
    public class AbrirDetalhesDaContaAReceberPage: PageObjectModel
    {
        public AbrirDetalhesDaContaAReceberPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ContaAReceberModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ContaAReceberModel.BotaoSubMenu);

        public void RealizarFluxoDeAbrirDetalhesDaContaNaContaAReceber()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAReceberModel.BotaoSubMenuDoReceber);
            RealizarFluxoDeGerarContaAReceber();
            DriverService.CliqueNoElementoDaGridComVarios("Saldo", "R$13,00");

            // Act
            ClicarBotaoName(ContaAReceberModel.BotaoDeDetalhes);
            ValidarAberturaDeTela(ContaAReceberModel.ElementoTelaDeDetalhesDaConta);
            Assert.AreEqual(DriverService.ObterValorElementoId(LancarContaAvulsaModel.ElementoCampoDePrimeiroVencimento), "quinta-feira, 22 de fevereiro de 2024");
            Assert.AreEqual(DriverService.ObterValorElementoId(LancarContaAvulsaModel.ElementoCampoDePessoa), "CONSUMIDOR");
            Assert.AreEqual(DriverService.ObterValorElementoId(LancarContaAvulsaModel.ElementoCampoDeValor), "R$13,00");

            // Assert
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(LancarContaAvulsaModel.ElementoCampoDaGridPendencia), "Pendente");
            ClicarBotaoName(LancarContaAvulsaModel.Cancelar);
            FecharTelaDeLancarContaAvulsaContaAReceberComEsc();
        }

        private void RealizarFluxoDeGerarContaAReceber()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var contaBasePage = beginLifetimeScope.Resolve<Func<DriverService, IContaBasePage>>()(DriverService);
            contaBasePage.RealizarFluxoDeGerarContaAReceber("13,00");
        }

        private void FecharTelaDeLancarContaAvulsaContaAReceberComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAReceberModel.ElementoTelaDeContaRecebidas);
    }
}
