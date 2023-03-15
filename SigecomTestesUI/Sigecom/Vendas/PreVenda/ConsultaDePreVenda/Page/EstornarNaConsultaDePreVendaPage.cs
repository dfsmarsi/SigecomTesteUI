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
            DriverService.CliqueNoElementoDaGridComVarios("Valor", "R$31,33");
            ClicarBotaoName(ConsultaDePreVendaModel.BotaoDaEstornarPreVenda);
            ClicarBotaoName(PreVendaModel.ElementoNameDoSim);
            VerificarSeOPrimeiroRegistroFoiEliminado();
        }

        private void VerificarSeOPrimeiroRegistroFoiEliminado()
            => Assert.AreNotEqual(DriverService.PegarValorDaColunaDaGrid("Código"), 1);
    }
}
