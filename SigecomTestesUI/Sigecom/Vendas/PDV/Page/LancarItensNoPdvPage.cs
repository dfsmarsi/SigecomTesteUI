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
    public class LancarItensNoPdvPage : PageObjectModel
    {
        public LancarItensNoPdvPage(DriverService driver) : base(driver)
        {
        }

        internal void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PdvModel.BotaoMenuCadastro);

        internal void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PdvModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarItemNoPdv(FormaDePagamento formaDePagamento)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<ILancarFormaDePagamentoPageFactory>().Fabricar(DriverService, formaDePagamento).RealizarFluxoDeLancarItemNoPdv(this, formaDePagamento);
        }

        internal void SelecionarFormaDePagamento(FormaDePagamento formaDePagamento)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<ILancarFormaDePagamentoPageFactory>().Fabricar(DriverService, formaDePagamento).SelecionarFormaDePagamento();
        }

        internal void PagarPedido() =>
            ClicarBotao(PdvModel.PagarPedido);

        internal void ConcluirPedido() =>
            ClicarBotao(PdvModel.ConfirmarPdv);

        internal void LancarItemNoPedido() => 
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.PesquisaDeProduto, LancarItemNoPdvModel.PesquisarItem, Keys.Enter);

        internal void EditarItemDoPedido()
        {
            ClicarBotao(PdvModel.AtalhoDoPdv);
            ClicarBotao(PdvModel.AtalhoDeEditarItemDoPdv);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.EditarQuantidade, LancarItemNoPdvModel.QuantidadeDeItens, Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.EditarValor, LancarItemNoPdvModel.ValorDosItens, Keys.Enter);
        }

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
