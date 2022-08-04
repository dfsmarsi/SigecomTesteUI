using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace SigecomTesteUI
{
    public class Page
    {
        protected DriverService DriverService;

        public Page(DriverService driverService) => DriverService = driverService;

        public virtual void RealizarTeste(Dictionary<string, string> dados)
        {}

        protected WindowsElement RetornarElementoPorNome(string nomeCampo) 
            => DriverService.RetornarSessao().FindElementByName(nomeCampo);

        protected WindowsElement RetornarElementoPorId(string nomeCampo)
            => DriverService.RetornarSessao().FindElementByAccessibilityId(nomeCampo);
    }
}
