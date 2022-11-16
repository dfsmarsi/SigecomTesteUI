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
        public readonly ILifetimeScope _lifetimeScope;

        public BaseTestes()
        {
            ControleDeInjecaoAutofac.ConstruirContainerComDependenciasSemCarregarDados();
            _lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();

            var resolveDriveFabrica = _lifetimeScope.Resolve<Func<WindowsDriver<WindowsElement>, DriverService>>();
            DriverService = resolveDriveFabrica(_lifetimeScope.Resolve<DriverFabrica>().CriarDriver());

            var resolveLoginPage = _lifetimeScope.Resolve<Func<DriverService, LoginPage>>();
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