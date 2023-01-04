﻿using System;
using System.Threading;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class LancarItemNoPdvPage: PageObjectModel
    {
        public LancarItemNoPdvPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PdvModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PdvModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarItemNoPdv()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.PesquisaDeProduto, LancarItemNoPdvModel.PesquisarItemId, Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.PesquisaDeProduto, LancarItemNoPdvModel.PesquisarItemCodInterno, Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.PesquisaDeProduto, LancarItemNoPdvModel.PesquisarItemReferencia, Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.PesquisaDeProduto, LancarItemNoPdvModel.PesquisarItemMultiplicadorDeQuantidade, Keys.Enter);
            PagarPedido();
            DriverService.RealizarSelecaoDaFormaDePagamento(PdvModel.GridDeFormaDePagamento, 1); 
            ConcluirPedido();
            FecharTelaDeVendaComEsc();
        }

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
