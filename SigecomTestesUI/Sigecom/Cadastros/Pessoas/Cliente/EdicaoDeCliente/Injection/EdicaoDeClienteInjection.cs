using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Factory;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Teste;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Injection
{
    public class EdicaoDeClienteInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<EdicaoDeClienteBasePage>();
                containerBuilder.RegisterType<EdicaoDeClienteJuridicoSimplesPage>();
                containerBuilder.RegisterType<EdicaoDeClienteJuridicoCompletoPage>();
                containerBuilder.RegisterType<EdicaoDeClienteFisicoSimplesPage>();
                containerBuilder.RegisterType<EdicaoDeClienteFisicoCompletoPage>();
                containerBuilder.RegisterType<EdicaoDeClientePageFactory>().As<IEdicaoDeClientePageFactory>();
                containerBuilder.RegisterType<EdicaoDeClienteJuridicoSimplesTeste>();
                containerBuilder.RegisterType<EdicaoDeClienteJuridicoCompletoTeste>();
                containerBuilder.RegisterType<EdicaoDeClienteFisicoSimplesTeste>();
                containerBuilder.RegisterType<EdicaoDeClienteFisicoCompletoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(EdicaoDeClienteInjection).Namespace, exception);
            }
        }
    }
}
