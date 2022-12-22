using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Page;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Page.Factory;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Teste;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Injection
{
    public class CadastroDeTabelaDePrecoInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CadastroDeTabelaDePrecoBasePage>();
                containerBuilder.RegisterType<CadastroDeTabelaDePrecoProdutoEspecificoPage>();
                containerBuilder.RegisterType<CadastroDeTabelaDePrecoTodosOsProdutosPage>();
                containerBuilder.RegisterType<CadastroDeTabelaDePrecoPageFactory>().As<ICadastroDeTabelaDePrecoPageFactory>();
                containerBuilder.RegisterType<CadastroDeTabelaDePrecoComTodosOsProdutosTeste>();

            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDeTabelaDePrecoInjection).Namespace, exception);
            }
        }
    }
}
