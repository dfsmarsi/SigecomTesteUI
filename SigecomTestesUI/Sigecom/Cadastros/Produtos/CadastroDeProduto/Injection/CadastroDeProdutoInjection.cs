using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage.Factory;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoTeste;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.Injection
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
                containerBuilder.RegisterType<CadastroDeProdutoCodigoDeBarrasValidoTeste>();
                containerBuilder.RegisterType<CadastroDeProdutoFactory>().As<ICadastroDeProdutoFactory>();
                containerBuilder.RegisterType<CadastroDeProdutoCombustivelPage>();
                containerBuilder.RegisterType<CadastroDeProdutoGradePage>();
                containerBuilder.RegisterType<CadastroDeProdutoBalancaPage>();
                containerBuilder.RegisterType<CadastroDeProdutoSimplesPage>();
                containerBuilder.RegisterType<CadastroDeProdutoMedicamentoPage>();
                containerBuilder.RegisterType<CadastroDeProdutoServicoPage>();
                containerBuilder.RegisterType<CadastroDeProdutoCompletoPage>();
                containerBuilder.RegisterType<CadastroDeProdutoCodigoDeBarrasValidoPage>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDeProdutoInjection).Namespace, exception);
            }
        }
    }
}
