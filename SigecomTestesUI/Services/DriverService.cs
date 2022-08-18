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

        public DriverService()
        {
            Driver = DriverFabrica.CriarDriver();
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

        public string ObterValorElementoId(WindowsElement elemento)
        {
            return elemento.Text;
        }

        public string ObterValorElementoName(WindowsElement elemento)
        {
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

        public void DigitarNoCampo(WindowsElement elemento, string texto)
        {
            elemento.SendKeys(texto);
        }

        public void DigitarNoCampoEnter(WindowsElement elemento, string texto)
        {
            elemento.SendKeys(texto);
            elemento.SendKeys(Keys.Enter);
        }

        public void ClicarBotao(WindowsElement botao)
        {
            botao.Click();
        }

        public void DoubleClickBotao(WindowsElement botao)
        {
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
