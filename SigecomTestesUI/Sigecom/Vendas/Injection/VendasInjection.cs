using Autofac;
using SigecomTestesUI.Sigecom.Vendas.PDV.Injection;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Injection;

namespace SigecomTestesUI.Sigecom.Vendas.Injection
{
    internal static class VendasInjection
    {
        internal static void ConstruindoDependenciasDeVendas(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<PdvInjection>();
            containerBuilder.RegisterModule<PedidoInjection>();
        }
    }
}
