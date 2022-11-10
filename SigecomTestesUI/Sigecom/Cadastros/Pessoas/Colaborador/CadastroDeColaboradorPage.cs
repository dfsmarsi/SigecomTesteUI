using System;
using System.Collections.Generic;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador
{
    public class CadastroDeColaboradorPage : PageObjectModel
    {
        private const string _botaoMenu = "Cadastro";
        private const string _botaoSubMenu = "Colaboradores";
        private const string _telaCadastroColaborador = "Cadastro de colaboradores";
        private const string _botaoNovo = "F2 - Novo";
        private const string _botaoGravar = "F5 - Gravar";
        private const string _botaoPesquisar = "F9 - Pesquisar";
        private const string _elementoTipoPessoa = "cbxPessoaClassificacao";
        private const string _elementoNome = "txtNome";
        private const string _elementoCpf = "txtCPF";
        private const string _elementoCep = "txtCEP";
        private const string _elementoNumero = "txtNumero";

        private readonly Dictionary<string, string> _dados;

        public CadastroDeColaboradorPage(DriverService driver, Dictionary<string, string> dados) : base(driver) => 
            _dados = dados;

        public bool ClicarNaOpcaoDoMenu()
        {
            try
            {
                AcessarOpcaoMenu(_botaoMenu);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ClicarNaOpcaoDoSubMenu()
        {
            try
            {
                AcessarOpcaoSubMenu(_botaoSubMenu);
                return true;
            }
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
            {
                return false;
            }
        }

        public bool VerificarTipoPessoa()
        {
            var valorTipoPessoa = DriverService.ObterValorElementoId(_elementoTipoPessoa);
            return valorTipoPessoa == "FÍSICA";
        }

        public bool PreencherCampos()
        {
            try
            {
                DriverService.DigitarNoCampoId(_elementoNome, _dados["Nome"]);
                DriverService.DigitarNoCampoId(_elementoCpf, _dados["Cpf"]);
                DriverService.DigitarNoCampoEnterId(_elementoCep, _dados["Cep"]);
                EsperarAcaoEmSegundos(5);
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
            catch (Exception)
            {
                return false;
            }
        }

        public bool FecharJanelaCadastroColaboradorComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(_telaCadastroColaborador);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
