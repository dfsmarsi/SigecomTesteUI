using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class LancarItensNoPdvPage : PageObjectModel
    {
        public LancarItensNoPdvPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PdvModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PdvModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarItemNoPdv()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarItemNoPedido();
            PagarPedido();
            SelecionarFormaDePagamento();
            ConcluirPedido();
            FecharTelaDeVendaComEsc();
        }

        private void SelecionarFormaDePagamento() =>
            DriverService.RealizarAcaoDaTeclaDeAtalho(PdvModel.ElementoTelaDePdv, Keys.Enter);

        private void PagarPedido() =>
            ClicarBotao(PdvModel.PagarPedido);

        private void ConcluirPedido() =>
            ClicarBotao(PdvModel.PagarPedido);

        public void LancarItemNoPedido() => 
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.PesquisaDeProduto, LancarItemNoPdvModel.PesquisarItem, Keys.Enter);

        private void FecharTelaDeVendaComEsc() =>
            DriverService.FecharJanelaComEsc(PdvModel.ElementoTelaDePdv);
    }
}
