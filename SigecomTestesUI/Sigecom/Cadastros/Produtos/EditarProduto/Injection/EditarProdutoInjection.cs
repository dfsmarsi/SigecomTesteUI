using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Teste;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Injection
{
    public class EditarProdutoInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<EdicaoDeProdutoSimplesTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(EditarProdutoInjection).Namespace, exception);
            }
        }
    }
}
