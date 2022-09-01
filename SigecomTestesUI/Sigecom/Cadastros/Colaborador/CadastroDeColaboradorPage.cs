using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Colaborador
{
    public class CadastroDeColaboradorPage : PageObjectModel
    {
        private const string _botaoMenu = "Cadastro";
        private const string _botaoSubMenu = "Colaboradores";
        private const string _telaCadastroColaborador = "Cadastro de colaboradores";
        private const string _botaoNovo = "F2 - Novo";
        private const string _botaoGravar = "F5 - Gravar";
        private const string _elementoTipoPessoa = "cbxPessoaClassificacao";
        private const string _elementoNome = "txtNome";
        private const string _elementoCpf = "txtCPF";
        private const string _elementoCep = "txtCEP";
        private const string _elementoNumero = "txtNumero";

        private Dictionary<string, string> dados = new Dictionary<string, string>() {
            {"Nome","Rony Rustico"},
            {"Cpf","28061149001"},
            {"Cep","15700082"},
            {"Numero","333"},
        };


        public CadastroDeColaboradorPage(DriverService driver) : base(driver) { }

        public bool AbrirCadastroColaborador()
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

        public bool PreencherCampos()
        {
            try
            {
                DriverService.DigitarNoCampoId(_elementoNome, dados["Nome"]);
                DriverService.DigitarNoCampoId(_elementoCpf, dados["Cpf"]);
                DriverService.DigitarNoCampoEnterId(_elementoCep, dados["Cep"]);
                Esperar3Segundos();
                DriverService.DigitarNoCampoId(_elementoNumero, dados["Numero"]);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool GravarCadastro()
        {
            try
            {
                DriverService.ClicarBotaoName(_botaoGravar);

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool FecharJanelaComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(_telaCadastroColaborador);

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
