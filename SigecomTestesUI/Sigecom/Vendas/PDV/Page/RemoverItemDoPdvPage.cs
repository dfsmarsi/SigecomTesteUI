using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class RemoverItemDoPdvPage: PageObjectModel
    {
        public RemoverItemDoPdvPage(DriverService driver) : base(driver)
        {
        }

        internal void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PdvModel.BotaoMenuCadastro);

        internal void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PdvModel.BotaoSubMenu);

        public void RealizarFluxoDeRemoverItemNoPdv()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.PesquisaDeProduto, LancarItemNoPdvModel.PesquisarItemId, Keys.Enter);
            DriverService.RemoverItensDaGridComBotaoDireito(PdvModel.GridDoProdutos);
            FecharTelaDeVendaComEsc();
        }

        internal void FecharTelaDeVendaComEsc()
        {
            ClicarBotao(PdvModel.AtalhoDoPdv);
            ClicarBotao(PdvModel.AtalhoDeSairDoPdv);
        }
    }
}
