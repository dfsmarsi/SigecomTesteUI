using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Page;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Teste;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Injection
{
    public class CadastroDeColaboradorInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CadastroDeColaboradorFisicoPage>();
                containerBuilder.RegisterType<CadastroDeColaboradorFisicoSimplesTeste>();
                containerBuilder.RegisterType<CadastroDeColaboradorFisicoCompletoTeste>();
                containerBuilder.RegisterType<CadastroDeColaboradorJuridicoPage>();
                containerBuilder.RegisterType<CadastroDeColaboradorJuridicoSimplesTeste>();
                containerBuilder.RegisterType<CadastroDeColaboradorJuridicoCompletoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDeColaboradorInjection).Namespace, exception);
            }
        }
    }
}
