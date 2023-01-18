using Autofac;
using System;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Page;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Page.Factory;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Teste;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Injection
{
    public class EdicaoDeTabelaDePrecoInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<EdicaoDeTabelaDePrecoBasePage>();
                containerBuilder.RegisterType<EdicaoDeTabelaDePrecoComProdutoEspecificoPage>();
                containerBuilder.RegisterType<EdicaoDeTabelaDePrecoComTodosOsProdutosPage>();
                containerBuilder.RegisterType<EdicaoDeTabelaDePrecoPageFactory>().As<IEdicaoDeTabelaDePrecoPageFactory>();
                containerBuilder.RegisterType<EdicaoDeTabelaDePrecoComProdutoEspecificoTeste>();
                containerBuilder.RegisterType<EdicaoDeTabelaDePrecoComTodosOsProdutosTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(EdicaoDeTabelaDePrecoInjection).Namespace, exception);
            }
        }
    }
}
