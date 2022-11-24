using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace SigecomTestesUI.Services
{
    public class DriverService : IDisposable
    {
        private readonly WindowsDriver<WindowsElement> _driver;

        public DriverService(WindowsDriver<WindowsElement> windowsDriver) => _driver = windowsDriver;

        public void FecharSistema()
        {
            ClicarBotaoName("Sair/Login");
            //ClicarBotaoName(", Sim (ENTER)");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            TrocarJanela();
            ValidarElementoExistentePorNome("Sistema de gestão comercial");
            ClicarBotaoName("Fechar");
            _driver.Dispose();
        }

        public void ValidarElementoExistentePorNome(string valor)
        {
            var elemento = EncontrarElementoName(valor);
            Assert.AreEqual(elemento.Text, valor);
        }

        public WindowsElement EncontrarElementoId(string idElemento) => 
            _driver.FindElementByAccessibilityId(idElemento);

        public WindowsElement EncontrarElementoName(string nomeElemento) => 
            _driver.FindElementByName(nomeElemento);

        public WindowsElement EncontrarElementoXPath(string caminhoElemento) => 
            _driver.FindElementByXPath(caminhoElemento);

        public string ObterValorElementoId(string nomeElemento) => 
            _driver.FindElementByAccessibilityId(nomeElemento).Text;

        public string ObterValorElementoName(string nomeElemento) => 
            _driver.FindElementByName(nomeElemento).Text;

        public string PegarValorDaColunaDaGrid(string nomeColuna) => 
            _driver.FindElementByName($"{nomeColuna} row 0").Text;

        public void TrocarJanela()
        {
            // Identify the current window handle. You can check through inspect.exe which window this is.

            //var currentWindowHandle = _driver.CurrentWindowHandle;

            // Wait for 5 seconds or however long it is needed for the right window to appear/for the splash screen to be dismissed
            Thread.Sleep(TimeSpan.FromSeconds(3));
            // Return all window handles associated with this process/application.
            // At this point hopefully you have one to pick from. Otherwise you can
            // simply iterate through them to identify the one you want.
            var allWindowHandles = _driver.WindowHandles;
            // Assuming you only have only one window entry in allWindowHandles and it is in fact the correct one,
            // switch the session to that window as follows. You can repeat this logic with any top window with the same
            // process id (any entry of allWindowHandles)
            _driver.SwitchTo().Window(allWindowHandles[0]);
        }

        public void DigitarNoCampoId(string idElemento, string texto) => 
            _driver.FindElementByAccessibilityId(idElemento).SendKeys(texto);

        public void DigitarNoCampoName(string nomeElemento, string texto) => 
            _driver.FindElementByName(nomeElemento).SendKeys(texto);

        public void DigitarNoCampoEnterId(string idElemento, string texto)
        {
            var elemento = _driver.FindElementByAccessibilityId(idElemento);
            elemento.SendKeys(texto);
            elemento.SendKeys(Keys.Enter);
        }

        public void DigitarNoCampoEnterName(string nomeElemento, string texto)
        {
            var elemento = _driver.FindElementByAccessibilityId(nomeElemento);
            elemento.SendKeys(texto);
            elemento.SendKeys(Keys.Enter);
        }

        public void ClicarBotaoName(string nomeBotao) => 
            _driver.FindElementByName(nomeBotao).Click();

        public void ClicarBotaoId(string nomeBotao) => 
            _driver.FindElementByAccessibilityId(nomeBotao).Click();

        public void DarDuploCliqueNoBotaoName(string nomeBotao)
        {
            var botaoEncontrado = _driver.FindElementByName(nomeBotao);
            var acao = new Actions(_driver);
            acao.MoveToElement(botaoEncontrado);
            acao.DoubleClick();
            acao.Perform();
        }

        public void SelecionarItemComboBox(string nomeCampo, int posicao)
        {
            var campo = _driver.FindElementByAccessibilityId(nomeCampo);
            campo.Click();
            EncontrarElementoNaComboBox(posicao, campo);
            campo.SendKeys(Keys.Enter);
        }

        public void SelecionarDoisItensDaGrid(string nomeCampo, int posicao)
        {
            var elementoEncontrado = _driver.FindElementByName(nomeCampo);
            elementoEncontrado.Click();
            EncontrarElementoNaComboBox(posicao, elementoEncontrado);
            elementoEncontrado.SendKeys(Keys.Enter);
            elementoEncontrado.SendKeys(Keys.Tab);
        }

        public void DigitarItensNaGrid(string nomeCampo, string texto)
        {
            var elementoEncontrado = _driver.FindElementByName($"{nomeCampo} new item row");
            elementoEncontrado.Click();
            elementoEncontrado.SendKeys(texto);
            elementoEncontrado.SendKeys(Keys.Tab);
        }

        public void ClicarNoToggleSwitchPeloId(string nomeDoCampo) => 
            ClicarBotaoId(nomeDoCampo);

        private static void EncontrarElementoNaComboBox(int posicao, WindowsElement campo)
        {
            for (var i = 1; i <= posicao; i++)
                campo.SendKeys(Keys.ArrowDown);
        }

        public void FecharJanelaComEsc(string nomeJanela) => 
            _driver.FindElementByName(nomeJanela).SendKeys(Keys.Escape);

        public void AbrirPesquisaDeProdutoComF9(string nomeJanela) =>
            _driver.FindElementByName(nomeJanela).SendKeys(Keys.F9);

        public void Dispose()
        {
            FecharSistema();
            _driver.Quit();
        }
    }
}
