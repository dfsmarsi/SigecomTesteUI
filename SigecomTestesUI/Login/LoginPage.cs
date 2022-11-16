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
        private readonly Dictionary<string, string> _dadosLogin
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

        public bool ValidarPreenchimentoFormLogin() =>
            DriverService.ObterValorElementoId(_elementoUsuario) == _dadosLogin["Usuario"] &&
            DriverService.ObterValorElementoId(_elementoSenha) == _dadosLogin["Senha"];

        public bool Logar()
        {
            if (!ValidarAberturaDeTela(_elementoTelaLogin)) return false;

            PreencherLogin();
            EsperarAcaoEmSegundos(2);
            DriverService.TrocarJanela();
            return ValidarAberturaDeTela(_elementoTelaPrincipal);
        }
    }
}
