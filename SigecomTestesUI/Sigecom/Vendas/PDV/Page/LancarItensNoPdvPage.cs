﻿using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using System;
using System.Threading;
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
            LancarProdutoPadrao();
            PagarPedido();
            DriverService.RealizarSelecaoDaFormaDePagamento(PdvModel.GridDeFormaDePagamento, 1); 
            FecharTelaDoPdv();
        }

        private void LancarProdutoPadrao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutosNaVenda(PdvModel.ElementoTelaDePdv);
        }

        private void PagarPedido() =>
            ClicarBotaoName(PdvModel.ElementoNamePagarPedido);

        private void FecharTelaDoPdv()
        {
            EsperarAcaoEmSegundos(3);
            DriverService.FecharJanelaComEscId("scProdutos");
        }
    }
}
