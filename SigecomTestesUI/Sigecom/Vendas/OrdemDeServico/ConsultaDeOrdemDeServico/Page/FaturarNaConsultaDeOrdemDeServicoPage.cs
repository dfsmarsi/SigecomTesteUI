using System;
using Autofac;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.ConsultaDeOrdemDeServico.Model;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.ConsultaDeOrdemDeServico.Page
{
    public class FaturarNaConsultaDeOrdemDeServicoPage: PageObjectModel
    {
        public FaturarNaConsultaDeOrdemDeServicoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDeOrdemDeServicoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDeOrdemDeServicoModel.BotaoSubMenu);

        public void RealizarFluxoDeFaturarNaConsultaDaOrdemDeServico()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            RealizarOFluxoDeGerarOrdemDeServicoNaConsulta();
            RealizarFluxoDeFaturarDaOrdemDeServico();
            DriverService.FecharJanelaComEsc(OrdemDeServicoModel.ElementoTelaDeOrdemDeServico);
        }

        private void RealizarOFluxoDeGerarOrdemDeServicoNaConsulta()
        {
            ClicarBotaoName(ConsultaDeOrdemDeServicoModel.BotaoDaNovaOrdemDeServico);
            ClicarBotaoName(OrdemDeServicoModel.BotaoAtalhosOrdemDeServico);
            ClicarBotaoName(OrdemDeServicoModel.AtalhoDePesquisarObjetoDaOrdemDeServico);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastrarObjetoModel.ElementoDoObjeto, CadastrarObjetoModel.ValorDoObjeto, Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(CadastrarObjetoModel.ElementoDoCampoDePesquisa, CadastrarObjetoModel.ValorDoObjeto, Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastrarObjetoModel.ElementoDaMarca, CadastrarObjetoModel.ValorDaMarca, Keys.Enter);
            ClicarBotaoName(OrdemDeServicoModel.ElementoNameDoCadastrar);
            ClicarBotaoName(OrdemDeServicoModel.ElementoNameDoConfirmarDoPesquisar);
            LancarProduto();
            AvancarNaOrdemDeServico();
            DriverService.SelecionarItemComboBoxSemEnter(OrdemDeServicoModel.ElementoDeTipoDaOrdemDeServico, 1);
            DriverService.SelecionarItemComboBox(OrdemDeServicoModel.ElementoDoStatusDaOrdemDeServico, 1);
            DriverService.RealizarSelecaoDaAcao(OrdemDeServicoModel.AcoesDaOrdemDeServico, 2);
            FecharTelaDeOrdemDeServicoComEsc();
            ClicarBotaoName(ConsultaDeOrdemDeServicoModel.BotaoDaAtualizarOrdemDeServico);
        }

        private void LancarProduto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(ConsultaDeOrdemDeServicoModel.ElementoTelaDeOrdemDeServico);
        }

        private void RealizarFluxoDeFaturarDaOrdemDeServico()
        {
            ClicarBotaoName(ConsultaDeOrdemDeServicoModel.BotaoDeFaturarDaOrdemDeServico);
            DriverService.RealizarSelecaoDaFormaDePagamento(OrdemDeServicoModel.GridDeFormaDePagamento, 1);
            FecharTelaDeOrdemDeServicoComEsc();
        }

        private void AvancarNaOrdemDeServico()
            => ClicarBotaoName(OrdemDeServicoModel.ElementoNameDoAvancar);

        private void FecharTelaDeOrdemDeServicoComEsc() =>
            DriverService.FecharJanelaComEsc(ConsultaDeOrdemDeServicoModel.ElementoTelaDeOrdemDeServico);
    }
}
