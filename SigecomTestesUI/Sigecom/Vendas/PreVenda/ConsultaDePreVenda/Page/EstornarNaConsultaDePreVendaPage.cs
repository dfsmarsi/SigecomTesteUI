using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Model;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Model;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page
{
    public class EstornarNaConsultaDePreVendaPage: PageObjectModel
    {
        public EstornarNaConsultaDePreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDePreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDePreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeEstornarNaConsultaDePreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.ClicarBotaoName("Filtro (F3)");
            DriverService.DigitarNoCampoId("comboBoxEditFiltroMes", "p");
            DriverService.DigitarNoCampoId("dateEditDataInicio", "13032023");
            DriverService.DigitarNoCampoId("dateEditDataFim", "13032023");
            DriverService.ClicarBotaoName(", Filtrar");
            DriverService.CliqueNoElementoDaGridComVarios("Valor", "R$31,33");
            ClicarBotaoName(ConsultaDePreVendaModel.BotaoDaEstornarPreVenda);
            DriverService.TrocarJanela();
            ClicarBotaoName(PreVendaModel.ElementoNameDoSim);
            EsperarAcaoEmSegundos(2); 
            DriverService.TrocarJanela();
            Assert.AreNotEqual(DriverService.VerificarSePossuiOValorNaTela("R$31,33"), true);
        }
    }
}
