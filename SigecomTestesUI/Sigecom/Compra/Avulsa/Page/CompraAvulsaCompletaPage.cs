using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using SigecomTestesUI.Sigecom.Compra.Avulsa.Model;
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
            LancarProdutosNaVenda();
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(CompraAvulsaModel.CampoDaGridDeQuantidadeDoProduto), "5,0000");
            DriverService.EditarItensNaGridComDuploClickComTab(CompraAvulsaModel.CampoDaGridDeCustoDoProduto, "10");
            DriverService.EditarItensNaGridComDuploClickComTab(CompraAvulsaModel.CampoDaGridDeDiferencialDoProduto, "10");
            ClicarBotaoName(CompraAvulsaModel.BotaoAtalhosCompra);
            ClicarBotaoName(CompraAvulsaModel.BotaoAtalhosDeDespesas);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CompraAvulsaModel.ElementoDoValorDeDespesas, "50", Keys.Enter);
            ClicarBotaoName(CompraAvulsaModel.BotaoAtalhosCompra);
            ClicarBotaoName(CompraAvulsaModel.BotaoAtalhosDeFrete);
            DriverService.ClicarBotaoName(CompraAvulsaModel.ElementoDoTransportador);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(PesquisaDePessoaModel.ElementoParametroDePesquisa, "", Keys.Enter);
            DriverService.DigitarNoCampoId(CompraAvulsaModel.ElementoDoValorDeFrete, "50");
            ClicarBotaoName(CompraAvulsaModel.ElementoDoConfirmar);
            ClicarBotaoName(CompraAvulsaModel.ElementoDoConfirmarFinalDoFrete);
            ClicarBotaoName(CompraAvulsaModel.BotaoAtalhosCompra);
            ClicarBotaoName(CompraAvulsaModel.BotaoAtalhosDeNfe);
            DriverService.DigitarNoCampoId(CompraAvulsaModel.ElementoDeSerieDoNfe, "1");
            DriverService.DigitarNoCampoId(CompraAvulsaModel.ElementoDoNumeroDoNfe, "1");
            ClicarBotaoName(CompraAvulsaModel.ElementoDoConfirmar);
            DriverService.EditarItensNaGridComDuploClickComTab(CompraAvulsaModel.CampoDaGridDeMarkupDoProduto, "100");
            EsperarAcaoEmSegundos(1);


            // Assert
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(CompraAvulsaModel.CampoDaGridDoNovoCustoDoProduto), "31,00");
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(CompraAvulsaModel.CampoDaGridDePrecoDeVendaDoProduto), "62,00");
            ClicarBotaoName(CompraAvulsaModel.ElementoDoAvancarCompra);
            ClicarBotaoName(CompraAvulsaModel.ElementoDoAvancarCompra);
            Assert.AreEqual(DriverService.ObterValorElementoId(CompraAvulsaModel.ElementoDoTotalDuplicatas), "R$50,00");
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(CompraAvulsaModel.CampoDaGridDeValorDuplicatas), "50,00");
            ClicarBotaoName(CompraAvulsaModel.ElementoDoAvancarCompra);
            ClicarBotaoName(CompraAvulsaModel.ElementoDoAvancarCompra);
            FecharTelaDeCompraAvulsaComEsc();
        }

        private void LancarProdutosNaVenda()
        {
            LancarProduto(PesquisaDeProdutoInformacoesParaTesteModel.PesquisarItemId);
            LancarProduto(PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto);
            LancarProduto(PesquisaDeProdutoInformacoesParaTesteModel.ReferenciaDoProduto);
            LancarProduto(PesquisaDeProdutoInformacoesParaTesteModel.CodigoInternoDoProduto);
            LancarProduto($"1*{PesquisaDeProdutoInformacoesParaTesteModel.PesquisarItemId}");
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(CompraAvulsaModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void FecharTelaDeCompraAvulsaComEsc() =>
            DriverService.FecharJanelaComEsc(CompraAvulsaModel.ElementoTelaDeCompra);
    }
}
