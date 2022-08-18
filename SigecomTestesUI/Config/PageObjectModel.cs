using OpenQA.Selenium.Appium.Windows;
using SigecomTestesUI.Services;

namespace SigecomTestesUI.Config
{
    public abstract class PageObjectModel
    {
        protected readonly DriverService DriverService;

        protected PageObjectModel(DriverService driver)
        {
            DriverService = driver;
        }

        public bool ValidarAberturaDeTela(WindowsElement elemento, string nomeTela)
        {
            if (DriverService.ObterValorElementoName(elemento) != nomeTela)
                return false;

            return true;
        }
    }
}
