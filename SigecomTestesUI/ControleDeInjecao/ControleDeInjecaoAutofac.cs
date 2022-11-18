using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.Login;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Categoria;
using SigecomTestesUI.Sigecom.Cadastros.Injection;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor;
using SigecomTestesUI.Sigecom.Cadastros.Produtos;
using SigecomTestesUI.Sigecom.Pesquisa.PesquisaDeCategoria;
using SigecomTestesUI.Sigecom.Pesquisa.PesquisaPessoa;
using SigecomTestesUI.Sigecom.Pesquisa.PesquisaProduto;

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
