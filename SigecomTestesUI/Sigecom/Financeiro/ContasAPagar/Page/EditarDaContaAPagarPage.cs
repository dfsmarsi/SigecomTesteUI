using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Interfaces;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Model;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Model;
using System;
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
            DriverService.CliqueNoElementoDaGridComVarios("Saldo", "R$20,13");

            // Act
            ClicarBotaoName(ContaAPagarModel.BotaoDeEditar);
            //DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(LancarContaAvulsaModel.ElementoCampoDePrimeiroVencimento, "29/03/2023", Keys.Enter);
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeHistorico, "Teste");
            DriverService.SelecionarItemComboBox(LancarContaAvulsaModel.ElementoCampoDeTipoDocumento, 1);
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeNumeroDocumento, "1");
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeValor, "10,10");
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeQuantidadeDeParcelas, "2");
            ClicarBotaoName(LancarContaAvulsaModel.Gravar);

            // Assert

            FecharTelaDeLancarContaAvulsaContaAPagarComEsc();
        }

        private void RealizarFluxoDeGerarConta()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<Func<DriverService,IContaBasePage>>()(DriverService).RealizarFluxoDeGerarContaAPagar("20,13");
        }

        private void FecharTelaDeLancarContaAvulsaContaAPagarComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAPagarModel.ElementoTelaDeContaPagar);
    }
}
