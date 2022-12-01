using Autofac;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Injection;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Injection;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Injection;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Injection;

namespace SigecomTestesUI.Sigecom.Cadastros.Injection
{
    internal static class CadastroInjection
    {
        internal static void ConstruindoDependenciasDeCadastro(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<CadastroDeCategoriaInjection>();
            containerBuilder.RegisterModule<CadastroDePessoaInjection>();
            containerBuilder.RegisterModule<CadastroDeProdutoInjection>();
            containerBuilder.RegisterModule<PesquisaDeProdutoInjection>();
        }
    }
}
