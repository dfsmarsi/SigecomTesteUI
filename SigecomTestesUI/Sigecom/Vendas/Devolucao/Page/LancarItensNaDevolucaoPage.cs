using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Devolucao.Model;
using System;
using OpenQA.Selenium;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Devolucao.Page
{
    public class LancarItensNaDevolucaoPage: PageObjectModel
    {
        public LancarItensNaDevolucaoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(DevolucaoModel.BotaoMenuVendas);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(DevolucaoModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarItensNaDevolucao()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto();
            AvancarNaDevolucao();
            AvancarNaDevolucao();
            DriverService.RealizarSelecaoDaAcao(DevolucaoModel.AcoesDaDevolucao, 2);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(PesquisaDePessoaModel.ElementoParametroDePesquisa, "CLIENTE TESTE PESQUISA", Keys.Enter);
            ClicarBotaoName(DevolucaoModel.ElementoNameDoNao);
            FecharTelaDeDevolucaoComEsc();
        }

        private void LancarProduto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(DevolucaoModel.ElementoTelaDeDevolucao);
        }

        private void AvancarNaDevolucao()
            => ClicarBotaoName(DevolucaoModel.ElementoNameDoAvancar);

        private void FecharTelaDeDevolucaoComEsc() =>
            DriverService.FecharJanelaComEsc(DevolucaoModel.ElementoTelaDeDevolucao);
    }
}
