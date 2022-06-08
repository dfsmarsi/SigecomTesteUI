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
            Thread.Sleep(20000);
            TrocarJanela();
            Verificar("SIGECOM - Sistema de Gestão Comercial - NFCE", "SIGECOM - Sistema de Gestão Comercial - NFCE");
        }
        [TestMethod]
        public void CadastrarProdutoNovo()
        {
            ClicarBotao("Cadastro");
        }
    }
}
