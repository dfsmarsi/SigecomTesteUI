using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste.Interfaces;

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
                containerBuilder.RegisterType<PesquisaDeProdutoPage>();
                containerBuilder.RegisterType<CadastroDeProdutoBaseTeste>().As<ICadastroDeProdutoBaseTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDeProdutoInjection).Namespace, exception);
            }
        }
    }
}
