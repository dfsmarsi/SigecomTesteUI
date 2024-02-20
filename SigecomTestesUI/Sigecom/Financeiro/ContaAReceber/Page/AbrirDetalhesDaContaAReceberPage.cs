using NUnit.Framework;
using SigecomTestesUI.Config;
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
            DriverService.ClicarBotaoName("Filtro");
            DriverService.DigitarNoCampoId("periodoComboBoxEdit", "p");
            DriverService.DigitarNoCampoId("txtDataInicio", "09032023");
            DriverService.DigitarNoCampoId("txtDataFim", "09032023");
            DriverService.ClicarBotaoName(", Filtrar");
            DriverService.CliqueNoElementoDaGridComVarios("Saldo", "R$6,50");

            // Act
            ClicarBotaoName(ContaAReceberModel.BotaoDeDetalhes);
            ValidarAberturaDeTela(ContaAReceberModel.ElementoTelaDeDetalhesDaConta);
            Assert.AreEqual(DriverService.ObterValorElementoId(LancarContaAvulsaModel.ElementoCampoDePrimeiroVencimento), "quinta-feira, 22 de fevereiro de 2024");
            Assert.AreEqual(DriverService.ObterValorElementoId(LancarContaAvulsaModel.ElementoCampoDePessoa), "CONSUMIDOR");
            Assert.AreEqual(DriverService.ObterValorElementoId(LancarContaAvulsaModel.ElementoCampoDeValor), "13,00");

            // Assert
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(LancarContaAvulsaModel.ElementoCampoDaGridPendencia), "Pendente");
            ClicarBotaoName(LancarContaAvulsaModel.Cancelar);
            FecharTelaDeLancarContaAvulsaContaAReceberComEsc();
        }

        private void FecharTelaDeLancarContaAvulsaContaAReceberComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAReceberModel.ElementoTelaDeContaReceber);
    }
}
