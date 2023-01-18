using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Model;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Model;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page
{
    public class ClonarNaConsultaDePreVendaPage: PageObjectModel
    {
        public ClonarNaConsultaDePreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDePreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDePreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeClonarNaConsultaDePreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoName(ConsultaDePreVendaModel.BotaoDaClonarPreVenda);
            DriverService.EditarItensNaGridComDuploClick(PreVendaModel.CampoDaGridDeValorUnitarioDoProduto, PreVendaModel.ValorTotalParaClonarPreVenda);
            DriverService.EditarItensNaGridComDuploClick(PreVendaModel.CampoDaGridDeDescontoDoProduto, PreVendaModel.DescontoParaClonarPreVenda);

            AvancarPreVenda();
            AvancarPreVenda();
            DriverService.RealizarSelecaoDaAcao(PreVendaModel.AcoesDaPreVenda, 2);
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.GridDeFormaDePagamento, 1);
            DriverService.CliqueNoElementoDaGridComVariosEVerificar(PreVendaModel.CampoDaGridDeValorTotalDaTelaDeConsultaDePreVenda, PreVendaModel.VerificarValorTotalParaClonarPreVenda);
        }

        private void AvancarPreVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);
    }
}
