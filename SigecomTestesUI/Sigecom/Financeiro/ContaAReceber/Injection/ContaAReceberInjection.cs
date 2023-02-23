using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Interfaces;
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
                containerBuilder.RegisterType<LancarContaAvulsaDaContaAReceberPage>();
                containerBuilder.RegisterType<LancarContaAvulsaDaContaAReceberTeste>();
                containerBuilder.RegisterType<AbrirDetalhesDaContaAReceberPage>();
                containerBuilder.RegisterType<AbrirDetalhesDaContaAReceberTeste>();
                containerBuilder.RegisterType<ReceberValorTotalDaContaAReceberPage>();
                containerBuilder.RegisterType<ReceberValorTotalDaContaAReceberTeste>();
                containerBuilder.RegisterType<ReceberValorParcialDaContaAReceberPage>();
                containerBuilder.RegisterType<ReceberValorParcialDaContaAReceberTeste>();
                containerBuilder.RegisterType<ReceberValorTotalComHaverDaContaAReceberPage>();
                containerBuilder.RegisterType<ReceberValorTotalComHaverDaContaAReceberTeste>();
                containerBuilder.RegisterType<ReceberValorParcialComHaverDaContaAReceberPage>();
                containerBuilder.RegisterType<ReceberValorParcialComHaverDaContaAReceberTeste>();
                containerBuilder.RegisterType<FazerAcordoNaContasAReceberPage>();
                containerBuilder.RegisterType<FazerAcordoNaContasAReceberTeste>();
                containerBuilder.RegisterType<EstornarDaContaAReceberPage>();
                containerBuilder.RegisterType<EstornarDaContaAReceberTeste>();
                containerBuilder.RegisterType<ContaBasePage>().As<IContaBasePage>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ContaAReceberInjection).Namespace, exception);
            }
        }
    }
}
