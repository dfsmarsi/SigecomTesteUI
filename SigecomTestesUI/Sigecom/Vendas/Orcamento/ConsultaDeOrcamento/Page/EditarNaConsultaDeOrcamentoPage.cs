using Autofac;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Model;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Page
{
    public class EditarNaConsultaDeOrcamentoPage :PageObjectModel
    {
        public EditarNaConsultaDeOrcamentoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
           AcessarOpcaoMenu(ConsultaDeOrcamentoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDeOrcamentoModel.BotaoSubMenu);

        public void RealizarFluxoDeEditarNaConsultaDoOrcamento()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            RealizarOFluxoDeGerarOrcamentoNaConsulta();
            RealizarOFluxoDeAlterarOrcamento();
            DriverService.FecharJanelaComEsc(OrcamentoModel.ElementoTelaDeOrcamento);
        }

        private void RealizarOFluxoDeGerarOrcamentoNaConsulta()
        {
            ClicarBotaoName(ConsultaDeOrcamentoModel.BotaoDaNovaOrcamento);
            LancarProduto();
            AvancarNoOrcamento();
            AvancarNoOrcamento();
            DriverService.RealizarSelecaoDaAcao(OrcamentoModel.AcoesDoOrcamento, 2);
        }

        private void LancarProduto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda();
        }

        private void RealizarOFluxoDeAlterarOrcamento()
        {
            ClicarBotaoName(ConsultaDeOrcamentoModel.BotaoDaAlterarOrcamento);
            DriverService.EditarItensNaGridComDuploClickComTab(OrcamentoModel.CampoDaGridDeQuantidadeDoProduto,
                LancarItensNoOrcamentoModel.QuantidadeDeProduto);
            AvancarNoOrcamento();
            DriverService.SelecionarItemComboBoxSemEnter(OrcamentoModel.ElementoDeTipoDoOrcamento, 1);
            DriverService.SelecionarItemComboBoxSemEnter(OrcamentoModel.ElementoDoStatusDoOrcamento, 1);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(OrcamentoModel.ElementoDaPrevisaoDeEntrega,
                LancarItensNoOrcamentoModel.PrevisaoDeEntrega, Keys.Enter);
            DriverService.RealizarSelecaoDaAcao(OrcamentoModel.AcoesDoOrcamento, 2);
            FecharTelaDoOrcamentoComEsc();
        }

        private void AvancarNoOrcamento()
            => ClicarBotaoName(OrcamentoModel.ElementoNameDoAvancar);

        private void FecharTelaDoOrcamentoComEsc() =>
            DriverService.FecharJanelaComEsc(ConsultaDeOrcamentoModel.ElementoTelaDoOrcamento);
    }
}
