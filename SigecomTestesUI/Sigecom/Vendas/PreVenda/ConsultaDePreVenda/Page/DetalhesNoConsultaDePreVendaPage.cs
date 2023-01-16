using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Model;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page
{
    public class DetalhesNoConsultaDePreVendaPage: PageObjectModel
    {
        public DetalhesNoConsultaDePreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDePreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDePreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeEditarNaConsultaDePreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoName(ConsultaDePreVendaModel.BotaoDaDetalhesPreVenda);
            Assert.AreEqual(DriverService.ObterValorElementoId(DetalhesNaConsultaDePreVendaModel.ElementoDoValorTotal), DetalhesNaConsultaDePreVendaModel.ValorDoValorTotal);
            Assert.AreEqual(DriverService.ObterValorElementoId(DetalhesNaConsultaDePreVendaModel.ElementoDoValorTotal), DetalhesNaConsultaDePreVendaModel.ValorDoValorTotal);
            FecharTelaDeDetalhesVenda();  
        }

        private void FecharTelaDeDetalhesVenda()
            => DriverService.ClicarBotaoId(DetalhesNaConsultaDePreVendaModel.BotaoDeFecharTelaDeDetalhes);
    }
}
