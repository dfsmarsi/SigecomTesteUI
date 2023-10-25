using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Model;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Model;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page
{
    public class AbrirDetalhesDaContaAPagarPage:PageObjectModel
    {
        public AbrirDetalhesDaContaAPagarPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ContaAPagarModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenu);

        public void RealizarFluxoDeAbrirDetalhesDaContaNaContaAPagar()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenuDoPagar);
            DriverService.ClicarBotaoName("Filtro");
            DriverService.DigitarNoCampoId("periodoComboBoxEdit", "p");
            DriverService.DigitarNoCampoId("txtDataInicio", "25032023");
            DriverService.DigitarNoCampoId("txtDataFim", "25032023");
            DriverService.ClicarBotaoName(", Filtrar");
            DriverService.CliqueNoElementoDaGridComVarios("Saldo", "R$13,00");

            // Act
            ClicarBotaoName(ContaAPagarModel.BotaoDeDetalhes);
            ValidarAberturaDeTela(ContaAPagarModel.ElementoTelaDeDetalhesDaConta);
            Assert.AreEqual(DriverService.ObterValorElementoId(LancarContaAvulsaModel.ElementoCampoDePrimeiroVencimento), "sábado, 25 de março de 2023");
            Assert.AreEqual(DriverService.ObterValorElementoId(LancarContaAvulsaModel.ElementoCampoDePessoa), "FORNECEDOR");
            Assert.AreEqual(DriverService.ObterValorElementoId(LancarContaAvulsaModel.ElementoCampoDeValor), "R$13,00");

            // Assert
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(LancarContaAvulsaModel.ElementoCampoDaGridPendencia), "Pendente");
            ClicarBotaoName(LancarContaAvulsaModel.Cancelar);
            FecharTelaDeLancarContaAvulsaContaAPagarComEsc();
        }

        private void FecharTelaDeLancarContaAvulsaContaAPagarComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAPagarModel.ElementoTelaDeContaPagar);
    }
}
