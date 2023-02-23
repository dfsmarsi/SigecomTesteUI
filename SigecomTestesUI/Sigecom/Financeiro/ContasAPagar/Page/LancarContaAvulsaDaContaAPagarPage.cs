using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Interfaces;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Model;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page
{
    public class LancarContaAvulsaDaContaAPagarPage:PageObjectModel
    {
        private readonly IContaBasePage _contaBasePage;
        public LancarContaAvulsaDaContaAPagarPage(DriverService driver) : base(driver)
        {
        }

        public LancarContaAvulsaDaContaAPagarPage(DriverService driver, IContaBasePage contaBasePage) : base(driver)
        {
            _contaBasePage = contaBasePage;
        }

        private void ClicarNaOpcaoDoMenu() =>
           AcessarOpcaoMenu(ContaAPagarModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarContaAvulsaNaContaAPagar()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenuDoPagar);

            // Act
            ClicarBotaoName(ContaAPagarModel.BotaoDeNovaConta);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaDaContaAReceberModel.ElementoCampoDePlanoConta, "Acerto de caixa", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaDaContaAReceberModel.ElementoCampoDeCliente, "CONSUMIDOR", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaDaContaAReceberModel.ElementoCampoDeHistorico, "", Keys.Enter);
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaDaContaAReceberModel.ElementoCampoDeValor, "10");
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaDaContaAReceberModel.ElementoCampoDeQuantidadeDeParcelas, "3");
            ClicarBotaoName(LancarContaAvulsaDaContaAReceberModel.Gravar);

            // Assert
            var posicao = DriverService.RetornarPosicaoDoRegistroDesejado("Saldo", "R$3,34");
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Saldo", posicao.ToString()), "R$3,34");
            VerificarValorDoSaldoNaPosicao(posicao + 1);
            VerificarValorDoSaldoNaPosicao(posicao + 2);
            FecharTelaDeLancarContaAvulsaContaAPagarComEsc();
        }

        private void VerificarValorDoSaldoNaPosicao(int posicao) =>
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Saldo", posicao.ToString()), "R$3,33");

        private void FecharTelaDeLancarContaAvulsaContaAPagarComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAPagarModel.ElementoTelaDeContaPagar);
    }
}
