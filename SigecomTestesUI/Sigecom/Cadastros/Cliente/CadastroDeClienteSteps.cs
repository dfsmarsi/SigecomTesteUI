using SigecomTestesUI.Config;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace SigecomTestesUI.Sigecom.Cadastros.Cliente
{
    [Binding]
    [CollectionDefinition(nameof(TestesFixture))]
    public class CadastroDeClienteSteps
    {
        private readonly CadastroDeClientePage _cadastroClientePage;
        private readonly TestesFixture _testesFixture;

        [Given(@"Que o sistema esteja aberto")]
        public void DadoQueOSistemaEstejaAberto()
        {
            
        }
        
        [Given(@"Aberto o formulario de cadastro de cliente")]
        public void DadoAbertoOFormularioDeCadastroDeCliente()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Clicar no botao Novo")]
        public void DadoClicarNoBotaoNovo()
        {
            ScenarioContext.Current.Pending();
        }


        [When(@"Confirmar que o tipo de pessoa fisica ja esteja selecionado")]
        public void QuandoConfirmarQueOTipoDePessoaFisicaJaEstejaSelecionado()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Preencher os campos obrigatorios")]
        public void QuandoPreencherOsCamposObrigatorios(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Clicar em gravar")]
        public void QuandoClicarEmGravar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"O nome do cliente deve aparecer na tela de pesquisa de cliente")]
        public void EntaoONomeDoClienteDeveAparecerNaTelaDePesquisaDeCliente()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
