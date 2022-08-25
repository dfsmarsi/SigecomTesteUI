using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Fornecedor
{
    public class CadastroDeFornecedorPage : PageObjectModel
    {
        private const string _botaoMenu = "Cadastro";
        private const string _botaoSubMenu = "Clientes";
        private const string _botaoNovo = "F2 - Novo";
        private const string _botaoGravar = "F5 - Gravar";
        private const string _elementoTipoPessoa = "cbxPessoaClassificacao";
        private const string _elementoNome = "txtNome";
        private const string _elementoCpf = "txtCPF";
        private const string _elementoCep = "txtCEP";
        private const string _elementoNumero = "txtNumero";

        private Dictionary<string, string> dados = new Dictionary<string, string>() {
            {"Nome","Joao Penca"},
            {"Cpf","43671566051"},
            {"Cep","15700082"},
            {"Numero","123"},
        };


        public CadastroDeFornecedorPage(DriverService driver) : base(driver) { }

        //public bool AbrirCadastroCliente()
        //{
        //    try
        //    {
        //        AcessarOpcaoMenu(_botaoMenu, _botaoSubMenu);

        //        return true;
        //    }
        //    catch (System.Exception)
        //    {
        //        return false;
        //    }
        //}

        //public bool ClicarBotaoNovo()
        //{
        //    try
        //    {
        //        DriverService.ClicarBotaoName(_botaoNovo);

        //        return true;
        //    }
        //    catch (System.Exception)
        //    {
        //        return false;
        //    }
        //}

        //public bool VerificarTipoPessoa()
        //{
        //    var valorTipoPessoa = DriverService.ObterValorElementoId(_elementoTipoPessoa);
        //    if (valorTipoPessoa != "FÍSICA")
        //        return false;
        //    return true;
        //}

        //public bool PreencherCampos()
        //{
        //    try
        //    {
        //        DriverService.DigitarNoCampoId(_elementoNome, dados["Nome"]);
        //        DriverService.DigitarNoCampoId(_elementoCpf, dados["Cpf"]);
        //        DriverService.DigitarNoCampoEnterId(_elementoCep, dados["Cep"]);
        //        Esperar3Segundos();
        //        DriverService.DigitarNoCampoId(_elementoNumero, dados["Numero"]);

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool GravarCadastro()
        //{
        //    try
        //    {
        //        DriverService.ClicarBotaoName(_botaoGravar);

        //        return true;
        //    }
        //    catch (System.Exception)
        //    {
        //        return false;
        //    }
        //}

    }
}
