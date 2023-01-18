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
            SelecionarAcaoDaPreVenda();
            DriverService.RealizarSelecaoDaFormaDePagamentoSemEnter(PreVendaModel.GridDeFormaDePagamento, "1");
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PreVendaModel.ElementoTotalPagamento, "5", Keys.Enter);
            DriverService.RealizarSelecaoDaFormaDePagamentoSemEnter(PreVendaModel.GridDeFormaDePagamento, "3");
            FecharTelaDePreVendaComEsc();
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(PreVendaModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarPreVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);

        private void SelecionarAcaoDaPreVenda() => 
            DriverService.RealizarSelecaoDaAcao(PreVendaModel.AcoesDaPreVenda, 2);

        private void FecharTelaDePreVendaComEsc()
        {
            FecharJanelaComEsc();
            FecharJanelaComEsc();
            ClicarBotaoName(", Sim (ENTER)");
            FecharJanelaComEsc();
            FecharJanelaComEsc();
            FecharJanelaComEsc();
            ClicarBotaoName(", Sim (ENTER)");
        }

        private void FecharJanelaComEsc() => 
            DriverService.FecharJanelaComEsc(PreVendaModel.ElementoTelaDePreVenda);
    }
}
