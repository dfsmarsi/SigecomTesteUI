using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;


namespace SigecomTesteUI
{
    public class UtilManipularCamposDaTela
    {

        public void DigitarNoCampo(WindowsElement elemento, string texto)
        {
            elemento.SendKeys(texto);
        }
        public void DigitarNoCampoEnter(WindowsElement elemento, string texto)
        {
            elemento.SendKeys(texto);
            elemento.SendKeys(Keys.Enter);
        }
        public void DigitarNoCampoESelecionarNaPesquisa(WindowsElement elemento, string texto)
        {
            elemento.SendKeys(texto);
            elemento.SendKeys(Keys.Enter);
        }

        public void ClicarBotaoName(WindowsElement elemento)
        {
            elemento.Click();
        }
        public void ClicarBotaoId(WindowsElement elemento)
        {
            elemento.Click();
        }
        public void DoubleClickBotao(WindowsElement elemento, Actions acao)
        {
            acao.MoveToElement(elemento);
            acao.DoubleClick();
            acao.Perform();
        }

        public void Verificar(WindowsElement elemento, string valor)
        {
            Assert.AreEqual(elemento.Text, valor);
        }

        public void SelecionarItemComboBox(WindowsElement elemento, int posicao)
        {
            elemento.Click();
            for (int i = 1; i <= posicao; i++)
                elemento.SendKeys(Keys.ArrowDown);
            elemento.SendKeys(Keys.Enter);
        }

        public void VerificarCadastroRealizado(string nomeTelaPesquisa, string stringPesquisa)
        {
            _windowsDriver.FindElementByName("F9 - Pesquisar").Click();
            Verificar(nomeTelaPesquisa, nomeTelaPesquisa);
            var campo = _windowsDriver.FindElementByAccessibilityId("textEditParametroDePesquisa");
            campo.SendKeys(stringPesquisa);
            campo.SendKeys(Keys.Enter);
            var nomeDaGrid = _windowsDriver.FindElementByName("Nome row 0").Text;
            Assert.AreEqual(stringPesquisa, nomeDaGrid);
        }
        public void FecharJanelaComEsc(string nomeJanela)
        {
            var janela = _windowsDriver.FindElementByName(nomeJanela);
            janela.SendKeys(Keys.Escape);
        }
    }
}
