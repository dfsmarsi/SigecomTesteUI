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
                containerBuilder.RegisterType<EditarNoConsultaDePreVendaPage>();
                containerBuilder.RegisterType<EditarNoConsultaDePreVendaTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ConsultaDaPreVendaInjection).Namespace, exception);
            }
        }
    }
}
