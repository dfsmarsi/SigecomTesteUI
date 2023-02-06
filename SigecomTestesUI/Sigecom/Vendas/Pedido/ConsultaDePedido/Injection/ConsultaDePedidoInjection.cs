using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.ConsultaDePedido.Injection
{
    public class ConsultaDePedidoInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {

            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ConsultaDePedidoInjection).Namespace, exception);
            }
        }
    }
}
