using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Threading;

namespace SigecomTesteUI
{
    [TestClass]
    public class TesteDev : AppiumDriver
    {
        [TestInitialize]
        public void Logar()
        {
            Setup();
            DigitarNoCampo("txtUsuario", "Douglas");
            DigitarNoCampoEnter("txtSenha", "123");
            Thread.Sleep(5000);
            TrocarJanela(0);
            Verificar("SIGECOM - Sistema de Gestão Comercial - NFCE", "SIGECOM - Sistema de Gestão Comercial - NFCE");
        }
        [TestMethod]
        public void CadastrarClienteNovo()
        {
            //Abrir tela de cadastro de Cliente e clicar no botão novo
            DoubleClickBotao("Cadastro");
            ClicarBotao("Clientes");
            ClicarBotao("F2 - Novo");
            DigitarNoCampo("txtNome", "Joao Penca");
            DigitarNoCampo("txtCPF", "43671566051");
            DigitarNoCampo("txtRG", "52195129X");
            DigitarNoCampoEnter("txtCEP", "15700082");
            Thread.Sleep(999);
            DigitarNoCampo("txtNumero", "123");
            ClicarBotao("F5 - Gravar");
            VerificarCadastroRealizado("Pesquisa de cliente", "JOAO PENCA");
            FecharJanelaComEsc("Pesquisa de cliente");
            FecharJanelaComEsc("Cadastro de clientes");
        }
    }
}
