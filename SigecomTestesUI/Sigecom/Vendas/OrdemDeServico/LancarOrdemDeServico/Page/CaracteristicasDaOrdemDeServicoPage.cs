using System;
using Autofac;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Page
{
    public class CaracteristicasDaOrdemDeServicoPage: PageObjectModel
    {
        public CaracteristicasDaOrdemDeServicoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(OrdemDeServicoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(OrdemDeServicoModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarCaracteristicasNaOrdemDeServico()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoName(OrdemDeServicoModel.BotaoAtalhosOrdemDeServico);
            ClicarBotaoName(OrdemDeServicoModel.AtalhoDePesquisarObjetoDaOrdemDeServico);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastrarObjetoModel.ElementoDoObjeto, CadastrarObjetoModel.ValorDoObjeto, Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(CadastrarObjetoModel.ElementoDoCampoDePesquisa, CadastrarObjetoModel.ValorDoObjeto, Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastrarObjetoModel.ElementoDaMarca, CadastrarObjetoModel.ValorDaMarca, Keys.Enter);
            ClicarBotaoName(OrdemDeServicoModel.ElementoNameDoCadastrar);
            ClicarBotaoName(OrdemDeServicoModel.ElementoNameDoConfirmarDoPesquisar);
            LancarProdutoPadrao();
            AvancarNaOrdemDeServico();
            DriverService.SelecionarItemComboBoxSemEnter(OrdemDeServicoModel.ElementoDeTipoDaOrdemDeServico, 1);
            DriverService.SelecionarItemComboBoxSemEnter(OrdemDeServicoModel.ElementoDoStatusDaOrdemDeServico, 1);
            DriverService.ClicarNoCheckEditDaGrid(OrdemDeServicoModel.GridDeCaracteristicas);
            DriverService.RealizarSelecaoDaAcao(OrdemDeServicoModel.AcoesDaOrdemDeServico, 2);
            FecharTelaDeOrdemDeServicoComEsc();
        }

        private void LancarProdutoPadrao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda();
        }

        private void AvancarNaOrdemDeServico()
            => ClicarBotaoName(OrdemDeServicoModel.ElementoNameDoAvancar);

        private void FecharTelaDeOrdemDeServicoComEsc() =>
            DriverService.FecharJanelaComEsc(OrdemDeServicoModel.ElementoTelaDeOrdemDeServico);
    }
}
