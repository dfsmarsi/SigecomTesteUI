using Autofac;
using SigecomTestesUI.Sigecom.Vendas.PDV.Injection;

namespace SigecomTestesUI.Sigecom.Vendas.Injection
{
    internal static class VendasInjection
    {
        internal static void ConstruindoDependenciasDeVendas(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<PdvInjection>();
        }
    }
}
