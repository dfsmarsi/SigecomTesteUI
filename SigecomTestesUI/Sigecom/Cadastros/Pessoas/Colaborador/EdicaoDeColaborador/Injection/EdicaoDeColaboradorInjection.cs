using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page.Factory;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Teste;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Injection
{
    public class EdicaoDeColaboradorInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<EdicaoDeColaboradorBasePage>();
                containerBuilder.RegisterType<EdicaoDeColaboradorJuridicoSimplesPage>();
                //containerBuilder.RegisterType<EdicaoDeColaboradorJuridicoCompletoPage>();
                containerBuilder.RegisterType<EdicaoDeColaboradorFisicoSimplesPage>();
                //containerBuilder.RegisterType<EdicaoDeColaboradorFisicoCompletoPage>();
                containerBuilder.RegisterType<EdicaoDeColaboradorPageFactory>().As<IEdicaoDeColaboradorPageFactory>();
                containerBuilder.RegisterType<EdicaoDeColaboradorJuridicoSimplesTeste>();
                //containerBuilder.RegisterType<EdicaoDeColaboradorJuridicoCompletoTeste>();
                containerBuilder.RegisterType<EdicaoDeColaboradorFisicoSimplesTeste>();
                //containerBuilder.RegisterType<EdicaoDeColaboradorFisicoCompletoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(EdicaoDeColaboradorInjection).Namespace, exception);
            }
        }
    }
}
