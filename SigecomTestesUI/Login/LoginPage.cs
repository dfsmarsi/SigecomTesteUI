using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Login.Model;
using System.Collections.Generic;
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
            DriverService.EsperarAbrirTelaDeLogin(60, LoginPageModel.ElementoTelaLogin);

            PreencherLogin();
            EsperarAcaoEmSegundos(3);
            DriverService.TrocarJanela();
            return ValidarAberturaDeTela(LoginPageModel.ElementoTelaPrincipal);
        }
    }
}
