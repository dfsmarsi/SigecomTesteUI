using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;

namespace SigecomTesteUI
{
    [TestClass]
    class Base
    {
        private WindowsDriver<WindowsElement> _driver;

        public Base(WindowsDriver<WindowsElement> _driver)
        {
            this._driver = _driver;
        }

        [TestInitialize]
        public void Logar()
        {

            _driver.Setup();
            DigitarNoCampo("txtUsuario", "Douglas");
            DigitarNoCampoEnter("txtSenha", "123");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            TrocarJanela();
            Verificar("SIGECOM - Sistema de Gestão Comercial - SISTEMASBR", "SIGECOM - Sistema de Gestão Comercial - SISTEMASBR");
        }
        [TestCleanup]
        public void FecharSistema()
        {
            ClicarBotaoName("Sair/Login");
            TrocarJanela();
            Verificar("Sistema de gestão comercial", "Sistema de gestão comercial");
            ClicarBotaoName("Fechar");
            EncerrarSessao();
        }
    }
}
