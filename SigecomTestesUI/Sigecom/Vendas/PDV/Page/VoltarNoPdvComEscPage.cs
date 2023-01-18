using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class VoltarNoPdvComEscPage : PageObjectModel
    {
        public VoltarNoPdvComEscPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PdvModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PdvModel.BotaoSubMenu);

        public void RealizarFluxoDeVoltarNoPdv()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarItemNoPedido();
            PagarPedido();
            DriverService.DigitarNoCampoId(PdvModel.GridDeFormaDePagamento, "1");
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.ElementoTotalPagamento, "5", Keys.Enter);
            DriverService.DigitarNoCampoId(PdvModel.GridDeFormaDePagamento, "3");
            FecharTelaDeVendaComEsc();
        }

        private void LancarItemNoPedido() =>
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.ElementoPesquisaDeProduto, LancarItemNoPdvModel.PesquisarItem, Keys.Enter);

        private void PagarPedido() =>
            ClicarBotaoName(PdvModel.ElementoNamePagarPedido);

        private void FecharTelaDeVendaComEsc()
        {
            DriverService.FecharJanelaComEsc("Pdv");
            DriverService.FecharJanelaComEsc("Pdv");
            ClicarBotaoName(", Sim (ENTER)");
            ClicarBotaoName(PdvModel.AtalhoDoPdv);
            ClicarBotaoName(PdvModel.AtalhoDeSairDoPdv);
            ClicarBotaoName(", Sim (ENTER)");
        }

    }
}
