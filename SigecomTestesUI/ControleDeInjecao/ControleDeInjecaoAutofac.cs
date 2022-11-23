using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.Login;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Injection;

namespace SigecomTestesUI.ControleDeInjecao
{
    public static class ControleDeInjecaoAutofac
    {
        internal static IContainer Container { get; private set; }

        public static void ConstruirContainerComDependencias()
        {
            var containerBuilder = new ContainerBuilder();
            CadastroInjection.ConstruindoDependenciasDeCadastro(containerBuilder);
            containerBuilder.RegisterType<DriverService>();
            containerBuilder.RegisterType<DriverFabrica>();
            containerBuilder.RegisterType<LoginPage>();
            Container = containerBuilder.Build();
        }
    }
}
