using OpenQA.Selenium.Appium.Windows;

namespace SigecomTesteUI.Views.Cadastros.Fornecedor
{
    public partial class CadastroFornecedorPage : Base
    {
        public WindowsElement Menu => WindowsDriver.FindElementByName("Cadastro");
        public WindowsElement BotaoCadastroFornecedor => WindowsDriver.FindElementByName("Fornecedores");
        public WindowsElement NovoCadastroFornecedor => WindowsDriver.FindElementByName("F2 - Novo");
        public WindowsElement NomeFornecedor => WindowsDriver.FindElementByAccessibilityId("txtNome");
        public WindowsElement CpfFornecedor => WindowsDriver.FindElementByAccessibilityId("txtCPF");
        public WindowsElement RgFornecedor => WindowsDriver.FindElementByAccessibilityId("txtRG");
        //DigitarNoCampoEnter("txtCEP", "15700082");
        //Thread.Sleep(TimeSpan.FromSeconds(3));
        //DigitarNoCampo("txtNumero", "123");
        //ClicarBotaoName("F5 - Gravar");
        //VerificarCadastroRealizado("Pesquisa de fornecedor", "FUSKAS TELEMARKETING");
        //FecharJanelaComEsc("Pesquisa de fornecedor");
        //FecharJanelaComEsc("Cadastro de fornecedores");

    }
}
