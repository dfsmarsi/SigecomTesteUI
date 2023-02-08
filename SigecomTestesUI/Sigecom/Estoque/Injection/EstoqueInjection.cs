using Autofac;
using SigecomTestesUI.Sigecom.Estoque.AnaliseDeEstoque.Injection;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Injection;

namespace SigecomTestesUI.Sigecom.Estoque.Injection
{
    internal static class EstoqueInjection
    {
        internal static void ConstruindoDependenciasDoEstoque(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<AnaliseDeEstoqueInjection>();
            containerBuilder.RegisterModule<ManutencaoDeEstoqueInjection>();
        }
    }
}
