using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.Threading;

namespace SigecomTesteUI
{
    class LoginPage : Base
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string AppId = @"C:\SIGECOM\SIGECOM.exe";

        private WindowsDriver<WindowsElement> _windowsDriver;

        // Elementos
        public WindowsElement Usuario => _windowsDriver.FindElementByAccessibilityId("txtUsuario");
        public WindowsElement Senha => _windowsDriver.FindElementByAccessibilityId("txtSenha");
        
        // Ações
        
        
    }
}
