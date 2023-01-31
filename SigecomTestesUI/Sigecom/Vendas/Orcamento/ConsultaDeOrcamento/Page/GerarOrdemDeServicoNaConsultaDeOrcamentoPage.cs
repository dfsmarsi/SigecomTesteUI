using System;
using Autofac;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Model;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Model;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Page
{
    public class GerarOrdemDeServicoNaConsultaDeOrcamentoPage: PageObjectModel
    {
        public GerarOrdemDeServicoNaConsultaDeOrcamentoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDeOrcamentoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDeOrcamentoModel.BotaoSubMenu);

        public void RealizarFluxoDeGerarOrdemDeServicoNaConsultaDoOrcamento()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            RealizarOFluxoDeGerarOrcamentoNaConsulta();
            RealizarOFluxoDeGerarOrdemDeServico();
            FecharTelaDoOrcamentoComEsc();
        }

        private void RealizarOFluxoDeGerarOrcamentoNaConsulta()
        {
            ClicarBotaoName(ConsultaDeOrcamentoModel.BotaoDaNovaOrcamento);
            LancarProduto();
            AvancarNoOrcamento();
            AvancarNoOrcamento();
            DriverService.RealizarSelecaoDaAcao(OrcamentoModel.AcoesDoOrcamento, 2);
        }

        private void RealizarOFluxoDeGerarOrdemDeServico()
        {
            ClicarBotaoName(ConsultaDeOrcamentoModel.BotaoDeGerarDoOrcamento);
            ClicarBotaoName(ConsultaDeOrcamentoModel.BotaoDeGerarOrdemDeServicoDoOrcamento);
            ClicarBotaoName(OrdemDeServicoModel.BotaoAtalhosOrdemDeServico);
            ClicarBotaoName(OrdemDeServicoModel.AtalhoDePesquisarObjetoDaOrdemDeServico);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastrarObjetoModel.ElementoDoObjeto,
                CadastrarObjetoModel.ValorDoObjeto, Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(CadastrarObjetoModel.ElementoDoCampoDePesquisa,
                CadastrarObjetoModel.ValorDoObjeto, Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastrarObjetoModel.ElementoDaMarca,
                CadastrarObjetoModel.ValorDaMarca, Keys.Enter);
            ClicarBotaoName(OrdemDeServicoModel.ElementoNameDoCadastrar);
            ClicarBotaoName(OrdemDeServicoModel.ElementoNameDoConfirmarDoPesquisar);
            ClicarBotaoName(OrdemDeServicoModel.ElementoNameDoAvancar);
            DriverService.SelecionarItemComboBoxSemEnter(OrdemDeServicoModel.ElementoDeTipoDaOrdemDeServico, 1);
            DriverService.SelecionarItemComboBox(OrdemDeServicoModel.ElementoDoStatusDaOrdemDeServico, 1);
            DriverService.RealizarSelecaoDaAcao(OrdemDeServicoModel.AcoesDaOrdemDeServico, 2);
        }

        private void LancarProduto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(ConsultaDeOrcamentoModel.ElementoTelaDoOrcamento);
        }

        private void AvancarNoOrcamento()
            => ClicarBotaoName(OrcamentoModel.ElementoNameDoAvancar);

        private void FecharTelaDoOrcamentoComEsc() =>
            DriverService.FecharJanelaComEsc(ConsultaDeOrcamentoModel.ElementoTelaDoOrcamento);
    }
}
