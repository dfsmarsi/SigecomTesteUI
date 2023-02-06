using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Pedido.ConsultaDePedido.Page;
using SigecomTestesUI.Sigecom.Vendas.Pedido.ConsultaDePedido.Teste;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.ConsultaDePedido.Injection
{
    public class ConsultaDePedidoInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<ConsultarVendasRealizadasPage>();
                containerBuilder.RegisterType<ConsultarVendasRealizadasTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ConsultaDePedidoInjection).Namespace, exception);
            }
        }
    }
}
