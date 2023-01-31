using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Page
{
    public class RemoverItemDaOrdemDeServicoPage: PageObjectModel
    {
        public RemoverItemDaOrdemDeServicoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
           AcessarOpcaoMenu(OrdemDeServicoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(OrdemDeServicoModel.BotaoSubMenu);

        public void RealizarFluxoDeRemoverItemNaOrdemDeServico()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProdutoPadrao();
            ClicarBotaoName(OrdemDeServicoModel.CampoDaGridParaRemoverProduto);
            FecharTelaDeOrdemDeServicoComEsc();
        }

        private void LancarProdutoPadrao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(OrdemDeServicoModel.ElementoTelaDeOrdemDeServico);
        }

        private void FecharTelaDeOrdemDeServicoComEsc() =>
            DriverService.FecharJanelaComEsc(OrdemDeServicoModel.ElementoTelaDeOrdemDeServico);
    }
}
