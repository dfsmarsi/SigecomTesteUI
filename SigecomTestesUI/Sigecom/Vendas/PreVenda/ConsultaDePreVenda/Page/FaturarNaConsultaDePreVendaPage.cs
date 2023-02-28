using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Model;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page
{
    public class FaturarNaConsultaDePreVendaPage:PageObjectModel
    {
        public FaturarNaConsultaDePreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDePreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDePreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeFaturarNaConsultaDePreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            RealizarOFluxoDeGerarPreVendaNaConsulta();
            EsperarAcaoEmSegundos(1);
            RealizarOFaturaNaConsulta();
        }

        private void RealizarOFluxoDeGerarPreVendaNaConsulta()
        {
            ClicarBotaoName(ConsultaDePreVendaModel.BotaoDaNovaPreVenda);
            LancarProduto();
            DriverService.EditarItensNaGridComDuploClickComTab(PreVendaModel.CampoDaGridDeValorUnitarioDoProduto,
                LancarItemNaPreVendaModel.ValorTotalParaFaturarPreVenda);
            AvancarNaPreVenda();
            AvancarNaPreVenda();
            DriverService.RealizarSelecaoDaAcao(PreVendaModel.AcoesDaPreVenda, 2);
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.GridDeFormaDePagamento, 1);
        }

        private void LancarProduto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(PreVendaModel.ElementoTelaDePreVenda);
        }

        private void RealizarOFaturaNaConsulta()
        {
            DriverService.CliqueNoElementoDaGridComVariosEVerificar(
                PreVendaModel.CampoDaGridDeValorTotalDaTelaDeConsultaDePreVenda,
                LancarItemNaPreVendaModel.VerificarValorTotalParaFaturarPreVenda);
            ClicarBotaoName(ConsultaDePreVendaModel.BotaoDaFaturarPreVenda);
            AvancarNaPreVenda();
            AvancarNaPreVenda();
            AvancarNaPreVenda();
            DriverService.RealizarSelecaoDaAcao(PreVendaModel.AcoesDaPreVenda, 2);
            AvancarNaPreVenda();
            Assert.AreEqual(DriverService.VerificarSePossuiOValorNaTela("R$40,00"), false);
        }

        private void AvancarNaPreVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);
    }
}
