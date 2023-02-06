using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;

namespace SigecomTestesUI.Sigecom.Estoque.AnaliseDeEstoque.Injection
{
    public class AnaliseDeEstoqueInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {

            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(AnaliseDeEstoqueInjection).Namespace, exception);
            }
        }
    }
}
