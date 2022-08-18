using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SigecomTesteUI
{
    public class LoginPage : Page
    {
        public LoginPage(DriverService driverService) : base(driverService)
        {
        }

        public bool AbrirSistema()
        {
            
            
            return true;
        }




        //private WindowsElement TextBoxUsuario => RetornarElementoPorId("txtUsuario");
        //private WindowsElement TextBoxSenha => RetornarElementoPorId("txtSenha");
        //private WindowsElement ViewTelaPrincipal => RetornarElementoPorNome("SIGECOM - Sistema de Gestão Comercial - SISTEMASBR");

        //public override void RealizarTeste(Dictionary<string, string> dados)
        //{
        //    DriverService.DigitarNoCampo(TextBoxUsuario, dados["Usuario"]);
        //    DriverService.DigitarNoCampoEnter(TextBoxSenha, dados["Senha"]);
        //    DriverService.Setup();
        //    Thread.Sleep(TimeSpan.FromSeconds(5));
        //    DriverService.TrocarJanela();
        //    DriverService.Verificar(ViewTelaPrincipal, dados["NomeTelaPrincipal"]);
        //}
    }
}
