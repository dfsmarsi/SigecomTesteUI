using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Page;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Teste;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Injection
{
    public class CondicionalInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<LancarItensNaCondicionalPage>();
                containerBuilder.RegisterType<LancarItensNaCondicionalTeste>();
                containerBuilder.RegisterType<RemoverItemDaCondicionalPage>();
                containerBuilder.RegisterType<RemoverItemNaCondicionalTeste>();
                containerBuilder.RegisterType<AplicarDescontoNaCondicionalPage>();
                containerBuilder.RegisterType<AplicarDescontoNaCondicionalTeste>();
                containerBuilder.RegisterType<VoltarNaCondicionalComEscPage>();
                containerBuilder.RegisterType<VoltarNaCondicionalComEscTeste>();
                containerBuilder.RegisterType<AlterarTabelaDePrecoDaCondicionalPage>();
                containerBuilder.RegisterType<AlterarTabelaDePrecoDaCondicionalTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CondicionalInjection).Namespace, exception);
            }
        }
    }
}
