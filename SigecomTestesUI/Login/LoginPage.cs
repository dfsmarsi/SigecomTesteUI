using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using System.Collections.Generic;

namespace SigecomTestesUI.Login
{
    public class LoginPage : PageObjectModel
    {

        private string _elementoUsuario = "txtUsuario";
        private string _elementoSenha = "txtSenha";
        private string _elementoTelaLogin = "Sistema de gestão comercial";
        private string _elementoTelaPrincipal = "SIGECOM - Sistema de Gestão Comercial - SISTEMASBR";
        private Dictionary<string, string> _dadosLogin
            = new Dictionary<string, string>{
                {"Usuario","Douglas"},
                {"Senha", "123"}
            };

        public LoginPage(DriverService driver) : base(driver) {}

        public void PreencherLogin()
        {
            DriverService.DigitarNoCampoId(_elementoUsuario, _dadosLogin["Usuario"]);
            DriverService.DigitarNoCampoEnterId(_elementoSenha, _dadosLogin["Senha"]);
        }

        public bool ValidarPreenchimentoFormLogin()
        {
            if (DriverService.ObterValorElementoId(_elementoUsuario) != _dadosLogin["Usuario"])
                return false;
            if (DriverService.ObterValorElementoId(_elementoSenha) != _dadosLogin["Senha"])
                return false;

            return true;
        }

        public bool Logar()
        {
            if (!ValidarAberturaDeTela(_elementoTelaLogin))
                return false;
            PreencherLogin();
            Esperar3Segundos();
            DriverService.TrocarJanela();
            if (!ValidarAberturaDeTela(_elementoTelaPrincipal))
                return false;

            return true;
        }
    }
}
