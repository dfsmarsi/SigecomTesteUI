using Autofac;
using SigecomTestesUI.Sigecom.Estoque.AnaliseDeEstoque.Injection;

namespace SigecomTestesUI.Sigecom.Estoque.Injection
{
    internal static class EstoqueInjection
    {
        internal static void ConstruindoDependenciasDoEstoque(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<AnaliseDeEstoqueInjection>();
        }
    }
}
