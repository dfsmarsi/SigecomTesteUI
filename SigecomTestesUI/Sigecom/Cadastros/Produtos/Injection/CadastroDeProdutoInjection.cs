using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
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
                containerBuilder.RegisterType<CadastroDeProdutoNormalTeste>();
                containerBuilder.RegisterType<CadastroDeProdutoBalancaTeste>();
                containerBuilder.RegisterType<CadastroDeProdutoGradeTeste>();
                containerBuilder.RegisterType<PesquisaDeProdutoPage>();
                containerBuilder.RegisterType<CadastroDeProdutoBaseTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDeProdutoInjection).Namespace, exception);
            }
        }
    }
}
