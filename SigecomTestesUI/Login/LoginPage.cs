using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using System.Collections.Generic;
using SigecomTestesUI.Login.Model;

namespace SigecomTestesUI.Login
{
    public class LoginPage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dadosDoLogin
            = new Dictionary<string, string>{
                {"Usuario","Douglas"},
                {"Senha", "123"}
            };

        public LoginPage(DriverService driver) : base(driver) {}

        public void PreencherLogin()
        {
            DriverService.DigitarNoCampoId(LoginPageModel.ElementoUsuario, _dadosDoLogin["Usuario"]);
            DriverService.DigitarNoCampoEnterId(LoginPageModel.ElementoSenha, _dadosDoLogin["Senha"]);
        }

        public bool ValidarPreenchimentoFormLogin() =>
            DriverService.ObterValorElementoId(LoginPageModel.ElementoUsuario) == _dadosDoLogin["Usuario"] &&
            DriverService.ObterValorElementoId(LoginPageModel.ElementoSenha) == _dadosDoLogin["Senha"];

        public bool Logar()
        {
            if (!ValidarAberturaDeTela(LoginPageModel.ElementoTelaLogin)) return false;

            PreencherLogin();
            EsperarAcaoEmSegundos(2);
            DriverService.TrocarJanela();
            return ValidarAberturaDeTela(LoginPageModel.ElementoTelaPrincipal);
        }
    }
}
