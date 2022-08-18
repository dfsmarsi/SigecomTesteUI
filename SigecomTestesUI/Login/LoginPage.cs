using OpenQA.Selenium.Appium.Windows;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using System.Collections.Generic;

namespace SigecomTestesUI.Login
{
    public class LoginPage : PageObjectModel
    {
        private WindowsElement _usuarioWindowsElement;
        private WindowsElement _senhaWindowsElement;
        private WindowsElement _telaLoginWindowsElement;
        private WindowsElement _telaPrincipalWindowsElement;

        public LoginPage(DriverService driver) : base(driver){
            MapearElementos();
        }

        public void MapearElementos()
        {
            _usuarioWindowsElement = DriverService.EncontrarElementoId("txtUsuario");
            _senhaWindowsElement = DriverService.EncontrarElementoId("txtSenha");
            _telaLoginWindowsElement = DriverService.EncontrarElementoName("Sistema de gestão comercial");
            _telaPrincipalWindowsElement = DriverService.EncontrarElementoName("SIGECOM - Sistema de Gestão Comercial - SISTEMASBR");
        }

        public void PreencherLogin(Dictionary<string, string> dados)
        {
            DriverService.DigitarNoCampo(_usuarioWindowsElement, dados["Usuario"]);
            DriverService.DigitarNoCampoEnter(_senhaWindowsElement, dados["Senha"]);
        }

        public bool ValidarPreenchimentoFormLogin(Dictionary<string, string> dados)
        {
            if (DriverService.ObterValorElementoId(_usuarioWindowsElement) != dados["Usuario"])
                return false;
            if (DriverService.ObterValorElementoId(_usuarioWindowsElement) != dados["Senha"])
                return false;

            return true;
        }

        public bool Logar(Dictionary<string, string> dados)
        {
            if(!ValidarAberturaDeTela(_telaLoginWindowsElement, "Sistema de gestão comercial"))
                return false;
            PreencherLogin(dados);
            DriverService.TrocarJanela();
            if (!ValidarAberturaDeTela(_telaPrincipalWindowsElement, "SIGECOM - Sistema de Gestão Comercial - SISTEMASBR"))
                return false;

            return true;
        }
    }
}
