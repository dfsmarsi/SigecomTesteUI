using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Page
{
    public class AplicarDescontoNoOrcamentoPage: PageObjectModel
    {
        public AplicarDescontoNoOrcamentoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
           AcessarOpcaoMenu(OrcamentoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(OrcamentoModel.BotaoSubMenu);

        public void RealizarFluxoDeAplicarDescontoNoOrcamento()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto();
            DriverService.EditarItensNaGridComDuploClickComTab(OrcamentoModel.CampoDaGridDeQuantidadeDoProduto, LancarItensNoOrcamentoModel.QuantidadeDeProduto);
            DriverService.EditarItensNaGridComDuploClickComEnter(OrcamentoModel.CampoDaGridDeDescontoDoProduto, LancarItensNoOrcamentoModel.DescontoNoItemOrcamento);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(OrcamentoModel.CampoDaGridDeTotalDoProduto), LancarItensNoOrcamentoModel.ItemComDescontoNoOrcamento);
            AvancarNaOrcamento();
            AvancarNaOrcamento();
            DriverService.RealizarSelecaoDaAcao(OrcamentoModel.AcoesDoOrcamento, 2);
            FecharTelaDeOrcamentoComEsc();
        }

        private void LancarProduto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda();
        }

        private void AvancarNaOrcamento()
            => ClicarBotaoName(OrcamentoModel.ElementoNameDoAvancar);

        private void FecharTelaDeOrcamentoComEsc() =>
            DriverService.FecharJanelaComEsc(OrcamentoModel.ElementoTelaDeOrcamento);
    }
}
