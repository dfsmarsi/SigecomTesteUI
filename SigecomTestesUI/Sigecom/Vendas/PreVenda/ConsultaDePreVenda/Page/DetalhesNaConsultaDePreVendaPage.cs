using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Model;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page
{
    public class DetalhesNaConsultaDePreVendaPage: PageObjectModel
    {
        public DetalhesNaConsultaDePreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDePreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDePreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeDetalhesNaConsultaDePreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoName(ConsultaDePreVendaModel.BotaoDaDetalhesPreVenda);
            Assert.AreEqual(DriverService.ObterValorElementoId(DetalhesNaConsultaDePreVendaModel.ElementoDoValorDaVenda), DetalhesNaConsultaDePreVendaModel.ValorDoValorTotalComDesconto);
            Assert.AreEqual(DriverService.ObterValorElementoId(DetalhesNaConsultaDePreVendaModel.ElementoDoDesconto), DetalhesNaConsultaDePreVendaModel.ValorDoDesconto);
            FecharTelaDeDetalhesDaPreVenda();  
        }

        private void FecharTelaDeDetalhesDaPreVenda()
            => DriverService.ClicarBotaoId(DetalhesNaConsultaDePreVendaModel.BotaoDeFecharTelaDeDetalhes);
    }
}
