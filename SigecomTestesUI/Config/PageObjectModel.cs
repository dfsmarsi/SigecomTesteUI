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

        public bool ValidarAberturaDeTela(string nomeTela)
        {
            if (DriverService.ObterValorElementoName(nomeTela) != nomeTela)
                return false;

            return true;
        }

        public bool AcessarOpcaoMenu(string menu, string opcaoSubMenu)
        {
            try
            {
                DriverService.DoubleClickBotaoName(menu);
                DriverService.ClicarBotaoName(opcaoSubMenu);

                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}
