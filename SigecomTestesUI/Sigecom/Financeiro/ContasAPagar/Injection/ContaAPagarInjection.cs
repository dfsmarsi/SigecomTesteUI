using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Injection
{
    public class ContaAPagarInjection:Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ContaAPagarInjection).Namespace, exception);
            }
        }
    }
}
