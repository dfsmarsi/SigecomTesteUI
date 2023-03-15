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
                containerBuilder.RegisterType<PagarValorTotalDaContaAPagarPage>();
                containerBuilder.RegisterType<PagarValorTotalDaContaAPagarTeste>();
                containerBuilder.RegisterType<EditarDaContaAPagarPage>();
                containerBuilder.RegisterType<EditarDaContaAPagarTeste>();
                containerBuilder.RegisterType<PagarValorParcialDaContaAPagarPage>();
                containerBuilder.RegisterType<PagarValorParcialDaContaAPagarTeste>();
                containerBuilder.RegisterType<PagarValorTotalComHaverDaContaAPagarPage>();
                containerBuilder.RegisterType<PagarValorTotalComHaverDaContaAPagarTeste>();
                containerBuilder.RegisterType<PagarValorParcialComHaverDaContaAPagarPage>();
                containerBuilder.RegisterType<PagarValorParcialComHaverDaContaAPagarTeste>();
                containerBuilder.RegisterType<EstornarDaContaAPagarPage>();
                containerBuilder.RegisterType<EstornarDaContaAPagarTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ContaAPagarInjection).Namespace, exception);
            }
        }
    }
}
