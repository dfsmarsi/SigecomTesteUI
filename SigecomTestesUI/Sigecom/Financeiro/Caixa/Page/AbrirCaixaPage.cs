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
            DriverService.RealizarAcaoDaTeclaDeAtalhoCtrlAltCombinadaNaTela("SIGECOM - Sistema de Gestão Comercial - SISTEMASBR", "c");
            DriverService.SelecionarItemComboBox("lookUpEditCaixa", 3);
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.SelecionarItensDoDropDown(1);

            // Act
            ClicarBotaoName(CaixaModel.BotaoDeAbrirCaixa);
            ClicarBotaoName(CaixaModel.Confirmar);
            DriverService.TrocarJanela();
            ClicarBotaoName(CaixaModel.Sim);
            ClicarBotaoName(CaixaModel.BotaoDeFecharCaixa);
            DriverService.TrocarJanela();
            ClicarBotaoName(CaixaModel.Confirmar);
            ClicarBotaoName(CaixaModel.Sim);
            DriverService.TrocarJanela();
            ClicarBotaoName(CaixaModel.Nao);

            // Assert
            DriverService.VerificarSePossuiOValorNaTela(CaixaModel.BotaoDeAbrirCaixa);
            DriverService.TrocarJanela();
            FecharTelaDeAbrirCaixaComEsc();
        }

        private void FecharTelaDeAbrirCaixaComEsc() =>
            DriverService.FecharJanelaComEsc(CaixaModel.ElementoTelaDeCaixa);
    }
}
