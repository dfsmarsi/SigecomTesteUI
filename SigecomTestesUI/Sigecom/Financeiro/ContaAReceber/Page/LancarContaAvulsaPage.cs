using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page
{
    public class LancarContaAvulsaPage:PageObjectModel
    {
        public LancarContaAvulsaPage(DriverService driver) : base(driver)
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
            DriverService.SelecionarItensDoDropDown(1);

            // Act
            ClicarBotaoName(ContaAReceberModel.BotaoDeNovaConta);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaModel.ElementoCampoDePlanoConta, "Acerto de caixa", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaModel.ElementoCampoDeCliente, "CONSUMIDOR", Keys.Enter);
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeValor, "1");
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeQuantidadeDeParcelas, "3");

            // Assert
            var posicao = DriverService.RetornarPosicaoDoRegistroDesejado("Saldo", "R$3,34");
            
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Saldo", posicao.ToString()), "R$3,34");
            //var novaPosicao = posicao + 1;
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Saldo", posicao + 1.ToString()), "R$3,33");
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Saldo", posicao + 1.ToString()), "R$3,33");

            FecharTelaDeLancarContaAvulsaContaAReceberComEsc();
        }

        private void FecharTelaDeLancarContaAvulsaContaAReceberComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAReceberModel.ElementoTelaDeConta);
    }
}
