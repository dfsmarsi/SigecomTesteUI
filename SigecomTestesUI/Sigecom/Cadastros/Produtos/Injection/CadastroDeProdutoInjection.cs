using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Page;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Page.Factory;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Injection
{
    public class CadastroDeProdutoInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CadastroDeProdutoPage>();
                containerBuilder.RegisterType<CadastroDeProdutoSimplesTeste>();
                containerBuilder.RegisterType<CadastroDeProdutoCombustivelTeste>();
                containerBuilder.RegisterType<CadastroDeProdutoBalancaTeste>();
                containerBuilder.RegisterType<CadastroDeProdutoGradeTeste>();
                containerBuilder.RegisterType<CadastroDeProdutoFactory>().As<ICadastroDeProdutoFactory>();
                //containerBuilder.RegisterType<CadastroDeProdutoCombustivelPage>().Keyed<ICadastroDeProdutoPage>(TipoDeProduto.Combustivel);
                //containerBuilder.RegisterType<CadastroDeProdutoGradePage>().Keyed<ICadastroDeProdutoPage>(TipoDeProduto.Grade);
                //containerBuilder.RegisterType<CadastroDeProdutoBalancaPage>().Keyed<ICadastroDeProdutoPage>(TipoDeProduto.Balanca);
                //containerBuilder.RegisterType<CadastroDeProdutoSimplesPage>().Keyed<ICadastroDeProdutoPage>(TipoDeProduto.Produto);
                containerBuilder.RegisterType<CadastroDeProdutoCombustivelPage>();
                containerBuilder.RegisterType<CadastroDeProdutoGradePage>();
                containerBuilder.RegisterType<CadastroDeProdutoBalancaPage>();
                containerBuilder.RegisterType<CadastroDeProdutoSimplesPage>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDeProdutoInjection).Namespace, exception);
            }
        }
    }
}
