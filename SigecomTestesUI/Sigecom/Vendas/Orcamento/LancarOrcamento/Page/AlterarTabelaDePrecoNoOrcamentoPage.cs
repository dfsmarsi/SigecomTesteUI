using System;
using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Page
{
    public class AlterarTabelaDePrecoNoOrcamentoPage: PageObjectModel
    {
        public AlterarTabelaDePrecoNoOrcamentoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
           AcessarOpcaoMenu(OrcamentoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(OrcamentoModel.BotaoSubMenu);

        public void RealizarFluxoDeAlterarTabelaDePrecoNoOrcamento()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto();
            DriverService.SelecionarItemComboBoxSemEnter(OrcamentoModel.ElementoDoComboDaTabelaDePreco, 3);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(OrcamentoModel.CampoDaGridDeTotalDoProduto),
                LancarItensNoOrcamentoModel.ValorUnitarioDoPrimeiroProdutoNoOrcamento);
            DriverService.SelecionarItemComboBoxSemEnter(OrcamentoModel.ElementoDoComboDaTabelaDePreco, 1);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(OrcamentoModel.CampoDaGridDeTotalDoProduto),
                LancarItensNoOrcamentoModel.ValorUnitarioDoPrimeiroProdutoNoOrcamento);
            LancarProduto(LancarItensNoOrcamentoModel.PesquisarItemIdDoSegundoProdutoNoOrcamento);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao(OrcamentoModel.CampoDaGridDeTotalDoProduto, "1"),
                LancarItensNoOrcamentoModel.ValorUnitarioDoSegundoProdutoNoOrcamento);
            AvancarNaOrcamento();
            AvancarNaOrcamento();
            DriverService.RealizarSelecaoDaAcao(OrcamentoModel.AcoesDoOrcamento, 2);
            FecharTelaDeOrcamentoComEsc();
        }

        private void LancarProduto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoNaVenda();
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(OrcamentoModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarNaOrcamento()
            => ClicarBotaoName(OrcamentoModel.ElementoNameDoAvancar);

        private void FecharTelaDeOrcamentoComEsc() =>
            DriverService.FecharJanelaComEsc(OrcamentoModel.ElementoTelaDeOrcamento);
    }
}
