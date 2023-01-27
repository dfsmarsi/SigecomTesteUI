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
    public class LancarItensNoOrcamentoPage :PageObjectModel
    {
        public LancarItensNoOrcamentoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(OrcamentoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(OrcamentoModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarItensNoOrcamento()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            var idDoProduto = vendasBasePage.RetornarIdDoProduto();
            LancarProduto(LancarItensNoOrcamentoModel.PesquisarItem);
            LancarProduto(idDoProduto);
            LancarProduto(LancarItensNoOrcamentoModel.PesquisarItemReferencia);
            LancarProduto(LancarItensNoOrcamentoModel.PesquisarItemCodInterno);
            LancarProduto($"1*{idDoProduto}");
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(OrcamentoModel.CampoDaGridDeQuantidadeDoProduto), LancarItensNoOrcamentoModel.QuantidadeDeProduto);
            AvancarNoOrcamento();
            DriverService.SelecionarItemComboBoxSemEnter(OrcamentoModel.ElementoDeTipoDoOrcamento, 1);
            DriverService.SelecionarItemComboBoxSemEnter(OrcamentoModel.ElementoDoStatusDoOrcamento, 1);
            DriverService.DigitarNoCampoId(OrcamentoModel.ElementoDaPrevisaoDeEntrega, LancarItensNoOrcamentoModel.PrevisaoDeEntrega);
            DriverService.DigitarNoCampoId(OrcamentoModel.ElementoDoPrazoDeEntrega, LancarItensNoOrcamentoModel.PrazoDeEntrega);
            DriverService.DigitarNoCampoId(OrcamentoModel.ElementoDaValidadeProposta, LancarItensNoOrcamentoModel.ValidadeProposta);
            DriverService.DigitarNoCampoId(OrcamentoModel.ElementoDaGarantiaNacional, LancarItensNoOrcamentoModel.GarantiaNacional);
            DriverService.DigitarNoCampoId(OrcamentoModel.ElementoDaFormaDePagamento, LancarItensNoOrcamentoModel.FormaDePagamento);
            DriverService.DigitarNoCampoId(OrcamentoModel.ElementoDaCondicoesDePagamento, LancarItensNoOrcamentoModel.CondicoesDePagamento);
            DriverService.DigitarNoCampoId(OrcamentoModel.ElementoDoValorFrete, LancarItensNoOrcamentoModel.ValorFrete);
            DriverService.DigitarNoCampoId(OrcamentoModel.ElementoDeObservação, LancarItensNoOrcamentoModel.Observacao);
            AvancarNoOrcamento();
            DriverService.RealizarSelecaoDaAcao(OrcamentoModel.AcoesDoOrcamento, 2);
            FecharTelaDeOrcamentoComEsc();
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(OrcamentoModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarNoOrcamento()
            => ClicarBotaoName(OrcamentoModel.ElementoNameDoAvancar);

        private void FecharTelaDeOrcamentoComEsc() =>
            DriverService.FecharJanelaComEsc(OrcamentoModel.ElementoTelaDeOrcamento);
    }
}
