using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;

namespace SigecomTestesUI.Config
{
    public class DriverFabrica
    {
        public const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        public const string AppIdPadrao = @"C:\SIGECOM\SIGECOM.exe";
        public const string WinAppDriverPadrao = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";

        // O Gerenciador de Testes define estas variáveis; sem elas vale o caminho padrão.
        public static string AppId => ObterCaminho("SIGECOM_EXE", AppIdPadrao);
        public static string CaminhoWinAppDriver => ObterCaminho("WINAPPDRIVER_EXE", WinAppDriverPadrao);

        public WindowsDriver<WindowsElement> CriarDriver()
        {
            AbrirWinAppDriver();

            var appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("app", AppId);
            // O Sigecom demora a exibir a tela de login; sem isso o WinAppDriver desiste antes e deixa o Sigecom aberto.
            appOptions.AddAdditionalCapability("ms:waitForAppLaunch", "5");
            var driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appOptions);
            Assert.NotNull(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            return driver;
        }

        public void AbrirWinAppDriver()
        {
            Process.Start(CaminhoWinAppDriver);
        }

        private static string ObterCaminho(string variavel, string padrao)
        {
            var valor = Environment.GetEnvironmentVariable(variavel);
            return string.IsNullOrWhiteSpace(valor) ? padrao : valor;
        }
    }
}
