using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Model;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page
{
    public class LancarContaAReceberAvulsaPage:PageObjectModel
    {
        public LancarContaAReceberAvulsaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ContaAReceberModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ContaAReceberModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarContaAReceberAvulsa()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAReceberModel.BotaoSubMenuDoReceber);

            // Act
            RealizarFluxoDeGerarContaAReceber();

            // Assert
            DriverService.CliqueNoElementoDaGridComVarios("Saldo", "R$5,00");
            DriverService.ClicarBotaoName(ContaAReceberModel.BotaoDeDetalhes);
            VerificarValorNaPosicao(0);
            VerificarValorNaPosicao(1);
            DriverService.ClicarBotaoName(", Cancelar (ESC)");
            FecharTelaDeLancarContaAvulsaContaAReceberComEsc();
        }

        private void RealizarFluxoDeGerarContaAReceber()
        {
            ClicarBotaoName(ContaAReceberModel.BotaoDeNovaConta);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(LancarContaAvulsaModel.ElementoCampoDePlanoConta, "Acerto de caixa", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(LancarContaAvulsaModel.ElementoCampoDePessoa, "CONSUMIDOR", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaModel.ElementoCampoDeHistorico, "", Keys.Enter);
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeValor, "10");
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeQuantidadeDeParcelas, "2");
            ClicarBotaoName(LancarContaAvulsaModel.Gravar);
        }

        private void VerificarValorNaPosicao(int posicao) => 
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Valor", posicao.ToString()), "R$5,00");

        private void FecharTelaDeLancarContaAvulsaContaAReceberComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAReceberModel.ElementoTelaDeContaReceber);
    }
}
