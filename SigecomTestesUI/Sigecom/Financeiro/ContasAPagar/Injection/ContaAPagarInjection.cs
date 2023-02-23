using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Teste;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Injection
{
    public class ContaAPagarInjection:Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<LancarContaAvulsaDaContaAPagarPage>();
                containerBuilder.RegisterType<LancarContaAvulsaDaContaAPagarTeste>();
                containerBuilder.RegisterType<AbrirDetalhesDaContaAPagarPage>();
                containerBuilder.RegisterType<AbrirDetalhesDaContaAPagarTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ContaAPagarInjection).Namespace, exception);
            }
        }
    }
}
