using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Model;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page
{
    public class LancarContaAvulsaDaContaAReceberPage:PageObjectModel
    {
        public LancarContaAvulsaDaContaAReceberPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ContaAReceberModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ContaAReceberModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarContaAvulsaNaContaAReceber()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAReceberModel.BotaoSubMenuDoReceber);

            // Act
            RealizarFluxoDeGerarContaAReceber();

            // Assert
            var posicao = DriverService.RetornarPosicaoDoRegistroDesejado("Saldo", "R$3,34");
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Saldo", posicao.ToString()), "R$3,34");
            VerificarValorDoSaldoNaPosicao(posicao + 1);
            VerificarValorDoSaldoNaPosicao(posicao + 2);
            FecharTelaDeLancarContaAvulsaContaAReceberComEsc();
        }

        private void RealizarFluxoDeGerarContaAReceber()
        {
            ClicarBotaoName(ContaAReceberModel.BotaoDeNovaConta);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaModel.ElementoCampoDePlanoConta, "Acerto de caixa", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaModel.ElementoCampoDePessoa, "CONSUMIDOR", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaModel.ElementoCampoDeHistorico, "", Keys.Enter);
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeValor, "10");
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeQuantidadeDeParcelas, "3");
            ClicarBotaoName(LancarContaAvulsaModel.Gravar);
        }

        private void VerificarValorDoSaldoNaPosicao(int posicao) => 
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Saldo", posicao.ToString()), "R$3,33");

        private void FecharTelaDeLancarContaAvulsaContaAReceberComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAReceberModel.ElementoTelaDeContaReceber);
    }
}
