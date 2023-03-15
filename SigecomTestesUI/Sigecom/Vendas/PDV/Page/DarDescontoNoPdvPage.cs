using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using System;
using System.Threading;
using Autofac;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class DarDescontoNoPdvPage: PageObjectModel
    {
        public DarDescontoNoPdvPage(DriverService driver) : base(driver)
        {
        }

        public void RealizarFluxoDeDarDescontoAoProduto()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProdutoPadrao();
            AtribuirDescontoNoProduto();
            Assert.AreEqual(DriverService.ObterValorElementoId(PdvModel.ElementoTotalParaPagar), LancarItemNoPdvModel.ItemComDescontoNoPdv);
            PagarPedido();
            DriverService.RealizarSelecaoDaFormaDePagamento(PdvModel.GridDeFormaDePagamento, 1);
            ConcluirPedido();
            FecharTelaDeVendaComEsc();
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PdvModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PdvModel.BotaoSubMenu);

        private void LancarProdutoPadrao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(PdvModel.ElementoTelaDePdv);
        }

        private void AtribuirDescontoNoProduto()
        {
            ClicarBotaoName(PdvModel.AtalhoDoPdv);
            ClicarBotaoName(PdvModel.AtalhoDeDescontoDoPdv);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.ElementoDoDesconto, LancarItemNoPdvModel.DescontoNoItemPdv, Keys.Enter);
        }

        private void PagarPedido() =>
            ClicarBotaoName(PdvModel.ElementoNamePagarPedido);

        private void ConcluirPedido() =>
            ClicarBotaoName(PdvModel.ElementoNameConfirmarPdv);

        private void FecharTelaDeVendaComEsc()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            DriverService.TrocarJanela();
            ClicarBotaoName("Saída");
            DriverService.ClicarBotaoName(PdvModel.BotaoDoNao);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ClicarBotaoName(PdvModel.AtalhoDoPdv);
            ClicarBotaoName(PdvModel.AtalhoDeSairDoPdv);
        }
    }
}
