using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using SigecomTesteUI.Config;
using System;
using System.Threading;

namespace SigecomTestesUI.Services
{
    public class DriverService : IDisposable
    {
        public WindowsDriver<WindowsElement> Driver;
        public DriverFabrica driverFabrica = new DriverFabrica();

        public DriverService()
        {
            Driver = driverFabrica.CriarDriver();
        }

        public WindowsElement EncontrarElementoId(string idElemento)
        {
            return Driver.FindElementByAccessibilityId(idElemento);
        }

        public WindowsElement EncontrarElementoName(string nomeElemento)
        {
            return Driver.FindElementByName(nomeElemento);
        }

        public WindowsElement EncontrarElementoXPath(string caminhoElemento)
        {
            return Driver.FindElementByXPath(caminhoElemento);
        }

        public string ObterValorElementoId(string nomeElemento)
        {
            var elemento = Driver.FindElementByAccessibilityId(nomeElemento);
            return elemento.Text;
        }

        public string ObterValorElementoName(string nomeElemento)
        {
            var elemento = Driver.FindElementByName(nomeElemento);
            return elemento.Text;
        }

        public void TrocarJanela()
        {
            // Identify the current window handle. You can check through inspect.exe which window this is.
            var currentWindowHandle = Driver.CurrentWindowHandle;
            // Wait for 5 seconds or however long it is needed for the right window to appear/for the splash screen to be dismissed
            Thread.Sleep(TimeSpan.FromSeconds(3));
            // Return all window handles associated with this process/application.
            // At this point hopefully you have one to pick from. Otherwise you can
            // simply iterate through them to identify the one you want.
            var allWindowHandles = Driver.WindowHandles;
            // Assuming you only have only one window entry in allWindowHandles and it is in fact the correct one,
            // switch the session to that window as follows. You can repeat this logic with any top window with the same
            // process id (any entry of allWindowHandles)
            Driver.SwitchTo().Window(allWindowHandles[0]);
        }

        public void DigitarNoCampoId(string idElemento, string texto)
        {
            var elemento = Driver.FindElementByAccessibilityId(idElemento);
            elemento.SendKeys(texto);
        }

        public void DigitarNoCampoName(string nomeElemento, string texto)
        {
            var elemento = Driver.FindElementByName(nomeElemento);
            elemento.SendKeys(texto);
        }

        public void DigitarNoCampoEnterId(string idElemento, string texto)
        {
            var elemento = Driver.FindElementByAccessibilityId(idElemento);
            elemento.SendKeys(texto);
            elemento.SendKeys(Keys.Enter);
        }

        public void DigitarNoCampoEnterName(string nomeElemento, string texto)
        {
            var elemento = Driver.FindElementByAccessibilityId(nomeElemento);
            elemento.SendKeys(texto);
            elemento.SendKeys(Keys.Enter);
        }

        public void ClicarBotaoName(string nomeBotao)
        {
            var botao = Driver.FindElementByName(nomeBotao);
            botao.Click();
        }

        public void ClicarBotaoId(string nomeBotao)
        {
            var botao = Driver.FindElementByAccessibilityId(nomeBotao);
            botao.Click();
        }

        public void DoubleClickBotaoName(string nomeBotao)
        {
            var botao = Driver.FindElementByName(nomeBotao);
            Actions acao = new Actions(Driver);
            acao.MoveToElement(botao);
            acao.DoubleClick();
            acao.Perform();
        }

        public void SelecionarItemComboBox(string nomeCampo, int posicao)
        {
            var campo = Driver.FindElementByAccessibilityId(nomeCampo);
            campo.Click();
            for (int i = 1; i <= posicao; i++)
                campo.SendKeys(Keys.ArrowDown);
            campo.SendKeys(Keys.Enter);
        }

        //public void VerificarCadastroRealizado(string nomeTelaPesquisa, string stringPesquisa)
        //{
        //    driver.FindElementByName("F9 - Pesquisar").Click();
        //    Verificar(nomeTelaPesquisa, nomeTelaPesquisa);
        //    var campo = driver.FindElementByAccessibilityId("textEditParametroDePesquisa");
        //    campo.SendKeys(stringPesquisa);
        //    campo.SendKeys(Keys.Enter);
        //    var nomeDaGrid = driver.FindElementByName("Nome row 0").Text;
        //    Assert.AreEqual(stringPesquisa, nomeDaGrid);
        //}
        public void FecharJanelaComEsc(string nomeJanela)
        {
            var janela = Driver.FindElementByName(nomeJanela);
            janela.SendKeys(Keys.Escape);
        }

        public void Dispose()
        {
        }
    }
}
