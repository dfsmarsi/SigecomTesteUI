using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.Caixa.Model;

namespace SigecomTestesUI.Sigecom.Financeiro.Caixa.Page
{
    public class ReabrirCaixaPage:PageObjectModel
    {
        public ReabrirCaixaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CaixaModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CaixaModel.BotaoSubMenu);

        public void RealizarFluxoDeReabrirCaixa()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.SelecionarItensDoDropDown(1);

            // Act
            ClicarBotaoName(CaixaModel.BotaoDeFecharCaixa);
            DriverService.TrocarJanela();
            ClicarBotaoName(CaixaModel.Confirmar);
            ClicarBotaoName(CaixaModel.Sim);
            DriverService.TrocarJanela();
            ClicarBotaoName(CaixaModel.Nao);

            // Assert
            ClicarBotaoName(CaixaModel.BotaoDeReabrirCaixa);
            DriverService.VerificarSePossuiOValorNaTela(CaixaModel.BotaoDeFecharCaixa);
            FecharTelaDeReabrirCaixaComEsc();
        }

        private void FecharTelaDeReabrirCaixaComEsc() =>
            DriverService.FecharJanelaComEsc(CaixaModel.ElementoTelaDeCaixa);
    }
}
