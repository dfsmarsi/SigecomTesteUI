using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Injection
{
    public class ConsultaDeCondicionalInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ConsultaDeCondicionalInjection).Namespace, exception);
            }
        }
    }
}
