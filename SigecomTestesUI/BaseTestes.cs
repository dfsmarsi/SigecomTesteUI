using Autofac;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Login;
using SigecomTestesUI.Services;
using System;

namespace SigecomTestesUI
{
    [TestFixture]
    [AllureNUnit]
    public class BaseTestes
    {
        public DriverService DriverService;
        private readonly LoginPage _loginPage;
        private readonly WindowsDriver<WindowsElement> _windowsDriver;

        public BaseTestes()
        {
            ControleDeInjecaoAutofac.ConstruirContainerComDependencias();
            var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();

            var resolveDriveFabrica = beginLifetimeScope.Resolve<Func<WindowsDriver<WindowsElement>, DriverService>>();
            _windowsDriver = beginLifetimeScope.Resolve<DriverFabrica>().CriarDriver();
            DriverService = resolveDriveFabrica(_windowsDriver);

            var resolveLoginPage = beginLifetimeScope.Resolve<Func<DriverService, LoginPage>>();
            _loginPage = resolveLoginPage(DriverService);
        }

        [SetUp]
        public void Setup() => 
            Assert.IsTrue(_loginPage.Logar());

        [TearDown]
        public void TearDown() =>
            _loginPage.FecharSistema();
    }
}