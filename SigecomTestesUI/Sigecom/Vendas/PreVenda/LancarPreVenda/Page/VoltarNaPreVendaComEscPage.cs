using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Page
{
    public class VoltarNaPreVendaComEscPage: PageObjectModel
    {
        public VoltarNaPreVendaComEscPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeVoltarNaPreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto(LancarItemNaPreVendaModel.PesquisarItem);
            AvancarPreVenda();
            AvancarPreVenda();
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.AcoesDaPreVenda, 2);
            DriverService.DigitarNoCampoId(PreVendaModel.GridDeFormaDePagamento, "1");
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PreVendaModel.ElementoTotalPagamento, "5", Keys.Enter);
            DriverService.DigitarNoCampoId(PreVendaModel.GridDeFormaDePagamento, "3");
            FecharTelaDeVendaComEsc();
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(PreVendaModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarPreVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);

        private void FecharTelaDeVendaComEsc()
        {
            DriverService.FecharJanelaComEsc(PreVendaModel.ElementoTelaDePreVenda);
            DriverService.FecharJanelaComEsc(PreVendaModel.ElementoTelaDePreVenda);
            ClicarBotaoName(", Sim (ENTER)");
            DriverService.FecharJanelaComEsc(PreVendaModel.ElementoTelaDePreVenda);
            DriverService.FecharJanelaComEsc(PreVendaModel.ElementoTelaDePreVenda);
            DriverService.FecharJanelaComEsc(PreVendaModel.ElementoTelaDePreVenda);
            ClicarBotaoName(", Sim (ENTER)");
        }
    }
}
