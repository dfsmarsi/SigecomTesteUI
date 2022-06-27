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
            Verificar("SIGECOM - Sistema de Gestão Comercial - SISTEMASBR", "SIGECOM - Sistema de Gestão Comercial - SISTEMASBR");
        }
        [TestCleanup]
        public void FecharSistema()
        {
            ClicarBotaoName("Sair/Login");
            TrocarJanela();
            Verificar("Sistema de gestão comercial", "Sistema de gestão comercial");
            ClicarBotaoName("Fechar");
            EncerrarSessao();
        }
    }
}
