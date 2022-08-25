using SigecomTestesUI.Services;
using System;
using System.Threading;

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
                DriverService.DarDuploCliqueNoBotaoName(menu);
                DriverService.ClicarBotaoName(opcaoSubMenu);

                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public void Esperar3Segundos()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        public void FecharSistema()
        {
            DriverService.Dispose();
        }
    }
}
