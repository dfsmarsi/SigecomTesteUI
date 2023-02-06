using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Page
{
    public class AplicarDescontoNaCondicionalPage: PageObjectModel
    {
        public AplicarDescontoNaCondicionalPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CondicionalModel.BotaoMenuVendas);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CondicionalModel.BotaoSubMenu);

        public void RealizarFluxoDeAplicarDescontoNaCondicional()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProdutoEAtribuirCliente();

            // Act
            DriverService.DigitarNoCampoName(CondicionalModel.CampoDaGridDeQuantidadeDoProduto, LancarItensNaCondicionalModel.QuantidadeDeProduto);
            DriverService.EditarItensNaGridComDuploClickComTab(CondicionalModel.CampoDaGridDeDescontoDoProduto, LancarItensNaCondicionalModel.DescontoNoItemCondicional);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(CondicionalModel.CampoDaGridDeTotalDoProduto), LancarItensNaCondicionalModel.ItemComDescontoNaCondicional);

            // Assert
            AvancarNaCondicional();
            AvancarNaCondicional();
            DriverService.RealizarSelecaoDaAcao(CondicionalModel.AcoesDaCondicional, 2);
            FecharTelaDeCondicionalComEsc();
        }

        private void LancarProdutoEAtribuirCliente()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(CondicionalModel.ElementoTelaDeCondicional);
            vendasBasePage.AbrirOAtalhoParaSelecionarCliente();
        }

        private void AvancarNaCondicional()
            => ClicarBotaoName(CondicionalModel.ElementoNameDoAvancar);

        private void FecharTelaDeCondicionalComEsc() =>
            DriverService.FecharJanelaComEsc(CondicionalModel.ElementoTelaDeCondicional);
    }
}
