using OpenQA.Selenium.Appium.Windows;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;

namespace SigecomTestesUI.Sigecom.Cadastros.Cliente
{
    public class CadastroDeClientePage : PageObjectModel
    {
        private WindowsElement _tipoPessoaWindowsElement;
        private WindowsElement _nomeWindowsElement;
        private WindowsElement _cpfWindowsElement;
        private WindowsElement _cepWindowsElement;
        private WindowsElement _numeroWindowsElement;

        public CadastroDeClientePage(DriverService driver) : base(driver)
        {
            MapearElementos();
        }

        public void MapearElementos()
        {
            _tipoPessoaWindowsElement = DriverService.EncontrarElementoId("cbxPessoaClassificacao");
            _nomeWindowsElement = DriverService.EncontrarElementoId("txtNome");
            _cpfWindowsElement = DriverService.EncontrarElementoId("txtCPF");
            _cepWindowsElement = DriverService.EncontrarElementoId("txtCEP");
            _numeroWindowsElement = DriverService.EncontrarElementoId("txtNumero");
        }
    }
}
