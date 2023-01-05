using SigecomTestesUI.Config;
using System.Collections.Generic;
using OpenQA.Selenium;
using SigecomTestesUI.Login.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

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
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LoginPageModel.ElementoSenha, _dadosDoLogin["Senha"], Keys.Enter);
        }

        public bool ValidarPreenchimentoFormLogin() =>
            DriverService.ObterValorElementoId(LoginPageModel.ElementoUsuario) == _dadosDoLogin["Usuario"] &&
            DriverService.ObterValorElementoId(LoginPageModel.ElementoSenha) == _dadosDoLogin["Senha"];

        public bool Logar()
        {
            EsperarAcaoEmSegundos(3);
            if (!ValidarAberturaDeTela(LoginPageModel.ElementoTelaLogin)) return false;

            PreencherLogin();
            EsperarAcaoEmSegundos(6);
            DriverService.TrocarJanela();
            return ValidarAberturaDeTela(LoginPageModel.ElementoTelaPrincipal);
        }
    }
}
