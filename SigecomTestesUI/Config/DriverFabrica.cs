using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;

namespace SigecomTesteUI.Config
{
    public class DriverFabrica
    {
        public const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        public const string AppId = @"C:\SIGECOM\SIGECOM.exe";

        public WindowsDriver<WindowsElement> CriarDriver()
        {
            WindowsDriver<WindowsElement> driver;

            AbrirWinAppDriver();

            AppiumOptions appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("app", AppId);
            driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appOptions);
            Assert.NotNull(driver);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);


            return driver;
        }

        public void AbrirWinAppDriver()
        {
            string WinAppDriver = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";
            Process.Start(WinAppDriver);
        }
    }
}
