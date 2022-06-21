using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace SigecomTesteUI
{
    [TestClass]
    public class CadastroCliente : Base
    {
        [TestMethod]
        public void CadastrarClienteNovo()
        {
            DoubleClickBotao("Cadastro");
            ClicarBotao("Clientes");
            ClicarBotao("F2 - Novo");
            DigitarNoCampo("txtNome", "Joao Penca");
            DigitarNoCampo("txtCPF", "43671566051");
            DigitarNoCampo("txtRG", "52195129X");
            DigitarNoCampoEnter("txtCEP", "15700082");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            DigitarNoCampo("txtNumero", "123");
            ClicarBotao("F5 - Gravar");
            VerificarCadastroRealizado("Pesquisa de cliente", "JOAO PENCA");
            FecharJanelaComEsc("Pesquisa de cliente");
            FecharJanelaComEsc("Cadastro de clientes");
        }
    }
}
