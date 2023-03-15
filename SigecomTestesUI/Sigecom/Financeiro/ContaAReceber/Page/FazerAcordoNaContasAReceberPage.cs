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
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAReceberModel.BotaoSubMenuDoReceber);

            // Act
            RealizarFluxoDeGerarContaAReceber();
            DriverService.CliqueNoElementoDaGridComVarios("Saldo", "R$22,11");
            ClicarBotaoName(ContaAReceberModel.BotaoDeAcordo);
            ClicarBotaoName(ContaAReceberModel.Avançar);
            ClicarBotaoName(ContaAReceberModel.ConcluirDoAcordo);
            EsperarAcaoEmSegundos(2);
            DriverService.TrocarJanela();
            ClicarBotaoName("Saída");

            DriverService.DigitarNoCampoComTeclaDeAtalhoId("tipoDaDataLookUpEdit", "Lançamento", Keys.Enter);
            ClicarBotaoName(", Filtrar");

            // Assert
            var posicao = DriverService.RetornarPosicaoDoRegistroDesejado("Saldo", "R$22,11");
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Parcela", posicao.ToString()), "A-1/1");
            FecharTelaDeContaAReceberComEsc();
        }

        private void RealizarFluxoDeGerarContaAReceber()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var contaBasePage = beginLifetimeScope.Resolve<Func<DriverService, IContaBasePage>>()(DriverService);
            contaBasePage.RealizarFluxoDeGerarContaAReceber("22,11");
        }

        private void FecharTelaDeContaAReceberComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAReceberModel.ElementoTelaDeContaReceber);
    }
}
