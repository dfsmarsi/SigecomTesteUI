using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Page
{
    public class RemoverItemDoOrcamentoPage: PageObjectModel
    {
        public RemoverItemDoOrcamentoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(OrcamentoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(OrcamentoModel.BotaoSubMenu);

        public void RealizarFluxoDeRemoverItemNoOrcamento()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto();
            ClicarBotaoName(OrcamentoModel.CampoDaGridParaRemoverProduto);
            FecharTelaDeOrcamentoComEsc();
        }

        private void LancarProduto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(OrcamentoModel.ElementoTelaDeOrcamento);
        }

        private void FecharTelaDeOrcamentoComEsc() =>
            DriverService.FecharJanelaComEsc(OrcamentoModel.ElementoTelaDeOrcamento);
    }
}
