using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Page;
using SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Teste;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Injection
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
                containerBuilder.RegisterType<LancarVendaDeCartaoNoPedidoPage>();
                containerBuilder.RegisterType<LancarVendaDePrazoNoPedidoPage>();
                containerBuilder.RegisterType<LancarVendaDeChequeNoPedidoPage>();
                containerBuilder.RegisterType<LancarVendaComTrocoNoPedidoPage>();
                containerBuilder.RegisterType<LancarVendaDeBancoNoPedidoPage>();
                containerBuilder.RegisterType<LancarVendaDeDinheiroNoPedidoPage>();
                containerBuilder.RegisterType<AlterarTabelaDePrecoDoPedidoPage>();
                containerBuilder.RegisterType<AlterarTabelaDePrecoDoPedidoTeste>();
                containerBuilder.RegisterType<LancarVendaDeDinheiroNoPedidoTeste>();
                containerBuilder.RegisterType<LancarVendaDeBancoNoPedidoTeste>();
                containerBuilder.RegisterType<LancarVendaComTrocoNoPedidoTeste>();
                containerBuilder.RegisterType<LancarVendaDeChequeNoPedidoTeste>();
                containerBuilder.RegisterType<LancarVendaDePrazoNoPedidoTeste>();
                containerBuilder.RegisterType<LancarVendaDeCartaoNoPedidoTeste>();
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
