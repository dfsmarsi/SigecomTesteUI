using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Page;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Teste;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Injection
{
    public class CadastroDeClienteInjection:Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CadastroDeClienteFisicoPage>();
                containerBuilder.RegisterType<CadastroDeClienteJuridicoPage>();
                containerBuilder.RegisterType<CadastroDeClienteJuridicoSimplesTeste>();
                containerBuilder.RegisterType<CadastroDeClienteJuridicoCompletoTeste>();
                containerBuilder.RegisterType<CadastroDeClienteFisicoSimplesTeste>();
                containerBuilder.RegisterType<CadastroDeClienteFisicoCompletoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDeClienteInjection).Namespace, exception);
            }
        }
    }
}
