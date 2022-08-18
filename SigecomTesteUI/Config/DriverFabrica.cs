using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;

namespace SigecomTesteUI.Config
{
    public static class DriverFabrica
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string AppId = @"C:\SIGECOM\SIGECOM.exe";

        public static WindowsDriver<WindowsElement> CriarDriver()
        {
            WindowsDriver<WindowsElement> driver = null;
            IniciarWinAppDriver();
            if (driver == null)
            {
                AppiumOptions appCapabilities = new AppiumOptions();
                appCapabilities.AddAdditionalCapability("app", AppId);
                driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
                Assert.IsNotNull(driver);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }

            return driver;
        }

        private static void IniciarWinAppDriver()
        {
            Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
        }
    }
}
