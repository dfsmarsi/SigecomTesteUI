using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Model;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Model;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Model;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Page
{
    public class GerarPreVendaFaturandoNaConsultaDeOrcamentoPage: PageObjectModel
    {
        public GerarPreVendaFaturandoNaConsultaDeOrcamentoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDeOrcamentoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDeOrcamentoModel.BotaoSubMenu);

        public void RealizarFluxoDeGerarPreVendaFaturandoNaConsultaDoOrcamento()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            RealizarOFluxoDeGerarOrcamentoNaConsulta();
            EsperarAcaoEmSegundos(2);
            RealizarOFluxoDeGerarPreVenda();
            DriverService.TrocarJanela();
            VerificarSePreVendaFoiFaturadaDoOrcamento();
        }

        private void RealizarOFluxoDeGerarOrcamentoNaConsulta()
        {
            ClicarBotaoName(ConsultaDeOrcamentoModel.BotaoDaNovaOrcamento);
            LancarProduto();
            AvancarNoOrcamento();
            DriverService.DigitarNoCampoId("txtObservacao", "pre-venda faturada");
            AvancarNoOrcamento();
            DriverService.RealizarSelecaoDaAcao(OrcamentoModel.AcoesDoOrcamento, 2);
        }

        private void RealizarOFluxoDeGerarPreVenda()
        {
            ClicarBotaoName(ConsultaDeOrcamentoModel.BotaoDeGerarDoOrcamento);
            DriverService.SelecionarItensDoDropDown(2);
            DriverService.TrocarJanela();
            ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);
            ClicarBotaoName(PreVendaModel.ElementoNameDoAvancar);
            DriverService.RealizarSelecaoDaAcao(PreVendaModel.AcoesDaPreVenda, 4);
            DriverService.RealizarSelecaoDaFormaDePagamento(PreVendaModel.GridDeFormaDePagamento, 1);
        }

        private void LancarProduto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(ConsultaDeOrcamentoModel.ElementoTelaDoOrcamento);
        }

        private void AvancarNoOrcamento()
            => ClicarBotaoName(OrcamentoModel.ElementoNameDoAvancar);

        private void VerificarSePreVendaFoiFaturadaDoOrcamento()
        {
            int posicaoOrcamentoNaGrid = DriverService.RetornarPosicaoDoRegistroDesejado("Observação", "pre-venda faturada");
            var dataFaturamentoOrcamento = DriverService.PegarValorDaColunaDaGridNaPosicao("Faturamento", posicaoOrcamentoNaGrid.ToString());
            Assert.IsTrue(dataFaturamentoOrcamento != "");
        }
    }
}
