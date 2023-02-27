using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.Caixa.Model;

namespace SigecomTestesUI.Sigecom.Financeiro.Caixa.Page
{
    public class SangriaSuprimentoNoCaixaPage:PageObjectModel
    {
        public SangriaSuprimentoNoCaixaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CaixaModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CaixaModel.BotaoSubMenu);

        public void RealizarFluxoDeSangriaSuprimento()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.SelecionarItensDoDropDown(1);

            // Act
            ClicarBotaoName(CaixaModel.BotaoDeSangria);
            const string valorDaSangria = "1,11";
            DriverService.EditarCampoComDuploCliqueNoBotaoId(CaixaModel.ElementoCampoDeSangriaSuprimento, valorDaSangria);
            ClicarBotaoName(CaixaModel.Confirmar);
            ClicarBotaoName("Não");

            ClicarBotaoName(CaixaModel.BotaoDeSuprimento);
            const string valorDaSuprimento = "5,55";
            DriverService.EditarCampoComDuploCliqueNoBotaoId(CaixaModel.ElementoCampoDeSangriaSuprimento, valorDaSuprimento);
            ClicarBotaoName(CaixaModel.Confirmar);
            ClicarBotaoName("Não");


            // Assert
            Assert.AreEqual(DriverService.VerificarSePossuiOValorNaGrid("Valor", "R$10,11"), true);
            Assert.AreEqual(DriverService.VerificarSePossuiOValorNaGrid("Valor", "R$50,55"), true);
            FecharTelaDeSangriaSuprimentoComEsc();
        }

        private void FecharTelaDeSangriaSuprimentoComEsc() =>
            DriverService.FecharJanelaComEsc(CaixaModel.ElementoTelaDeCaixa);
    }
}
