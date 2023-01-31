using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Page
{
    public class LancarItensNaOrdemDeServicoPage: PageObjectModel
    {
        public LancarItensNaOrdemDeServicoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(OrdemDeServicoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(OrdemDeServicoModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarItensNaOrdemDeServico()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu(); 
            ClicarBotaoName(OrdemDeServicoModel.BotaoAtalhosOrdemDeServico);
            ClicarBotaoName(OrdemDeServicoModel.AtalhoDePesquisarObjetoDaOrdemDeServico);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastrarObjetoModel.ElementoDoObjeto, CadastrarObjetoModel.ValorDoObjeto, Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(CadastrarObjetoModel.ElementoDoCampoDePesquisa, CadastrarObjetoModel.ValorDoObjeto, Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastrarObjetoModel.ElementoDaMarca, CadastrarObjetoModel.ValorDaMarca, Keys.Enter);
            ClicarBotaoName(OrdemDeServicoModel.ElementoNameDoCadastrar);
            ClicarBotaoName(OrdemDeServicoModel.ElementoNameDoConfirmarDoPesquisar);
            LancarProdutoPadrao();
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(OrdemDeServicoModel.CampoDaGridDeQuantidadeDoProduto), LancarItensNaOrdemDeServicoModel.QuantidadeDeProduto);
            AvancarNaOrdemDeServico();
            DriverService.SelecionarItemComboBoxSemEnter(OrdemDeServicoModel.ElementoDeTipoDaOrdemDeServico, 1);
            DriverService.SelecionarItemComboBoxSemEnter(OrdemDeServicoModel.ElementoDoStatusDaOrdemDeServico, 1);
            DriverService.DigitarNoCampoId(OrdemDeServicoModel.ElementoDoSolicitanteDaOrdemDeServico, LancarItensNaOrdemDeServicoModel.SolicitanteDaOrdemDeServico);
            DriverService.DigitarNoCampoId(OrdemDeServicoModel.ElementoDoDefeitoDaOrdemDeServico, LancarItensNaOrdemDeServicoModel.DefeitoDaOrdemDeServico);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(OrdemDeServicoModel.ElementoDeObservação, LancarItensNaOrdemDeServicoModel.Observacao, Keys.Enter);
            DriverService.RealizarSelecaoDaAcao(OrdemDeServicoModel.AcoesDaOrdemDeServico, 2);
            FecharTelaDeOrdemDeServicoComEsc();
        }

        private void LancarProdutoPadrao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.AbrirOAtalhoParaSelecionarCliente();
            var idDoProduto = vendasBasePage.LancarProdutoPadraoNaVenda();
            LancarProduto(LancarItensNaOrdemDeServicoModel.PesquisarItem);
            LancarProduto(LancarItensNaOrdemDeServicoModel.PesquisarItemReferencia);
            LancarProduto(LancarItensNaOrdemDeServicoModel.PesquisarItemCodInterno);
            LancarProduto($"1*{idDoProduto}");
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(OrdemDeServicoModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarNaOrdemDeServico()
            => ClicarBotaoName(OrdemDeServicoModel.ElementoNameDoAvancar);

        private void FecharTelaDeOrdemDeServicoComEsc() =>
            DriverService.FecharJanelaComEsc(OrdemDeServicoModel.ElementoTelaDeOrdemDeServico);
    }
}
