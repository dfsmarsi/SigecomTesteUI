using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace SigecomTesteUI
{
    [TestClass]
    public class CadastroColaborador : Base
    {
        [TestMethod]
        public void CadastrarColaboradorNovo()
        {
            DoubleClickBotao("Cadastro");
            ClicarBotao("Colaboradores");
            ClicarBotao("F2 - Novo");
            DigitarNoCampo("txtNome", "HAUK LEE");
            DigitarNoCampo("txtCPF", "03250492035");
            DigitarNoCampo("txtRG", "222222222");
            DigitarNoCampoEnter("txtCEP", "15700082");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            DigitarNoCampo("txtNumero", "123");
            ClicarBotao("F5 - Gravar");
            VerificarCadastroRealizado("Pesquisa de funcionário", "HAUK LEE");
            FecharJanelaComEsc("Pesquisa de funcionário");
            FecharJanelaComEsc("Cadastro de colaboradores");
        }
    }
}
