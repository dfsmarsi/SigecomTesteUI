using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;

namespace SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Injection
{
    public class ManutencaoDeEstoqueInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {

            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ManutencaoDeEstoqueInjection).Namespace, exception);
            }
        }
    }
}
