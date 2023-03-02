using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Model;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Model;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page
{
    public class LancarContaAvulsaDaContaAPagarPage:PageObjectModel
    {
        public LancarContaAvulsaDaContaAPagarPage(DriverService driver) : base(driver)
        {
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
            RealizarFluxoDeGerarContaAPagar();

            // Assert
            var posicao = DriverService.RetornarPosicaoDoRegistroDesejado("Saldo", "R$6,68");
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Saldo", posicao.ToString()), "R$6,68");
            VerificarValorDoSaldoNaPosicao(posicao + 1);
            VerificarValorDoSaldoNaPosicao(posicao + 2);
            FecharTelaDeLancarContaAvulsaContaAPagarComEsc();
        }

        private void RealizarFluxoDeGerarContaAPagar()
        {
            ClicarBotaoName(ContaAReceberModel.BotaoDeNovaConta);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(LancarContaAvulsaModel.ElementoCampoDePlanoConta, "Acerto de caixa", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(LancarContaAvulsaModel.ElementoCampoDePessoa, "FORNECEDOR", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaModel.ElementoCampoDeHistorico, "", Keys.Enter);
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeValor, "20");
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeQuantidadeDeParcelas, "3");
            ClicarBotaoName(LancarContaAvulsaModel.Gravar);
        }

        private void VerificarValorDoSaldoNaPosicao(int posicao) =>
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Saldo", posicao.ToString()), "R$6,66");

        private void FecharTelaDeLancarContaAvulsaContaAPagarComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAPagarModel.ElementoTelaDeContaPagar);
    }
}
