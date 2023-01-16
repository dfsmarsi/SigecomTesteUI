using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Page;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Teste;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Injection
{
    public class PreVendaInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<LancarItensNaPreVendaPage>();
                containerBuilder.RegisterType<LancarItensNaPreVendaTeste>();
                containerBuilder.RegisterType<RemoverItemDaPreVendaPage>();
                containerBuilder.RegisterType<RemoverItemDaPreVendaTeste>();
                containerBuilder.RegisterType<AlterarTabelaDePrecoDaPreVendaPage>();
                containerBuilder.RegisterType<AlterarTabelaDePrecoDaPreVendaTeste>();
                containerBuilder.RegisterType<DarDescontoNaPreVendaPage>();
                containerBuilder.RegisterType<DarDescontoNaPreVendaTeste>();
                containerBuilder.RegisterType<VoltarNaPreVendaComEscPage>();
                containerBuilder.RegisterType<VoltarNaPreVendaComEscTeste>();
                containerBuilder.RegisterType<MarcarEntregaComFreteNaPreVendaPage>();
                containerBuilder.RegisterType<MarcarEntregaComFreteNaPreVendaTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(PreVendaInjection).Namespace, exception);
            }
        }
    }
}
