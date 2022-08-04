using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace SigecomTesteUI
{
    public class CadastroFornecedorPage : Page
    {
        public CadastroFornecedorPage(DriverService driverService) : base(driverService)
        {
        }

        private WindowsElement Menu => RetornarElementoPorNome("Cadastro");
        private WindowsElement OpMenu => RetornarElementoPorNome("Fornecedores");
        private WindowsElement BotaoNovo => RetornarElementoPorNome("F2 - Novo");
        private WindowsElement TextBoxNome => RetornarElementoPorId("txtNome");
        //private WindowsElement TextBoxCpf => RetornarElementoPorId("txtCPF");
        //private WindowsElement TextBoxRg => RetornarElementoPorId("txtRG");
        //private WindowsElement TextBoxCep => RetornarElementoPorId("txtCEP");
        //private WindowsElement TextBoxNumero => RetornarElementoPorNome("txtNumero");
        //private WindowsElement BotaoGravar => RetornarElementoPorNome("F5 - Gravar");
        //private WindowsElement BotaoPesquisa => RetornarElementoPorNome("F9 - Pesquisar");
        //private WindowsElement ViewCadastroDeFornecedor => RetornarElementoPorNome("Cadastro de fornecedores");


        public override void RealizarTeste(Dictionary<string, string> dados)
        {
            DriverService.DoubleClickBotao(Menu);
            DriverService.ClicarBotao(OpMenu);
            DriverService.ClicarBotao(BotaoNovo);
            DriverService.DigitarNoCampo(TextBoxNome, dados["Nome"]);
        }      
    }
}
