using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.Caixa.Injection
{
    public class CaixaInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CaixaInjection).Namespace, exception);
            }
        }
    }
}
