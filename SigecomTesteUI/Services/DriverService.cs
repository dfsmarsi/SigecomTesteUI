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
    public class DriverService
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string AppId = @"C:\SIGECOM\SIGECOM.exe";

        private WindowsDriver<WindowsElement> _session;

        public void Setup()
        {
            Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
            if (_session == null)
            {
                AppiumOptions appCapabilities = new AppiumOptions();
                appCapabilities.AddAdditionalCapability("app", AppId);
                _session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
                Assert.IsNotNull(_session);

                _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            }
        }

        public WindowsDriver<WindowsElement> RetornarSessao() => _session;

        public void EncerrarSessao()
        {
            _session = null; ;
        }

        public void TrocarJanela()
        {
            // Identify the current window handle. You can check through inspect.exe which window this is.
            var currentWindowHandle = _session.CurrentWindowHandle;
            // Wait for 5 seconds or however long it is needed for the right window to appear/for the splash screen to be dismissed
            Thread.Sleep(TimeSpan.FromSeconds(3));
            // Return all window handles associated with this process/application.
            // At this point hopefully you have one to pick from. Otherwise you can
            // simply iterate through them to identify the one you want.
            var allWindowHandles = _session.WindowHandles;
            // Assuming you only have only one window entry in allWindowHandles and it is in fact the correct one,
            // switch the session to that window as follows. You can repeat this logic with any top window with the same
            // process id (any entry of allWindowHandles)
            _session.SwitchTo().Window(allWindowHandles[0]);
        }

        public void DigitarNoCampo(WindowsElement campo, string texto)
        {
            campo.SendKeys(texto);
        }

        public void DigitarNoCampoEnter(WindowsElement campo, string texto)
        {
            campo.SendKeys(texto);
            campo.SendKeys(Keys.Enter);
        }

        public void DigitarNoCampoESelecionarNaPesquisa(string nomeCampo, string texto)
        {
            var campo = _session.FindElementByAccessibilityId(nomeCampo);
            campo.SendKeys(texto);
            campo.SendKeys(Keys.Enter);
        }

        public void ClicarBotao(WindowsElement botao)
        {
            botao.Click();
        }
        
        public void DoubleClickBotao(WindowsElement botao)
        {
            Actions acao = new Actions(_session);
            acao.MoveToElement(botao);
            acao.DoubleClick();
            acao.Perform();
        }

        public void Verificar(WindowsElement elemento, string valor)
        {
            Assert.AreEqual(elemento.Text, valor);
        }

        public void SelecionarItemComboBox(string nomeCampo, int posicao)
        {
            var campo = _session.FindElementByAccessibilityId(nomeCampo);
            campo.Click();
            for (int i = 1; i <= posicao; i++)
                campo.SendKeys(Keys.ArrowDown);
            campo.SendKeys(Keys.Enter);
        }

        //public void VerificarCadastroRealizado(string nomeTelaPesquisa, string stringPesquisa)
        //{
        //    _session.FindElementByName("F9 - Pesquisar").Click();
        //    Verificar(nomeTelaPesquisa, nomeTelaPesquisa);
        //    var campo = _session.FindElementByAccessibilityId("textEditParametroDePesquisa");
        //    campo.SendKeys(stringPesquisa);
        //    campo.SendKeys(Keys.Enter);
        //    var nomeDaGrid = _session.FindElementByName("Nome row 0").Text;
        //    Assert.AreEqual(stringPesquisa, nomeDaGrid);
        //}
        public void FecharJanelaComEsc(string nomeJanela)
        {
            var janela = _session.FindElementByName(nomeJanela);
            janela.SendKeys(Keys.Escape);
        }
    }
}
