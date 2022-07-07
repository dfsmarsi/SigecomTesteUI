using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.Threading;

namespace SigecomTesteUI
{
    [TestClass]
    public class Base
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string AppId = @"C:\SIGECOM\SIGECOM.exe";

        private WindowsDriver<WindowsElement> _windowsDriver;

        public void Setup()
        {
            Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
            if (_windowsDriver == null)
            {
                AppiumOptions appCapabilities = new AppiumOptions();
                appCapabilities.AddAdditionalCapability("app", AppId);
                _windowsDriver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
                Assert.IsNotNull(_windowsDriver);

                _windowsDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            }
        }

        public void EncerrarSessao()
        {
            _windowsDriver = null; ;
        }

        public void TrocarJanela()
        {
            // Identify the current window handle. You can check through inspect.exe which window this is.
            var currentWindowHandle = _windowsDriver.CurrentWindowHandle;
            // Wait for 5 seconds or however long it is needed for the right window to appear/for the splash screen to be dismissed
            Thread.Sleep(TimeSpan.FromSeconds(3));
            // Return all window handles associated with this process/application.
            // At this point hopefully you have one to pick from. Otherwise you can
            // simply iterate through them to identify the one you want.
            var allWindowHandles = _windowsDriver.WindowHandles;
            // Assuming you only have only one window entry in allWindowHandles and it is in fact the correct one,
            // switch the session to that window as follows. You can repeat this logic with any top window with the same
            // process id (any entry of allWindowHandles)
            _windowsDriver.SwitchTo().Window(allWindowHandles[0]);
        }

        [TestInitialize]
        public void Logar()
        {
            Setup();
            //DigitarNoCampo("txtUsuario", "Douglas");
            //_appiumDriver.DigitarNoCampoEnter("txtSenha", "123");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            TrocarJanela();
            //Verificar("SIGECOM - Sistema de Gestão Comercial - SISTEMASBR", "SIGECOM - Sistema de Gestão Comercial - SISTEMASBR");
        }

        [TestCleanup]
        public void FecharSistema()
        {
            _appiumDriver.ClicarBotaoName("Sair/Login");
            _appiumDriver.TrocarJanela();
            _appiumDriver.Verificar("Sistema de gestão comercial", "Sistema de gestão comercial");
            _appiumDriver.ClicarBotaoName("Fechar");
            _appiumDriver.EncerrarSessao();
        }
    }
}
