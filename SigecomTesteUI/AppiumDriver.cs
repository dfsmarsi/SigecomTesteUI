using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;
using System.Diagnostics;
using System.Threading;

namespace SigecomTesteUI
{
    public class AppiumDriver
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string AppId = @"C:\SIGECOM\SIGECOM.exe";

        public static WindowsDriver<WindowsElement> session;

        public void Setup()
        {
            Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
            if (session == null)
            {
                AppiumOptions appCapabilities = new AppiumOptions();
                appCapabilities.AddAdditionalCapability("app", AppId);
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
                Assert.IsNotNull(session);

                session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            }
        }
        public void EncerrarSessao()
        {
            session = null; ;
        }

        public void TrocarJanela()
        {
            // Identify the current window handle. You can check through inspect.exe which window this is.
            var currentWindowHandle = session.CurrentWindowHandle;
            // Wait for 5 seconds or however long it is needed for the right window to appear/for the splash screen to be dismissed
            Thread.Sleep(TimeSpan.FromSeconds(3));
            // Return all window handles associated with this process/application.
            // At this point hopefully you have one to pick from. Otherwise you can
            // simply iterate through them to identify the one you want.
            var allWindowHandles = session.WindowHandles;
            // Assuming you only have only one window entry in allWindowHandles and it is in fact the correct one,
            // switch the session to that window as follows. You can repeat this logic with any top window with the same
            // process id (any entry of allWindowHandles)
            session.SwitchTo().Window(allWindowHandles[0]);
        }

        public void DigitarNoCampo(string nomeCampo, string texto)
        {
            var campo = session.FindElementByAccessibilityId(nomeCampo);
            campo.SendKeys(texto);
        }
        public void DigitarNoCampoEnter(string nomeCampo, string texto)
        {
            var campo = session.FindElementByAccessibilityId(nomeCampo);
            campo.SendKeys(texto);
            campo.SendKeys(Keys.Enter);
        }
        public void DigitarNoCampoESelecionarNaPesquisa(string nomeCampo, string texto)
        {
            var campo = session.FindElementByAccessibilityId(nomeCampo);
            campo.SendKeys(texto);
            campo.SendKeys(Keys.Enter);
        }

        public void ClicarBotaoName(string nomeBotao)
        {
            var botao = session.FindElementByName(nomeBotao);
            botao.Click();
        }
        public void ClicarBotaoId(string idBotao)
        {
            var botao = session.FindElementByAccessibilityId(idBotao);
            botao.Click();
        }
        public void DoubleClickBotao(string nomeBotao)
        {
            Actions acao = new Actions(session);
            acao.MoveToElement(session.FindElementByName(nomeBotao));
            acao.DoubleClick();
            acao.Perform();
        }

        public void Verificar(string nomeCampo, string valor)
        {
            var campo = session.FindElementByName(nomeCampo);
            Assert.AreEqual(campo.Text, valor);
        }

        public void SelecionarItemComboBox(string nomeCampo, int posicao)
        {
            var campo = session.FindElementByAccessibilityId(nomeCampo);
            campo.Click();
            for (int i = 1; i <= posicao; i++)
                campo.SendKeys(Keys.ArrowDown);
            campo.SendKeys(Keys.Enter);
        }

        public void VerificarCadastroRealizado(string nomeTelaPesquisa, string stringPesquisa)
        {
            session.FindElementByName("F9 - Pesquisar").Click();
            Verificar(nomeTelaPesquisa, nomeTelaPesquisa);
            var campo = session.FindElementByAccessibilityId("textEditParametroDePesquisa");
            campo.SendKeys(stringPesquisa);
            campo.SendKeys(Keys.Enter);
            var nomeDaGrid = session.FindElementByName("Nome row 0").Text;
            Assert.AreEqual(stringPesquisa, nomeDaGrid);
        }
        public void FecharJanelaComEsc(string nomeJanela)
        {
            var janela = session.FindElementByName(nomeJanela);
            janela.SendKeys(Keys.Escape);
        }
    }
}
