using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SigecomTesteUI
{
    [TestClass]
    public class Base
    {
        public Page pageTeste;
        protected DriverService DriverService;

        [TestInitialize]
        public void AbrirSistema()
        {
            var dictionaryDados = new Dictionary<string, string>() {
                { "Usuario", "Douglas" },
                { "Senha", "123" },
                { "NomeTelaPrincipal", "SIGECOM - Sistema de Gestão Comercial - SISTEMASBR" }
            };
            DriverService = new DriverService();
            DriverService.Setup();
            pageTeste = new LoginPage(DriverService);
            pageTeste.RealizarTeste(dictionaryDados);
        }

        [TestCleanup]
        public void FecharSistema()
        {
            //ClicarBotaoName("Sair/Login");
            //TrocarJanela();
            //Verificar("Sistema de gestão comercial", "Sistema de gestão comercial");
            //ClicarBotaoName("Fechar");
            //EncerrarSessao();
        }
    }
}
