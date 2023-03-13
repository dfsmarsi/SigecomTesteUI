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
    public class AlterarTabelaDePrecoDoPdvPage: PageObjectModel
    {
        public AlterarTabelaDePrecoDoPdvPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PdvModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PdvModel.BotaoSubMenu);

        public void RealizarFluxoDeAlterarTabelaDePrecoNoPdv()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProdutoPadrao();
            DriverService.SelecionarItemComboBoxSemEnter(PdvModel.ElementoTabelaDePreco, 3);
            VerificarValorDaTabelaDoPrimeiroProduto();
            DriverService.SelecionarItemComboBoxSemEnter(PdvModel.ElementoTabelaDePreco, 1);
            VerificarValorDaTabelaDoPrimeiroProduto();
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.ElementoPesquisaDeProduto, LancarItemNoPdvModel.PesquisarItemIdDoSegundoProduto, Keys.Enter);
            VerificarValorDaTabelaDoSegundoProduto();
            PagarPedido();
            DriverService.RealizarSelecaoDaFormaDePagamento(PdvModel.GridDeFormaDePagamento, 1);
            ConcluirPedido();
            FecharTelaDeVendaComEsc();
        }

        private void LancarProdutoPadrao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(PdvModel.ElementoTelaDePdv);
        }

        private void VerificarValorDaTabelaDoPrimeiroProduto() => 
            VerificarValorDaTabelaDePreco(LancarItemNoPdvModel.ValorUnitarioDoPrimeiroProdutoNoPdv);

        private void VerificarValorDaTabelaDoSegundoProduto() =>
            VerificarValorDaTabelaDePreco(LancarItemNoPdvModel.ValorUnitarioDoSegundoProdutoNoPdv);

        private void VerificarValorDaTabelaDePreco(string valorUnitario)
        {
            ClicarBotaoName(PdvModel.AtalhoDoPdv);
            ClicarBotaoName(PdvModel.AtalhoDeEditarItemDoPdv);
            Assert.AreEqual(DriverService.ObterValorElementoId(PdvModel.ElementoDeEditarValor), valorUnitario);
            ClicarBotaoName(PdvModel.ElementoNameDoConfirmar);
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
