using OpenQA.Selenium.Appium.Windows;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;

namespace SigecomTestesUI.Sigecom.Cadastros.Cliente
{
    public class CadastroDeClientePage : PageObjectModel
    {
        private string _botaoMenu = "Cadastro";
        private string _botaoSubMenu = "Clientes";
        private string _botaoNovo = "F2 - Novo";
        private string _elementoTipoPessoa = "cbxPessoaClassificacao";
        private string _elementoNome = "txtNome";
        private string _elementoCpf = "txtCPF";
        private string _elementoCep = "txtCEP";
        private string _elementoNumero = "txtNumero";

        public CadastroDeClientePage(DriverService driver) : base(driver) { }

        public bool AbrirCadastroCliente()
        {
            try
            {
                AcessarOpcaoMenu(_botaoMenu, _botaoSubMenu);

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool ClicarBotaoNovo()
        {
            try
            {
                DriverService.ClicarBotaoName(_botaoNovo);

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool VerificarTipoPessoa()
        {
            var valorTipoPessoa = DriverService.ObterValorElementoId(_elementoTipoPessoa);
            if (valorTipoPessoa != "FÍSICA")
                return false;
            return true;
        }
    }
}
