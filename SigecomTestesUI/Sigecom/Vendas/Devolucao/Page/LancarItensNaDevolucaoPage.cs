using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Devolucao.Model;

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
            LancarProdutoEAtribuirCliente();
            AvancarNaDevolucao();
            AvancarNaDevolucao();
            DriverService.RealizarSelecaoDaAcao(DevolucaoModel.AcoesDaDevolucao, 2);
            FecharTelaDeDevolucaoComEsc();
        }

        private void LancarProdutoEAtribuirCliente()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.AbrirOAtalhoParaSelecionarCliente();
            vendasBasePage.LancarProdutoPadraoNaVenda(DevolucaoModel.ElementoTelaDeDevolucao);
        }

        private void AvancarNaDevolucao()
            => ClicarBotaoName(DevolucaoModel.ElementoNameDoAvancar);

        private void FecharTelaDeDevolucaoComEsc() =>
            DriverService.FecharJanelaComEsc(DevolucaoModel.ElementoTelaDeDevolucao);
    }
}
