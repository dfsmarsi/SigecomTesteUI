using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using System;
using System.Threading;
using NUnit.Framework;
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
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.ElementoPesquisaDeProduto, LancarItemNoPdvModel.PesquisarItemId, Keys.Enter);
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
            DriverService.ClicarBotaoId(PdvModel.BotaoDeFecharPerguntaDeImpressaoPdv);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ClicarBotaoName(PdvModel.AtalhoDoPdv);
            ClicarBotaoName(PdvModel.AtalhoDeSairDoPdv);
        }
    }
}
