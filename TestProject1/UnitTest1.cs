using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;

namespace TestProject1
{
    public class Tests
    {
        public WindowsDriver<WindowsElement> driver;
        [SetUp]
        public void Setup()
        {
            string WinAppDriver = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";
            Process.Start(WinAppDriver);
            AppiumOptions appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("app", @"C:\SIGECOM\SIGECOM.exe");
            driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appOptions);
            Assert.NotNull(driver);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        [Test]
        public void Test1()
        {
            driver.FindElementByAccessibilityId("txtUsuario").SendKeys("DOUGLAS");
            driver.FindElementByAccessibilityId("txtSenha").SendKeys("123");
        }
    }
}