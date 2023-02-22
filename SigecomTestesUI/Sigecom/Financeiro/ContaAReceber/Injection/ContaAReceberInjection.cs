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
                containerBuilder.RegisterType<ReceberValorTotalPage>();
                containerBuilder.RegisterType<ReceberValorTotalTeste>();
                containerBuilder.RegisterType<ReceberValorParcialPage>();
                containerBuilder.RegisterType<ReceberValorParcialTeste>();
                containerBuilder.RegisterType<ReceberValorTotalComHaverPage>();
                containerBuilder.RegisterType<ReceberValorTotalComHaverTeste>();
                containerBuilder.RegisterType<ReceberValorParcialComHaverPage>();
                containerBuilder.RegisterType<ReceberValorParcialComHaverTeste>();
                containerBuilder.RegisterType<FazerAcordoNaContasAReceberPage>();
                containerBuilder.RegisterType<FazerAcordoNaContasAReceberTeste>();
                containerBuilder.RegisterType<EstornarDaContaAReceberPage>();
                containerBuilder.RegisterType<EstornarDaContaAReceberTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ContaAReceberInjection).Namespace, exception);
            }
        }
    }
}
