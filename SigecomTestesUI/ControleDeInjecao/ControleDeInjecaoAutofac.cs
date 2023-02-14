using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.Login;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Injection;
using SigecomTestesUI.Sigecom.Compra.Injection;
using SigecomTestesUI.Sigecom.Estoque.Injection;
using SigecomTestesUI.Sigecom.Vendas.Injection;

namespace SigecomTestesUI.ControleDeInjecao
{
    public static class ControleDeInjecaoAutofac
    {
        internal static IContainer Container { get; private set; }

        public static void ConstruirContainerComDependencias()
        {
            var containerBuilder = new ContainerBuilder();
            CadastroInjection.ConstruindoDependenciasDeCadastro(containerBuilder);
            VendasInjection.ConstruindoDependenciasDeVendas(containerBuilder);
            EstoqueInjection.ConstruindoDependenciasDoEstoque(containerBuilder);
            CompraInjection.ConstruindoDependenciasDaCompra(containerBuilder);
            containerBuilder.RegisterType<DriverService>();
            containerBuilder.RegisterType<DriverFabrica>();
            containerBuilder.RegisterType<LoginPage>();
            Container = containerBuilder.Build();
        }
    }
}
