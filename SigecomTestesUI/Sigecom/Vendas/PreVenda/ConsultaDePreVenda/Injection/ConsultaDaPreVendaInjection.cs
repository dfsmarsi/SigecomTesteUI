using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Page;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Teste;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Injection
{
    public class ConsultaDaPreVendaInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<EditarNaConsultaDePreVendaPage>();
                containerBuilder.RegisterType<EditarNaConsultaDePreVendaTeste>();
                containerBuilder.RegisterType<DetalhesNaConsultaDePreVendaPage>();
                containerBuilder.RegisterType<DetalhesNaConsultaDePreVendaTeste>();
                containerBuilder.RegisterType<ClonarNaConsultaDePreVendaPage>();
                containerBuilder.RegisterType<ClonarNaConsultaDePreVendaTeste>();
                containerBuilder.RegisterType<EstornarNaConsultaDePreVendaPage>();
                containerBuilder.RegisterType<EstornarNaConsultaDePreVendaTeste>();
                containerBuilder.RegisterType<FaturarNaConsultaDePreVendaPage>();
                containerBuilder.RegisterType<FaturarNaConsultaDePreVendaTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ConsultaDaPreVendaInjection).Namespace, exception);
            }
        }
    }
}
