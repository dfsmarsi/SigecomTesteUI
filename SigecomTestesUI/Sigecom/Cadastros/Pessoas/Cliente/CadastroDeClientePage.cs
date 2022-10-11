using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente
{
    public class CadastroDeClientePage : PageObjectModel
    {
        private const string _botaoMenu = "Cadastro";
        private const string _botaoSubMenu = "Clientes";
        private const string _elementoTelaCadastroCliente = "Cadastro de clientes";
        private const string _botaoNovo = "F2 - Novo";
        private const string _botaoGravar = "F5 - Gravar";
        private const string _botaoPesquisar = "F9 - Pesquisar";
        private const string _elementoTipoPessoa = "cbxPessoaClassificacao";
        private const string _elementoNome = "txtNome";
        private const string _elementoCpf = "txtCPF";
        private const string _elementoCep = "txtCEP";
        private const string _elementoNumero = "txtNumero";

        private readonly Dictionary<string, string> _dados;

        public CadastroDeClientePage(DriverService driver, Dictionary<string, string> dados) : base(driver) 
        {
            _dados = dados;
        }

        public bool ClicarNaOpcaoDoMenu()
        {
            var acessadoMenu = AcessarOpcaoMenu(_botaoMenu);
            return acessadoMenu;
        }

        public bool ClicarNaOpcaoDoSubMenu()
        {
            var acessadoSubMenu = AcessarOpcaoSubMenu(_botaoSubMenu);
            return acessadoSubMenu;
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

        public bool ClicarBotaoPesquisar()
        {
            try
            {
                DriverService.ClicarBotaoName(_botaoPesquisar);

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
                DriverService.DigitarNoCampoId(_elementoNome, _dados["Nome"]);
                DriverService.DigitarNoCampoId(_elementoCpf, _dados["Cpf"]);
                DriverService.DigitarNoCampoEnterId(_elementoCep, _dados["Cep"]);
                EsperarAcaoEmSegundos(2);
                DriverService.DigitarNoCampoId(_elementoNumero, _dados["Numero"]);

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
                DriverService.FecharJanelaComEsc(_elementoTelaCadastroCliente);

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
