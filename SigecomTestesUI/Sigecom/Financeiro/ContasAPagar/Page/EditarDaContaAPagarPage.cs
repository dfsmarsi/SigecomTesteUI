using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Interfaces;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Model;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Model;
using System;
using NUnit.Framework;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page
{
    public class EditarDaContaAPagarPage:PageObjectModel
    {
        public EditarDaContaAPagarPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ContaAPagarModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenu);

        public void RealizarFluxoDeEditarDaContaAPagar()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenuDoPagar);
            RealizarFluxoDeGerarConta();
            DriverService.ClicarBotaoName("Filtro");
            DriverService.DigitarNoCampoId("periodoComboBoxEdit", "p");
            DriverService.DigitarNoCampoId("cbxCriterioValor", "ig");
            DriverService.DigitarNoCampoId("txtValor", "2,13");
            DriverService.ClicarBotaoName(", Filtrar");
            DriverService.CliqueNoElementoDaGridComVarios("Saldo", "R$2,13");

            // Act
            ClicarBotaoName(ContaAPagarModel.BotaoDeEditar);
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeHistorico, "Teste");
            DriverService.SelecionarItemComboBox(LancarContaAvulsaModel.ElementoCampoDeTipoDocumento, 1);
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeNumeroDocumento, "1");
            EsperarAcaoEmSegundos(1);
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeValor, "1");
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeQuantidadeDeParcelas, "2");
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeDataDeVencimento, "2");
            var diaDaPrimeiraParcela = DateTime.Parse(DriverService.PegarValorDaColunaDaGrid(LancarContaAvulsaModel.ElementoCampoDaGridDataVencimento));
            ClicarBotaoName(LancarContaAvulsaModel.Recalcular);

            // Assert
            Assert.AreEqual(diaDaPrimeiraParcela.ToString("d"), DateTime.Parse(DriverService.PegarValorDaColunaDaGrid(LancarContaAvulsaModel.ElementoCampoDaGridDataVencimento)).ToString("d"));
            Assert.AreEqual(diaDaPrimeiraParcela.AddMonths(2).ToString("d"), DateTime.Parse(DriverService.PegarValorDaColunaDaGridNaPosicao(LancarContaAvulsaModel.ElementoCampoDaGridDataVencimento, "1")).ToString("d"));
            ClicarBotaoName(LancarContaAvulsaModel.Gravar);
            FecharTelaDeLancarContaAvulsaContaAPagarComEsc();
        }

        private void RealizarFluxoDeGerarConta()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<Func<DriverService,IContaBasePage>>()(DriverService).RealizarFluxoDeGerarContaAPagar("2,13");
        }

        private void FecharTelaDeLancarContaAvulsaContaAPagarComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAPagarModel.ElementoTelaDeContaPagar);
    }
}
