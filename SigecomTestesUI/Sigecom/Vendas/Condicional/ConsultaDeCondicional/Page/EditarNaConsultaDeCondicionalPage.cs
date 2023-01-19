using System;
using Autofac;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Model;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Page
{
    public class EditarNaConsultaDeCondicionalPage: PageObjectModel
    {
        public EditarNaConsultaDeCondicionalPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDeCondicionalModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDeCondicionalModel.BotaoSubMenu);

        public void RealizarFluxoDeAlterarCondicional()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            RealizarOFluxoDeGerarCondicionalNaConsulta();
            ClicarBotaoName(ConsultaDeCondicionalModel.BotaoDaAlterarCondicional);
            DriverService.EditarItensNaGridComDuploClick(CondicionalModel.CampoDaGridDeValorUnitarioDoProduto, LancarItensNaCondicionalModel.ValorUnitarioParaEditarCondicional);
            AvancarNaCondicional();
            AvancarNaCondicional();
            DriverService.RealizarSelecaoDaAcao(CondicionalModel.AcoesDaCondicional, 2);
            FecharTelaDeCondicionalComEsc();
        }

        private void RealizarOFluxoDeGerarCondicionalNaConsulta()
        {
            ClicarBotaoName(ConsultaDeCondicionalModel.BotaoDaNovaCondicional);
            ClicarBotaoName(CondicionalModel.BotaoAtalhosCondicional);
            ClicarBotaoName(CondicionalModel.AtalhoDeEditarClienteDaCondicional);
            SelecionarCliente();
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CondicionalModel.ElementoPesquisaDeProduto,
                LancarItensNaCondicionalModel.PesquisarItemId, Keys.Enter);
            DriverService.EditarItensNaGridComDuploClick(CondicionalModel.CampoDaGridDeQuantidadeDoProduto,
                LancarItensNaCondicionalModel.QuantidadeDeProduto);
            AvancarNaCondicional();
            AvancarNaCondicional();
            DriverService.RealizarSelecaoDaAcao(CondicionalModel.AcoesDaCondicional, 2);
        }

        private void SelecionarCliente()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>()(DriverService).PesquisarPessoaComConfirmar("cliente", "CLIENTE TESTE PESQUISA");
        }

        private void AvancarNaCondicional()
            => ClicarBotaoName(CondicionalModel.ElementoNameDoAvancar);

        private void FecharTelaDeCondicionalComEsc() =>
            DriverService.FecharJanelaComEsc(ConsultaDeCondicionalModel.ElementoTelaDeCondicional);
    }
}
