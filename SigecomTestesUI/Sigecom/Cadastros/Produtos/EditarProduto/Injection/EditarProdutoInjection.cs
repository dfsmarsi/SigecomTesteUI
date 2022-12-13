using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Teste;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page.Factory;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page.Interface;

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
                containerBuilder.RegisterType<EdicaoDeProdutoCompletoTeste>();
                containerBuilder.RegisterType<EdicaoDeProdutoBalancaTeste>();
                containerBuilder.RegisterType<EdicaoDeProdutoGradeTeste>();
                containerBuilder.RegisterType<EdicaoDeProdutoCombustivelTeste>();
                containerBuilder.RegisterType<EdicaoDeProdutoMedicamentoTeste>();
                containerBuilder.RegisterType<EdicaoDoProdutoServicoTeste>();
                containerBuilder.RegisterType<EdicaoDeProdutoPageFactory>().As<IEdicaoDeProdutoPageFactory>();
                containerBuilder.RegisterType<EdicaoDeProdutoSimplesPage>();
                containerBuilder.RegisterType<EdicaoDeProdutoCompletoPage>();
                containerBuilder.RegisterType<EdicaoDeProdutoBalancaPage>();
                containerBuilder.RegisterType<EdicaoDeProdutoGradePage>();
                containerBuilder.RegisterType<EdicaoDeProdutoCombustivelPage>();
                containerBuilder.RegisterType<EdicaoDeProdutoMedicamentoPage>();
                containerBuilder.RegisterType<EdicaoDeProdutoServicoPage>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(EditarProdutoInjection).Namespace, exception);
            }
        }
    }
}
