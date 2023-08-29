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
                containerBuilder.RegisterType<LancarContaAPagarAvulsaPage>();
                containerBuilder.RegisterType<LancarContaAPagarAvulsaTeste>();
                containerBuilder.RegisterType<AbrirDetalhesDaContaAPagarPage>();
                containerBuilder.RegisterType<AbrirDetalhesDaContaAPagarTeste>();
                containerBuilder.RegisterType<PagarContaPage>();
                containerBuilder.RegisterType<PagarContaTeste>();
                containerBuilder.RegisterType<EditarDaContaAPagarPage>();
                containerBuilder.RegisterType<EditarDaContaAPagarTeste>();
                containerBuilder.RegisterType<PagarContaParcialmentePage>();
                containerBuilder.RegisterType<PagarContaParcialmenteTeste>();
                containerBuilder.RegisterType<PagarContaComHaverPage>();
                containerBuilder.RegisterType<PagarContaComHaverTeste>();
                containerBuilder.RegisterType<PagarContaParcialComHaverPage>();
                containerBuilder.RegisterType<PagarContaParcialComHaverTeste>();
                containerBuilder.RegisterType<EstornarContaPagaPage>();
                containerBuilder.RegisterType<EstornarContaPagaTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ContaAPagarInjection).Namespace, exception);
            }
        }
    }
}
