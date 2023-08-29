using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Model;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page
{
    public class EstornarContaPagaPage:PageObjectModel
    {
        public EstornarContaPagaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ContaAPagarModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenu);

        public void RealizarFluxoDeEstornarContaPaga()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.SelecionarItensDoDropDown(2);
            DriverService.ClicarBotaoName("Filtro");
            DriverService.DigitarNoCampoId("periodoComboBoxEdit", "p");
            DriverService.DigitarNoCampoId("txtDataInicio", "28042023");
            DriverService.DigitarNoCampoId("txtDataFim", "28042023");
            DriverService.ClicarBotaoName(", Filtrar");

            // Act
            DriverService.CliqueNoElementoDaGridComVarios("Valor pago", "R$31,33");
            ClicarBotaoName(ContaAPagarModel.BotaoDeEstornar);
            ClicarBotaoName(ContaAPagarModel.Estornar);
            FecharTelaDeContasRecebidasComEsc();

            // Assert
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenuDoPagar);
            DriverService.ClicarBotaoName("Filtro");
            DriverService.DigitarNoCampoId("txtDataInicio", "24032023");
            DriverService.DigitarNoCampoId("txtDataFim", "24032023");
            DriverService.ClicarBotaoName(", Filtrar");
            Assert.AreEqual(DriverService.VerificarSePossuiOValorNaGrid("Saldo", "R$31,33"), true);
            FecharTelaDeContaAPagarComEsc();
        }

        private void FecharTelaDeContaAPagarComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAPagarModel.ElementoTelaDeContaPagar);

        private void FecharTelaDeContasRecebidasComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAPagarModel.ElementoTelaDeContaPagas);
    }
}
