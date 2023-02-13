using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;

namespace SigecomTestesUI.Sigecom.Compra.Avulsa.Injection
{
    public class CompraAvulsaInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {

            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CompraAvulsaInjection).Namespace, exception);
            }
        }
    }
}
