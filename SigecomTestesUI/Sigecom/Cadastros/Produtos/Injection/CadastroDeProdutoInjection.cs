using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoPage;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoPage.Factory;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoPage.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoTeste;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Injection
{
    public class CadastroDeProdutoInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CadastroDeProdutoBasePage>();
                containerBuilder.RegisterType<CadastroDeProdutoSimplesTeste>();
                containerBuilder.RegisterType<CadastroDeProdutoCombustivelTeste>();
                containerBuilder.RegisterType<CadastroDeProdutoBalancaTeste>();
                containerBuilder.RegisterType<CadastroDeProdutoGradeTeste>();
                containerBuilder.RegisterType<CadastroDeProdutoCompletoTeste>();
                containerBuilder.RegisterType<CadastroDeProdutoFactory>().As<ICadastroDeProdutoFactory>();
                containerBuilder.RegisterType<CadastroDeProdutoCombustivelPage>();
                containerBuilder.RegisterType<CadastroDeProdutoGradePage>();
                containerBuilder.RegisterType<CadastroDeProdutoBalancaPage>();
                containerBuilder.RegisterType<CadastroDeProdutoSimplesPage>();
                containerBuilder.RegisterType<CadastroDeProdutoMedicamentoPage>();
                containerBuilder.RegisterType<CadastroDeProdutoServicoPage>();
                containerBuilder.RegisterType<CadastroDeProdutoCompletoPage>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDeProdutoInjection).Namespace, exception);
            }
        }
    }
}
