using Autofac;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using SigecomTestesUI.Sigecom.Vendas.PDV.Enum;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces;
using System;
using System.Threading;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class LancarVendaNaFormaDePagamentoPage : PageObjectModel
    {
        public LancarVendaNaFormaDePagamentoPage(DriverService driver) : base(driver)
        {
        }

        internal void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PdvModel.BotaoMenuCadastro);

        internal void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PdvModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarVendaNoPdv(FormaDePagamento formaDePagamento)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<ILancarFormaDePagamentoPageFactory>().Fabricar(DriverService, formaDePagamento).RealizarFluxoDeLancarVendaNoPdv(this, formaDePagamento);
        }

        internal void PagarPedido() =>
            ClicarBotao(PdvModel.PagarPedido);

        internal void ConcluirPedido() =>
            ClicarBotao(PdvModel.ConfirmarPdv);

        internal void LancarItemNoPedido() => 
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.PesquisaDeProduto, LancarItemNoPdvModel.PesquisarItem, Keys.Enter);

        internal void EditarClienteDoPedido()
        {
            ClicarBotao(PdvModel.AtalhoDoPdv);
            ClicarBotao(PdvModel.AtalhoDeEditarClienteDoPdv);
            SelecionarCliente();
        }

        private void SelecionarCliente()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>()(DriverService).PesquisarPessoaComConfirmar("cliente", "CLIENTE TESTE PESQUISA");
        }

        internal void FecharTelaDeVendaComEsc()
        {
            DriverService.ClicarBotaoId(PdvModel.BotaoDeFecharPerguntaDeImpressaoPdv);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ClicarBotao(PdvModel.AtalhoDoPdv);
            ClicarBotao(PdvModel.AtalhoDeSairDoPdv);
        }
    }
}
