using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page.Factory;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page.Interfaces;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Teste;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Injection
{
    public class CadastroDeClienteSimplificadoInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<ClienteSimplificadoBasePage>();
                containerBuilder.RegisterType<ClienteSimplificadoFisicoComNomeTeste>();
                containerBuilder.RegisterType<ClienteSimplificadoFisicoComNomeECpfTeste>();
                containerBuilder.RegisterType<ClienteSimplificadoFisicoCompletoTeste>();
                containerBuilder.RegisterType<ClienteSimplificadoJuridicoComNomeTeste>();
                containerBuilder.RegisterType<ClienteSimplificadoPageFactory>().As<IClienteSimplificadoPageFactory>();
                containerBuilder.RegisterType<ClienteSimplificadoFisicoComNomePage>();
                containerBuilder.RegisterType<ClienteSimplificadoFisicoComNomeECpfPage>();
                containerBuilder.RegisterType<ClienteSimplificadoFisicoCompletoPage>();
                containerBuilder.RegisterType<ClienteSimplificadoJuridicoComNomePage>();
                containerBuilder.RegisterType<ClienteSimplificadoJuridicoComNomeECpfPage>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDeClienteSimplificadoInjection).Namespace, exception);
            }
        }
    }
}
