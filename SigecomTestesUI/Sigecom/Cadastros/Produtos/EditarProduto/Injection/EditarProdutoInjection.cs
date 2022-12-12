using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Teste;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.EdicaoDeProdutoPage;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.EdicaoDeProdutoPage.Factory;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Injection
{
    public class EditarProdutoInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<EdicaoDeProdutoBasePage>();
                containerBuilder.RegisterType<EdicaoDeProdutoSimplesTeste>();
                containerBuilder.RegisterType<EdicaoDeProdutoPageFactory>().As<IEdicaoDeProdutoPageFactory>();
                containerBuilder.RegisterType<EdicaoDeProdutoSimplesPage>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(EditarProdutoInjection).Namespace, exception);
            }
        }
    }
}
