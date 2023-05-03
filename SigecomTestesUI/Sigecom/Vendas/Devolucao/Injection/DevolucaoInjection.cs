using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Devolucao.Page;
using SigecomTestesUI.Sigecom.Vendas.Devolucao.Teste;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Devolucao.Injection
{
    public class DevolucaoInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<LancarItensNaDevolucaoTeste>();
                containerBuilder.RegisterType<LancarItensNaDevolucaoPage>();
                containerBuilder.RegisterType<RemoverItemNaDevolucaoTeste>();
                containerBuilder.RegisterType<RemoverItemNaDevolucaoPage>();
                containerBuilder.RegisterType<DevolucaoParcialNaDevolucaoPage>();
                containerBuilder.RegisterType<DevolucaoParcialNaDevolucaoTeste>();
                containerBuilder.RegisterType<DevolucaoTotalPage>();
                containerBuilder.RegisterType<DevolucaoTotalTeste>();
                containerBuilder.RegisterType<VoltarNaDevolucaoComEscPage>();
                containerBuilder.RegisterType<VoltarNaDevolucaoComEscTeste>();
                containerBuilder.RegisterType<GerarHaverNaDevolucaoPage>();
                containerBuilder.RegisterType<GerarHaverNaDevolucaoTeste>();
                containerBuilder.RegisterType<DevolverDinheiroNaDevolucaoPage>();
                containerBuilder.RegisterType<DevolverDinheiroNaDevolucaoTeste>();
                containerBuilder.RegisterType<ContasPagarNaDevolucaoPage>();
                containerBuilder.RegisterType<ContasPagarNaDevolucaoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(DevolucaoInjection).Namespace, exception);
            }
        }
    }
}
