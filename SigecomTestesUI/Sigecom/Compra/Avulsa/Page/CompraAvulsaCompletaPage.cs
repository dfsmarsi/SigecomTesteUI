using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using SigecomTestesUI.Sigecom.Compra.Avulsa.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Compra.Avulsa.Page
{
    public class CompraAvulsaCompletaPage: PageObjectModel
    {
        public CompraAvulsaCompletaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CompraAvulsaModel.BotaoMenuEstoque);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CompraAvulsaModel.BotaoSubMenu);

        public void RealizarFluxoDaCompraAvulsa()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoName(CompraAvulsaModel.BotaoAtalhosCompra);
            ClicarBotaoName(CompraAvulsaModel.AtalhoDeInserirFornecedor);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(PesquisaDePessoaModel.ElementoParametroDePesquisa,
                "6", Keys.Enter);

            // Act
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(PesquisaDeProdutoModel.ElementoParametroDePesquisa,
                PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto, Keys.Enter);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(CompraAvulsaModel.CampoDaGridDeQuantidadeDoProduto), "5");
            DriverService.EditarItensNaGridComDuploClickComTab(CompraAvulsaModel.CampoDaGridDeCustoDoProduto, "10");
            DriverService.EditarItensNaGridComDuploClickComTab(CompraAvulsaModel.CampoDaGridDeDiferencialDoProduto, "50");
            ClicarBotaoName(CompraAvulsaModel.BotaoAtalhosCompra);
            ClicarBotaoName(CompraAvulsaModel.BotaoAtalhosDeDespesas);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CompraAvulsaModel.ElementoDoValorDeDespesas, "50", Keys.Enter);
            ClicarBotaoName(CompraAvulsaModel.BotaoAtalhosCompra);
            ClicarBotaoName(CompraAvulsaModel.BotaoAtalhosDeFrete);
            ClicarBotaoName(CompraAvulsaModel.ElementoDoTransportador);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(PesquisaDePessoaModel.ElementoParametroDePesquisa, "", Keys.Enter);
            DriverService.EditarItensNaGridComDuploClickComTab(CompraAvulsaModel.CampoDaGridDeCustoDoProduto, "10");



            // Assert
            DriverService.TrocarJanela();
            FecharTelaDeCompraAvulsaComEsc();
        }

        public string LancarProdutoPadraoNaVenda(string nomeDaTela)
        {
            if (!PesquisarProduto(nomeDaTela, out var idDoProduto)) throw new Exception("Não encontrado produto");

            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CompraAvulsaModel.ElementoPesquisaDeProduto, idDoProduto, Keys.Enter);
            LancarProdutosNaVenda(CompraAvulsaModel.ElementoTelaDeCompra);
            return idDoProduto;
        }

        private bool PesquisarProduto(string nomeDaTela, out string idDoProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var pesquisaDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>()(DriverService);
            var pesquisarComF9UmProdutoNaTelaDeVenda = pesquisaDeProdutoPage.PesquisarComF9UmProdutoNaTelaDeVenda(beginLifetimeScope, nomeDaTela);
            idDoProduto = DriverService.PegarValorDaColunaDaGrid("Código");
            pesquisaDeProdutoPage.FecharJanelaComEsc();
            return pesquisarComF9UmProdutoNaTelaDeVenda;
        }

        public void LancarProdutosNaVenda(string nomeDaTela)
        {
            var idDoProduto = LancarProdutoPadraoNaVenda(nomeDaTela);
            LancarProduto(CompraAvulsaModel.PesquisarItem);
            LancarProduto(CompraAvulsaModel.PesquisarItemReferencia);
            LancarProduto(CompraAvulsaModel.PesquisarItemCodInterno);
            LancarProduto($"1*{idDoProduto}");
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(CompraAvulsaModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void FecharTelaDeCompraAvulsaComEsc() =>
            DriverService.FecharJanelaComEsc(CompraAvulsaModel.ElementoTelaDeCompra);
    }
}
