using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace SigecomTesteUI.Views.Cadastros.Fornecedor
{
    [TestClass]
    public class CadastroFornecedorTests : Base
    {
        private CadastroFornecedorPage _cadastroFornecedorPage;
        
        [TestMethod]
        public void CadastrarFornecedorNovo()
        {
            _cadastroFornecedorPage = new CadastroFornecedorPage(_driver);
            DoubleClickBotao("Cadastro");
            ClicarBotaoName("Fornecedores");
            ClicarBotaoName("F2 - Novo");
            DigitarNoCampo("txtNome", "FUSKAS TELEMARKETING");
            DigitarNoCampo("txtCPF", "39920109029");
            DigitarNoCampo("txtRG", "111111111");
            DigitarNoCampoEnter("txtCEP", "15700082");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            DigitarNoCampo("txtNumero", "123");
            ClicarBotaoName("F5 - Gravar");
            VerificarCadastroRealizado("Pesquisa de fornecedor", "FUSKAS TELEMARKETING");
            FecharJanelaComEsc("Pesquisa de fornecedor");
            FecharJanelaComEsc("Cadastro de fornecedores");
        }
    }
}
