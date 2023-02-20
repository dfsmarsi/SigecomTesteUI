using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page
{
    public class AbrirDetalhesDaContaPage: PageObjectModel
    {
        public AbrirDetalhesDaContaPage(DriverService driver) : base(driver)
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

            // Act
            ClicarBotaoName(ContaAReceberModel.BotaoDeDetalhes);
            ValidarAberturaDeTela(ContaAReceberModel.ElementoTelaDeDetalhesDaConta);
            Assert.AreEqual(DriverService.ObterValorElementoId(LancarContaAvulsaModel.ElementoCampoDePrimeiroVencimento), "quinta-feira, 22 de fevereiro de 2024");
            Assert.AreEqual(DriverService.ObterValorElementoId(LancarContaAvulsaModel.ElementoCampoDeCliente), "CONSUMIDOR");
            Assert.AreEqual(DriverService.ObterValorElementoId(LancarContaAvulsaModel.ElementoCampoDeValor), "R$13,00");

            // Assert
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(LancarContaAvulsaModel.ElementoCampoDaGridPendencia), "Pendente");
            ClicarBotaoName(LancarContaAvulsaModel.Cancelar);
            FecharTelaDeLancarContaAvulsaContaAReceberComEsc();
        }

        private void FecharTelaDeLancarContaAvulsaContaAReceberComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAReceberModel.ElementoTelaDeContaRecebidas);
    }
}
