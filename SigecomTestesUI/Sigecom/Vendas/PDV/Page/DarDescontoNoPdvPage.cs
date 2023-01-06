using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using System;
using System.Threading;
using NUnit.Framework;
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
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.ElementoPesquisaDeProduto, LancarItemNoPdvModel.PesquisarItemId, Keys.Enter);
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
            DriverService.ClicarBotaoId(PdvModel.BotaoDeFecharPerguntaDeImpressaoPdv);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ClicarBotaoName(PdvModel.AtalhoDoPdv);
            ClicarBotaoName(PdvModel.AtalhoDeSairDoPdv);
        }
    }
}
