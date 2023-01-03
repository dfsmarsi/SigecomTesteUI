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

        internal void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PdvModel.BotaoMenuCadastro);

        internal void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PdvModel.BotaoSubMenu);

        public void RealizarFluxoDeVoltarNoPdv()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarItemNoPedido();
            PagarPedido();
            DriverService.DigitarNoCampoId(PdvModel.GridDeFormaDePagamento, "1");
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.TotalPagamento, "5", Keys.Enter);
            DriverService.DigitarNoCampoId(PdvModel.GridDeFormaDePagamento, "3");
            FecharTelaDeVendaComEsc();
        }

        internal void LancarItemNoPedido() =>
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.PesquisaDeProduto, LancarItemNoPdvModel.PesquisarItem, Keys.Enter);

        internal void PagarPedido() =>
            ClicarBotao(PdvModel.PagarPedido);

        internal void FecharTelaDeVendaComEsc()
        {
            DriverService.FecharJanelaComEsc("Pdv");
            DriverService.FecharJanelaComEsc("Pdv");
            ClicarBotao(", Sim (ENTER)");
            ClicarBotao(PdvModel.AtalhoDoPdv);
            ClicarBotao(PdvModel.AtalhoDeSairDoPdv);
            ClicarBotao(", Sim (ENTER)");
        }

    }
}
