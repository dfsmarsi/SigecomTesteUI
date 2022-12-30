using System;
using System.Threading;
using Autofac;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.PDV.Enum;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class LancarItensNoPdvPage : PageObjectModel
    {
        public LancarItensNoPdvPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PdvModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PdvModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarItemNoPdv(FormaDePagamento formaDePagamento)
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarItemNoPedido();
            EditarItemDoPedido();
            PagarPedido();
            SelecionarFormaDePagamento(formaDePagamento);
            ConcluirPedido();
            FecharTelaDeVendaComEsc();
        }

        private void SelecionarFormaDePagamento(FormaDePagamento formaDePagamento)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<ILancarFormaDePagamentoPageFactory>().Fabricar(DriverService, formaDePagamento).SelecionarFormaDePagamento();
        }

        private void PagarPedido() =>
            ClicarBotao(PdvModel.PagarPedido);

        private void ConcluirPedido() =>
            ClicarBotao(PdvModel.ConfirmarPdv);

        private void LancarItemNoPedido() => 
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.PesquisaDeProduto, LancarItemNoPdvModel.PesquisarItem, Keys.Enter);

        private void EditarItemDoPedido()
        {
            ClicarBotao(PdvModel.AtalhoDoPdv);
            ClicarBotao(PdvModel.AtalhoDeEditarItemDoPdv);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.EditarQuantidade, LancarItemNoPdvModel.QuantidadeDeItens, Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PdvModel.EditarValor, LancarItemNoPdvModel.ValorDosItens, Keys.Enter);
        }

        private void FecharTelaDeVendaComEsc()
        {
            DriverService.ClicarBotaoId(PdvModel.BotaoDeFecharPerguntaDeImpressaoPdv);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ClicarBotao(PdvModel.AtalhoDoPdv);
            ClicarBotao(PdvModel.AtalhoDeSairDoPdv);
        }
    }
}
