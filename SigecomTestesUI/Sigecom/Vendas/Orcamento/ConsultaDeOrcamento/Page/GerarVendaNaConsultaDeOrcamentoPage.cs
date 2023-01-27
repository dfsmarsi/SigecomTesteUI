using System;
using Autofac;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Model;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Page
{
    public class GerarVendaNaConsultaDeOrcamentoPage: PageObjectModel
    {
        public GerarVendaNaConsultaDeOrcamentoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
           AcessarOpcaoMenu(ConsultaDeOrcamentoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDeOrcamentoModel.BotaoSubMenu);

        public void RealizarFluxoDeGerarVendaNaConsultaDoOrcamento()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            RealizarOFluxoDeGerarOrdemDeServicoNaConsulta(vendasBasePage.RetornarIdDoProduto());
            ClicarBotaoName(ConsultaDeOrcamentoModel.BotaoDeFaturarDaOrcamento);
            DriverService.RealizarSelecaoDaFormaDePagamento(OrcamentoModel.GridDeFormaDePagamento, 1);
            FecharTelaDoOrcamentoComEsc();
        }

        private void RealizarOFluxoDeGerarOrdemDeServicoNaConsulta(string idDoProduto)
        {
            ClicarBotaoName(ConsultaDeOrcamentoModel.BotaoDaNovaOrcamento);
            LancarProduto(idDoProduto);
            AvancarNoOrcamento();
            AvancarNoOrcamento();
            DriverService.RealizarSelecaoDaAcao(OrcamentoModel.AcoesDoOrcamento, 2);
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(OrcamentoModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarNoOrcamento()
            => ClicarBotaoName(OrcamentoModel.ElementoNameDoAvancar);

        private void FecharTelaDoOrcamentoComEsc() =>
            DriverService.FecharJanelaComEsc(ConsultaDeOrcamentoModel.ElementoTelaDoOrcamento);
    }
}
