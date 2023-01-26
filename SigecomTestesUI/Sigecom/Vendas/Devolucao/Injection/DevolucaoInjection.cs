using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Devolucao.Injection
{
    public class DevolucaoInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {

            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(DevolucaoInjection).Namespace, exception);
            }
        }
    }
}
