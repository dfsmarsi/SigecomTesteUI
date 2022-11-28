using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Teste;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto
{
    public class PesquisaDeProdutoInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<PesquisaDeProdutoPage>();
                containerBuilder.RegisterType<PesquisaDeProdutoBaseTeste>();
                containerBuilder.RegisterType<PesquisaDeProdutoPorCodigoTeste>();
                containerBuilder.RegisterType<PesquisaDeProdutoVaziaTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(PesquisaDeProdutoInjection).Namespace, exception);
            }
        }
    }
}
