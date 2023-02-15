using Autofac;
using SigecomTestesUI.Sigecom.Compra.Avulsa.Injection;

namespace SigecomTestesUI.Sigecom.Compra.Injection
{
    public class CompraInjection
    {
        internal static void ConstruindoDependenciasDaCompra(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<CompraAvulsaInjection>();
        }
    }
}
