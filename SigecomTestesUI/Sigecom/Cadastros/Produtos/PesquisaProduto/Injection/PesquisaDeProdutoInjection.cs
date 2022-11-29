using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Teste;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Injection
{
    public class PesquisaDeProdutoInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<PesquisaDeProdutoPage>();
                containerBuilder.RegisterType<PesquisaDeProdutoPorCodigoTeste>();
                containerBuilder.RegisterType<PesquisaDeProdutoVaziaTeste>();
                containerBuilder.RegisterType<PesquisaDeProdutoConfirmacaoDeItemTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(PesquisaDeProdutoInjection).Namespace, exception);
            }
        }
    }
}
