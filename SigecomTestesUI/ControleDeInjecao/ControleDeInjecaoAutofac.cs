using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.Login;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Categoria;
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

        public static void ConstruirContainerComDependenciasSemCarregarDados()
        {
            var containerBuilder = new ContainerBuilder();
            ConstruindoDependenciasDePessoa(containerBuilder);
            ConstruindoDependenciasDoProduto(containerBuilder);
            ConstruindoDependenciasDoCategoria(containerBuilder);
            containerBuilder.RegisterType<DriverService>();
            containerBuilder.RegisterType<DriverFabrica>();
            containerBuilder.RegisterType<LoginPage>();
            Container = containerBuilder.Build();
        }

        private static void ConstruindoDependenciasDePessoa(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CadastroDeClientePage>();
            containerBuilder.RegisterType<CadastroDeClienteTeste>();
            containerBuilder.RegisterType<CadastroDeColaboradorPage>();
            containerBuilder.RegisterType<CadastroDeColaboradorTeste>();
            containerBuilder.RegisterType<CadastroDeFornecedorPage>();
            containerBuilder.RegisterType<CadastroDeFornecedorTeste>();
            containerBuilder.RegisterType<PesquisaDePessoaPage>();
        }

        private static void ConstruindoDependenciasDoProduto(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CadastroDeProdutoPage>();
            containerBuilder.RegisterType<CadastroDeProdutoTeste>();
            containerBuilder.RegisterType<PesquisaDeProdutoPage>();
        }

        private static void ConstruindoDependenciasDoCategoria(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CadastroDeCategoriaPage>();
            containerBuilder.RegisterType<CadastroDeCategoriaTeste>();
            containerBuilder.RegisterType<PesquisaDeCategoriaPage>();
        }
    }
}
