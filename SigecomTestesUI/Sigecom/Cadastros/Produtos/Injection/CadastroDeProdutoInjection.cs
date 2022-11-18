using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Injection
{
    public class CadastroDeProdutoInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CadastroDeProdutoPage>();
                containerBuilder.RegisterType<CadastroDeProdutoTeste>();
                containerBuilder.RegisterType<PesquisaDeProdutoPage>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDeProdutoInjection).Namespace, exception);
            }
        }
    }
}
