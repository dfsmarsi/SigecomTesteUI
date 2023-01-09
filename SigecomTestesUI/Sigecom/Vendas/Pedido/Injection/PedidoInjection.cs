using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Page;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Teste;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.Injection
{
    public class PedidoInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<LancarItensNoPedidoPage>();
                containerBuilder.RegisterType<RemoverItemDoPedidoPage>();
                containerBuilder.RegisterType<DarDescontoNoPedidoPage>();
                containerBuilder.RegisterType<VoltarNoPedidoComEscPage>();
                containerBuilder.RegisterType<LancarVendaNoCartaoNoPedidoPage>();
                containerBuilder.RegisterType<LancarVendaNoPrazoNoPedidoPage>();
                containerBuilder.RegisterType<LancarVendaNoPrazoNoPedidoTeste>();
                containerBuilder.RegisterType<LancarVendaNoCartaoNoPedidoTeste>();
                containerBuilder.RegisterType<VoltarNoPedidoComEscTeste>();
                containerBuilder.RegisterType<DarDescontoNoPedidoTeste>();
                containerBuilder.RegisterType<RemoverItemDoPedidoTeste>();
                containerBuilder.RegisterType<LancarItensNoPedidoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(PedidoInjection).Namespace, exception);
            }
        }
    }
}
