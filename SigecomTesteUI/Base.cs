using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace SigecomTesteUI
{
    [TestClass]
    public class Base : AppiumDriver
    {
        [TestInitialize]
        public void Logar()
        {
            Setup();
            DigitarNoCampo("txtUsuario", "Douglas");
            DigitarNoCampoEnter("txtSenha", "123");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            TrocarJanela();
            Verificar("SIGECOM - Sistema de Gestão Comercial - NFCE", "SIGECOM - Sistema de Gestão Comercial - NFCE");
        }
        [TestCleanup]
        public void FecharSistema()
        {
            ClicarBotao("Sair/Login");
            TrocarJanela();
            Verificar("Sistema de gestão comercial", "Sistema de gestão comercial");
            ClicarBotao("Fechar");
            EncerrarSessao();
        }
    }
}
