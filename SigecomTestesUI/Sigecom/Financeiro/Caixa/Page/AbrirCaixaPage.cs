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
            DriverService.SelecionarItemComboBox(CaixaModel.BotaoSubMenuDoSub, 1);

            // Act
            


            // Assert

        }

        private void FecharTelaDeAbrirCaixaComEsc() =>
            DriverService.FecharJanelaComEsc(CaixaModel.ElementoTelaDeCaixa);
    }
}
