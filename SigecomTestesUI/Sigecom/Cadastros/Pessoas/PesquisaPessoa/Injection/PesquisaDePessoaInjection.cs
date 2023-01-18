using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.PesquisaDeCliente;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa.Injection
{
    public class PesquisaDePessoaInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<PesquisaDePessoaPage>();
                containerBuilder.RegisterType<PesquisaDeClienteVaziaTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(PesquisaDePessoaInjection).Namespace, exception);
            }
        }
    }
}
