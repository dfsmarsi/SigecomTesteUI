using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Devolucao.Model;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Devolucao.Page
{
    public class RemoverItemNaDevolucaoPage: PageObjectModel
    {
        public RemoverItemNaDevolucaoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(DevolucaoModel.BotaoMenuVendas);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(DevolucaoModel.BotaoSubMenu);

        public void RealizarFluxoDeRemoverItemNaDevolucao()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto();
            ClicarBotaoName(DevolucaoModel.CampoDaGridParaRemoverProduto);
            FecharTelaDeDevolucaoComEsc();
        }

        private void LancarProduto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(DevolucaoModel.ElementoTelaDeDevolucao);
        }

        private void FecharTelaDeDevolucaoComEsc() =>
            DriverService.FecharJanelaComEsc(DevolucaoModel.ElementoTelaDeDevolucao);
    }
}
