using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.Caixa.Model;

namespace SigecomTestesUI.Sigecom.Financeiro.Caixa.Page
{
    public class AbrirCaixaPage:PageObjectModel
    {
        public AbrirCaixaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CaixaModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CaixaModel.BotaoSubMenu);

        public void RealizarFluxoDeAbrirCaixa()
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
            ClicarBotaoName(CaixaModel.BotaoDeAbrirCaixa);
            ClicarBotaoName(CaixaModel.Confirmar);
            ClicarBotaoName(CaixaModel.Sim);
            ClicarBotaoName(CaixaModel.Nao);
            DriverService.VerificarSePossuiOValorNaTela(CaixaModel.BotaoDeFecharCaixa);

            FecharTelaDeAbrirCaixaComEsc();
        }

        private void FecharTelaDeAbrirCaixaComEsc() =>
            DriverService.FecharJanelaComEsc(CaixaModel.ElementoTelaDeCaixa);
    }
}
