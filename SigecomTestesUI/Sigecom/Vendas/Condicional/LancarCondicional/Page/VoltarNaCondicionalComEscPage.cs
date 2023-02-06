using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Page
{
    public class VoltarNaCondicionalComEscPage: PageObjectModel
    {
        public VoltarNaCondicionalComEscPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CondicionalModel.BotaoMenuVendas);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CondicionalModel.BotaoSubMenu);

        public void RealizarFluxoDeVoltarNaCondicionalComEsc()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProdutoEAtribuirCliente();
            // Act
            AvancarNaCondicional();
            AvancarNaCondicional();
            FecharTelaDeCondicionalComEsc();
            FecharTelaDeCondicionalComEsc();
            FecharTelaDeCondicionalComEsc();
            // Assert
            ClicarBotaoName(CondicionalModel.ElementoNameDoSim);
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
