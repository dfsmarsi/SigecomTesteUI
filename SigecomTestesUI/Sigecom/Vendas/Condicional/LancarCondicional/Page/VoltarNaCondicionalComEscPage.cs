using Autofac;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
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
            AcessarOpcaoMenu(CondicionalModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CondicionalModel.BotaoSubMenu);

        public void RealizarFluxoDeVoltarNaCondicionalComEsc()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var condicionalBasePage = beginLifetimeScope.Resolve<Func<DriverService, CondicionalBasePage>>()(DriverService);
            condicionalBasePage.AbrirOAtalhoParaSelecionarCliente();
            LancarProduto(condicionalBasePage.RetornarIdDoProduto());
            AvancarNaCondicional();
            AvancarNaCondicional();
            FecharTelaDeCondicionalComEsc();
            FecharTelaDeCondicionalComEsc();
            FecharTelaDeCondicionalComEsc();
            ClicarBotaoName(CondicionalModel.ElementoNameDoSim);
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(CondicionalModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarNaCondicional()
            => ClicarBotaoName(CondicionalModel.ElementoNameDoAvancar);

        private void FecharTelaDeCondicionalComEsc() =>
            DriverService.FecharJanelaComEsc(CondicionalModel.ElementoTelaDeCondicional);
    }
}
