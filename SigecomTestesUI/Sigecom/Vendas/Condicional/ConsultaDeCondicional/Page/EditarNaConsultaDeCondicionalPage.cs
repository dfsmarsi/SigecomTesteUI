﻿using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Model;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Page
{
    public class EditarNaConsultaDeCondicionalPage: PageObjectModel
    {
        public EditarNaConsultaDeCondicionalPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDeCondicionalModel.BotaoMenuVendas);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDeCondicionalModel.BotaoSubMenu);

        public void RealizarFluxoDeAlterarCondicionalNaConsulta()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            RealizarOFluxoDeGerarCondicionalNaConsulta();
            // Act
            RealizarFluxoDeAlterarCondicional();
            // Assert
            FecharTelaDeCondicionalComEsc();
        }

        private void RealizarOFluxoDeGerarCondicionalNaConsulta()
        {
            ClicarBotaoName(ConsultaDeCondicionalModel.BotaoDaNovaCondicional);
            LancarProdutoEAtribuirCliente();
            DriverService.EditarItensNaGridComDuploClickComTab(CondicionalModel.CampoDaGridDeQuantidadeDoProduto,
                LancarItensNaCondicionalModel.QuantidadeDeProduto);
            AvancarNaCondicional();
            AvancarNaCondicional();
            DriverService.RealizarSelecaoDaAcao(CondicionalModel.AcoesDaCondicional, 2);
        }

        private void LancarProdutoEAtribuirCliente()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(ConsultaDeCondicionalModel.ElementoTelaDeCondicional);
            vendasBasePage.AbrirOAtalhoParaSelecionarCliente();
        }

        private void RealizarFluxoDeAlterarCondicional()
        {
            ClicarBotaoName(ConsultaDeCondicionalModel.BotaoDaAlterarCondicional);
            DriverService.EditarItensNaGridComDuploClickComTab(CondicionalModel.CampoDaGridDeValorUnitarioDoProduto,
                LancarItensNaCondicionalModel.ValorUnitarioParaEditarCondicional);
            AvancarNaCondicional();
            AvancarNaCondicional();
            DriverService.RealizarSelecaoDaAcao(CondicionalModel.AcoesDaCondicional, 2);
        }

        private void AvancarNaCondicional()
            => ClicarBotaoName(CondicionalModel.ElementoNameDoAvancar);

        private void FecharTelaDeCondicionalComEsc() =>
            DriverService.FecharJanelaComEsc(ConsultaDeCondicionalModel.ElementoTelaDeCondicional);
    }
}
