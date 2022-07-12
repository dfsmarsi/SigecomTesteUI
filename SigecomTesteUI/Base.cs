using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.Threading;

namespace SigecomTesteUI
{
    [TestClass]
    public class Base : UtilManipularCamposDaTela
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string AppId = @"C:\SIGECOM\SIGECOM.exe";

        protected WindowsDriver<WindowsElement> WindowsDriver;

        public void Setup()
        {
            Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
            if (WindowsDriver == null)
            {
                AppiumOptions appCapabilities = new AppiumOptions();
                appCapabilities.AddAdditionalCapability("app", AppId);
                WindowsDriver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
                Assert.IsNotNull(WindowsDriver);

                WindowsDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            }
        }

        public void EncerrarSessao()
        {
            WindowsDriver = null; ;
        }

        public void TrocarJanela()
        {
            // Identify the current window handle. You can check through inspect.exe which window this is.
            var currentWindowHandle = WindowsDriver.CurrentWindowHandle;
            // Wait for 5 seconds or however long it is needed for the right window to appear/for the splash screen to be dismissed
            Thread.Sleep(TimeSpan.FromSeconds(3));
            // Return all window handles associated with this process/application.
            // At this point hopefully you have one to pick from. Otherwise you can
            // simply iterate through them to identify the one you want.
            var allWindowHandles = WindowsDriver.WindowHandles;
            // Assuming you only have only one window entry in allWindowHandles and it is in fact the correct one,
            // switch the session to that window as follows. You can repeat this logic with any top window with the same
            // process id (any entry of allWindowHandles)
            WindowsDriver.SwitchTo().Window(allWindowHandles[0]);
        }

        [TestInitialize]
        public void Logar()
        {
            Setup();
            var txtUsuario = WindowsDriver.FindElementByAccessibilityId("txtUsuario");
            DigitarNoCampo(txtUsuario, "Douglas");
            var txtSenha = WindowsDriver.FindElementByAccessibilityId("txtSenha");
            DigitarNoCampoEnter(txtSenha, "123");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            TrocarJanela();
            var janelaAtual = WindowsDriver.FindElementByName("Sistema de gestão comercial");
            Verificar(janelaAtual, "SIGECOM - Sistema de Gestão Comercial - SISTEMASBR");
        }

        [TestCleanup]
        public void FecharSistema()
        {
            var sairLogin = WindowsDriver.FindElementByName("Sair/Login");
            ClicarBotaoName(sairLogin);
            TrocarJanela();
            var janelaAtual = WindowsDriver.FindElementByName("Sistema de gestão comercial");
            Verificar(janelaAtual, "Sistema de gestão comercial");

            var fechar = WindowsDriver.FindElementByName("Fechar");
            ClicarBotaoName(fechar);
            EncerrarSessao();
        }
    }
}
