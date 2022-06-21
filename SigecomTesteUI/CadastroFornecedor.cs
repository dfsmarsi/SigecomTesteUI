using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace SigecomTesteUI
{
    [TestClass]
    public class CadastroFornecedor : Base
    {
        [TestMethod]
        public void CadastrarFornecedorNovo()
        {
            DoubleClickBotao("Cadastro");
            ClicarBotao("Fornecedores");
            ClicarBotao("F2 - Novo");
            DigitarNoCampo("txtNome", "FORNECEDOR BATUTA");
            DigitarNoCampo("txtCPF", "39920109029");
            DigitarNoCampo("txtRG", "111111111");
            DigitarNoCampoEnter("txtCEP", "15700082");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            DigitarNoCampo("txtNumero", "123");
            ClicarBotao("F5 - Gravar");
            VerificarCadastroRealizado("Pesquisa de fornecedor", "FORNECEDOR BATUTA");
            FecharJanelaComEsc("Pesquisa de fornecedor");
            FecharJanelaComEsc("Cadastro de fornecedores");
        }
    }
}
