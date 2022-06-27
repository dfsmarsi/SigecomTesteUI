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
            //Abrir formulario
            DoubleClickBotao("Cadastro");
            ClicarBotaoName("Clientes");
            ClicarBotaoName("F2 - Novo");
            //Dados Pessoais
            DigitarNoCampo("txtIdentificador", "id");
            DigitarNoCampo("txtNome", "WUDSHOW");
            DigitarNoCampo("txtCPF", "43671566051");
            DigitarNoCampo("txtRG", "52195129X");
            DigitarNoCampo("txtApelido", "Braia");
            SelecionarItemComboBox("cbxSexo", 1);
            DigitarNoCampo("txtDataNascimento", "25122000");
            SelecionarItemComboBox("cbxEstadoCivil", 1);
            DigitarNoCampoEnter("txtCEP", "15700082");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            DigitarNoCampo("txtNumero", "123");
            DigitarNoCampo("txtComplemento", "ao lado do bar do NEY");
            //DigitarNoCampoESelecionarNaPesquisa("txtProfissao","analista da qualidade");
            DigitarNoCampo("txtContatos", "Falar com o Will");
            DigitarNoCampo("txtObservacao", "Digita BANANA ai...");
            //Contato
            SelecionarItemComboBox("cbxPessoaContatoTipo", 3);
            DigitarNoCampo("txtContato", "17996461069");
            DigitarNoCampo("txtObsContato", "cel do Braia");
            ClicarBotaoId("btnAddContato");
            //Aviso de venda
            DigitarNoCampo("txtAvisoDeVenda", "Ele vai perguntar se já usa uma casa de apostas");
            //Gravar e Verificar pesquisa
            ClicarBotaoName("F5 - Gravar");
            VerificarCadastroRealizado("Pesquisa de cliente", "WUDSHOW");
            FecharJanelaComEsc("Pesquisa de cliente");
            FecharJanelaComEsc("Cadastro de clientes");
        }
    }
}
