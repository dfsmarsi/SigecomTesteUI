using SigecomTestesUI.Config;
using SigecomTestesUI.Login;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace SigecomTestesUI.Sigecom.Cadastros.Cliente
{
    [Binding]
    [CollectionDefinition(nameof(TestesFixture))]
    public class CadastroDeClienteSteps
    {
        private readonly LoginPage _loginPage;
        private readonly TestesFixture _testesFixture;
        private readonly CadastroDeClientePage _cadastroClientePage;

        public CadastroDeClienteSteps(TestesFixture testesFixture)
        {
            _testesFixture = testesFixture;
            _loginPage = new LoginPage(testesFixture.DriverService);
            _cadastroClientePage = new CadastroDeClientePage(testesFixture.DriverService);
        }

        [Given(@"Que o sistema esteja aberto")]
        public void DadoQueOSistemaEstejaAberto()
        {
            var login = _loginPage.Logar();
            
            Assert.True(login);
        }
        
        [Given(@"Aberto o formulario de cadastro de cliente")]
        public void DadoAbertoOFormularioDeCadastroDeCliente()
        {
            var abrirCadastroCliente = _cadastroClientePage.AbrirCadastroCliente();

            Assert.True(abrirCadastroCliente);
        }

        [Given(@"Clicar no botao Novo")]
        public void DadoClicarNoBotaoNovo()
        {
            var clicarBotaoNovo = _cadastroClientePage.ClicarBotaoNovo();

            Assert.True(clicarBotaoNovo);
        }

        [When(@"Confirmar que o tipo de pessoa fisica ja esteja selecionado")]
        public void QuandoConfirmarQueOTipoDePessoaFisicaJaEstejaSelecionado()
        {
            var verificarTipoPessoa = _cadastroClientePage.VerificarTipoPessoa();

            Assert.True(verificarTipoPessoa);
        }
        
        [When(@"Preencher os campos obrigatorios")]
        public void QuandoPreencherOsCamposObrigatorios(Table table)
        {
            
        }
        
        [When(@"Clicar em gravar")]
        public void QuandoClicarEmGravar()
        {
            
        }
        
        [Then(@"O nome do cliente deve aparecer na tela de pesquisa de cliente")]
        public void EntaoONomeDoClienteDeveAparecerNaTelaDePesquisaDeCliente()
        {
            
        }
    }
}
