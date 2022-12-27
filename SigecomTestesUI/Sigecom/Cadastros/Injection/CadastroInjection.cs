using Autofac;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Injection;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Injection;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Injection;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa.Injection;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.Injection;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Injection;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Injection;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Injection;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Injection;

namespace SigecomTestesUI.Sigecom.Cadastros.Injection
{
    internal static class CadastroInjection
    {
        internal static void ConstruindoDependenciasDeCadastro(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<CadastroDeCategoriaInjection>();
            containerBuilder.RegisterModule<CadastroDePessoaInjection>();
            containerBuilder.RegisterModule<EditarProdutoInjection>();
            containerBuilder.RegisterModule<CadastroDeProdutoInjection>();
            containerBuilder.RegisterModule<PesquisaDeProdutoInjection>();
            containerBuilder.RegisterModule<PesquisaDePessoaInjection>();
            containerBuilder.RegisterModule<CadastroDeTabelaDePrecoInjection>();
            containerBuilder.RegisterModule<EdicaoDeTabelaDePrecoInjection>();
            containerBuilder.RegisterModule<CadastroDeClienteSimplificadoInjection>();
        }
    }
}
