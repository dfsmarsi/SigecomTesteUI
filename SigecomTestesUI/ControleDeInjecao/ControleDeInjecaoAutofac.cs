using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.Login;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos;
using SigecomTestesUI.Sigecom.Pesquisa.PesquisaProduto;

namespace SigecomTestesUI.ControleDeInjecao
{
    public static class ControleDeInjecaoAutofac
    {
        internal static IContainer Container { get; private set; }

        public static void ConstruirContainerComDependenciasSemCarregarDados()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<CadastroDeProdutoPage>();
            containerBuilder.RegisterType<CadastroDeProdutoTeste>();
            containerBuilder.RegisterType<PesquisaDeProdutoPage>();
            containerBuilder.RegisterType<DriverService>();
            containerBuilder.RegisterType<DriverFabrica>();
            containerBuilder.RegisterType<LoginPage>();
            Container = containerBuilder.Build();
        }
    }
}
