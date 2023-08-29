using System;
using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa.Model;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Devolucao.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Devolucao.Page
{
    public class DevolucaoParcialNaDevolucaoPage: PageObjectModel
    {
        public DevolucaoParcialNaDevolucaoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(DevolucaoModel.BotaoMenuVendas);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(DevolucaoModel.BotaoSubMenu);

        public void RealizarFluxoDeDevolucaoParcialNaDevolucao()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto();
            DriverService.EditarItensNaGridComDuploClickComTab(DevolucaoModel.CampoDaGridDeQuantidadeParaDevolver, "0");
            AvancarNaDevolucao();
            var posicao = DriverService.RetornarPosicaoDoRegistroDesejado(DevolucaoModel.CampoDaGridIdPedido, "18");
            var qtdeVendida = int.Parse(DriverService.PegarValorDaColunaDaGridNaPosicao(DevolucaoModel.CampoDaGridDeQuantidadeVendida, posicao.ToString()));
            Assert.IsTrue(qtdeVendida > 1);
            DriverService.EditarNaGridNaPosicao(DevolucaoModel.CampoDaGridDeQuantidadeParaDevolver, "1", posicao);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao(DevolucaoModel.CampoDaGridDeSituacaoParaDevolver, posicao.ToString()), "Devolução parcial");
            AvancarNaDevolucao();
            DriverService.RealizarSelecaoDaAcao(DevolucaoModel.AcoesDaDevolucao, 2);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(PesquisaDePessoaModel.ElementoParametroDePesquisa, "CLIENTE TESTE PESQUISA", Keys.Enter);
            ClicarBotaoName(DevolucaoModel.ElementoNameDoNao);
            FecharTelaDeDevolucaoComEsc();
        }

        private void LancarProduto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(DevolucaoModel.ElementoTelaDeDevolucao);
        }

        private void AvancarNaDevolucao()
            => ClicarBotaoName(DevolucaoModel.ElementoNameDoAvancar);

        private void FecharTelaDeDevolucaoComEsc() =>
            DriverService.FecharJanelaComEsc(DevolucaoModel.ElementoTelaDeDevolucao);
    }
}
