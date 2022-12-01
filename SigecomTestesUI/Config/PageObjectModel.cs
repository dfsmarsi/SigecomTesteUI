using SigecomTestesUI.Services;
using System;
using System.Threading;

namespace SigecomTestesUI.Config
{
    public abstract class PageObjectModel
    {
        protected readonly DriverService DriverService;

        protected PageObjectModel(DriverService driver) => DriverService = driver;

        public bool ValidarAberturaDeTela(string nomeTela) => 
            DriverService.ObterValorElementoName(nomeTela).Equals(nomeTela);

        public bool AcessarOpcaoMenu(string menu)
        {
            try
            {
                DriverService.DarDuploCliqueNoBotaoName(menu);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AcessarOpcaoSubMenu(string opcaoSubMenu)
        {
            try
            {
                DriverService.ClicarBotaoName(opcaoSubMenu);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void EsperarAcaoEmSegundos(int tempoEmSegundos) => 
            Thread.Sleep(TimeSpan.FromSeconds(tempoEmSegundos));

        public void FecharSistema() => 
            DriverService.Dispose();
    }
}
