using System;
using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Model;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Model;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page
{
    public class DetalhesNaConsultaDePreVendaPage: PageObjectModel
    {
        public DetalhesNaConsultaDePreVendaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDePreVendaModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDePreVendaModel.BotaoSubMenu);

        public void RealizarFluxoDeDetalhesNaConsultaDePreVenda()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            RealizarOFluxoDeGerarPreVendaNaConsulta();
            DriverService.CliqueNoElementoDaGridComVarios(PreVendaModel.CampoDaGridDeValorTotalDaTelaDeConsultaDePreVenda, DetalhesNaConsultaDePreVendaModel.ValorDoValorTotalComDesconto);
            ClicarBotaoName(ConsultaDePreVendaModel.BotaoDaDetalhesPreVenda);
            DriverService.TrocarJanela();
            Assert.AreEqual(DriverService.ObterValorElementoId(DetalhesNaConsultaDePreVendaModel.ElementoDoValorDaVenda), DetalhesNaConsultaDePreVendaModel.ValorDoValorTotalComDesconto);
            Assert.AreEqual(DriverService.ObterValorElementoId(DetalhesNaConsultaDePreVendaModel.ElementoDoDesconto), DetalhesNaConsultaDePreVendaModel.ValorDoDesconto);
            FecharTelaDeDetalhesDaPreVenda();  
        }

        private void RealizarOFluxoDeGerarPreVendaNaConsulta()
        {
            ClicarBotaoName(ConsultaDePreVendaModel.BotaoDaNovaPreVenda);
            LancarProduto();
            DriverService.EditarItensNaGridComDuploClickComTab(PreVendaModel.CampoDaGridDeValorUnitarioDoProduto,
                DetalhesNaConsultaDePreVendaModel.ValorTotalParaVerificarDetalhes);
            DriverService.EditarItensNaGridComDuploClickComTab(PreVendaModel.CampoDaGridDeDescontoDoProduto,
                DetalhesNaConsultaDePreVendaModel.DescontoParaVerificarDetalhes);
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

        private void AvancarNaPreVenda()
            => ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);

        private void FecharTelaDeDetalhesDaPreVenda()
            => DriverService.FecharJanelaComEsc(DetalhesNaConsultaDePreVendaModel.TelaDeDetalhesPreVenda);
    }
}
