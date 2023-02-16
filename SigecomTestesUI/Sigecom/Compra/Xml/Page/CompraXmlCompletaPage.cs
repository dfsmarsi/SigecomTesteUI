using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Compra.Xml.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Compra.Xml.Page
{
    public class CompraXmlCompletaPage:PageObjectModel
    {
        public CompraXmlCompletaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CompraXmlModel.BotaoMenuEstoque);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CompraXmlModel.BotaoSubMenu);

        public void RealizarFluxoDaCompraXml()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoName(CompraXmlModel.BotaoAtalhosCompra);
            ClicarBotaoName(CompraXmlModel.AtalhoDeCarregarXml);
            DriverService.TrocarJanela();
            ClicarBotaoName(CompraXmlModel.ElementoDoCaminhoDoDocumentos);
            DriverService.DigitarNoCampoId("1148", "Teste.xml");
            DriverService.ClicarBotaoId("1");
            ClicarBotaoName("F5 - Gravar");

            // Act
            DriverService.EditarItensNaGridComDuploClickNaPosicaoDesejada("Item", "", "0");
            DriverService.ClicarBotaoId("linkBuscarProdutoCadastrado");
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CompraXmlModel.ElementoPesquisaDeProduto, "11", Keys.Enter);
            ClicarBotaoName(", Confirmar (ENTER)");
            DriverService.EditarItensNaGridComDuploClickNaPosicaoDesejada("Item", "", "1");
            DriverService.ClicarBotaoId("linkBuscarProdutoCadastrado");
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CompraXmlModel.ElementoPesquisaDeProduto, "11", Keys.Enter);
            ClicarBotaoName(", Confirmar (ENTER)");

            // Assert
            ClicarBotaoName(CompraXmlModel.ElementoDoAvancarCompra);
            ClicarBotaoName(CompraXmlModel.ElementoDoAvancarCompra);
            ClicarBotaoName(CompraXmlModel.ElementoDoAvancarCompra);
            ClicarBotaoName(CompraXmlModel.ElementoDoAvancarCompra);
            ClicarBotaoName(CompraXmlModel.ElementoDoAvancarCompra);
            Assert.AreEqual(DriverService.ObterValorElementoId(CompraXmlModel.ElementoDoTotalDuplicatas), "R$150,00");
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(CompraXmlModel.CampoDaGridDeValorDuplicatas), "150,00");
            ClicarBotaoName(CompraXmlModel.ElementoDoAvancarCompra);
            ClicarBotaoName(CompraXmlModel.ElementoDoAvancarCompra);
            FecharTelaDeCompraXmlComEsc();
        }

        private void FecharTelaDeCompraXmlComEsc() =>
            DriverService.FecharJanelaComEsc(CompraXmlModel.ElementoTelaDeCompra);
    }
}
