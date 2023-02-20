using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Page;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Teste;

namespace SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Injection
{
    public class ContaAReceberInjection:Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<LancarContaAvulsaPage>();
                containerBuilder.RegisterType<LancarContaAvulsaTeste>();
                containerBuilder.RegisterType<AbrirDetalhesDaContaPage>();
                containerBuilder.RegisterType<AbrirDetalhesDaContaTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ContaAReceberInjection).Namespace, exception);
            }
        }
    }
}
