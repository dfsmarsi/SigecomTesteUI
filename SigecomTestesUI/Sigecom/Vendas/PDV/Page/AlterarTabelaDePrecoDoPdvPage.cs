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
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.PesquisaDeProduto, LancarItemNoPdvModel.PesquisarItemId, Keys.Enter);
            DriverService.ClicarBotaoId(PdvModel.TabelaDePreco);
            DriverService.SelecionarItemComboBox(PdvModel.TabelaDePreco, 1);
            
            VerificarValorDoPedidoEspecifico();
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.PesquisaDeProduto, LancarItemNoPdvModel.PesquisarItemId, Keys.Enter);
            ClicarBotao(PdvModel.TabelaDePreco);
            DriverService.SelecionarItemComboBox(PdvModel.TabelaDePreco, 2);
            PagarPedido();
            DriverService.RealizarSelecaoDaFormaDePagamento(PdvModel.GridDeFormaDePagamento, 1);
            ConcluirPedido();
            FecharTelaDeVendaComEsc();
        }

        private void VerificarValorDoPedidoEspecifico() =>
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(PdvModel.GridDoProdutos), "R$11,00");

        private void PagarPedido() =>
            ClicarBotao(PdvModel.PagarPedido);

        private void ConcluirPedido() =>
            ClicarBotao(PdvModel.ConfirmarPdv);

        private void FecharTelaDeVendaComEsc()
        {
            DriverService.ClicarBotaoId(PdvModel.BotaoDeFecharPerguntaDeImpressaoPdv);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ClicarBotao(PdvModel.AtalhoDoPdv);
            ClicarBotao(PdvModel.AtalhoDeSairDoPdv);
        }
    }
}
