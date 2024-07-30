using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.PDV.Enum;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces;
using System;
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
            ClicarBotaoName(PdvModel.ElementoNamePagarPedido);

        public void LancarProdutoPadrao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(PdvModel.ElementoTelaDePdv);
        }

        internal void EditarClienteDoPedido()
        {
            ClicarBotaoName(PdvModel.AtalhoDoPdv);
            ClicarBotaoName(PdvModel.AtalhoDeEditarClienteDoPdv);
            SelecionarCliente();
        }

        public void SelecionarCliente()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>()(DriverService).PesquisarPessoaComConfirmar("cliente", "CLIENTE TESTE PESQUISA");
        }

        internal void FecharTelaDoPdv()
        {
            EsperarAcaoEmSegundos(3);
            DriverService.FecharJanelaComEscId("scProdutos");
        }
    }
}
