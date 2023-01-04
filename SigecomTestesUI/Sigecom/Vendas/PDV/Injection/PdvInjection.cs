using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page;
using SigecomTestesUI.Sigecom.Vendas.PDV.Teste;
using System;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Factory;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Injection
{
    public class PdvInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<RemoverItemDoPdvPage>();
                containerBuilder.RegisterType<LancarItemNoPdvPage>();
                containerBuilder.RegisterType<LancarVendaNaFormaDePagamentoPage>();
                containerBuilder.RegisterType<LancarVendaNoDinheiroPage>();
                containerBuilder.RegisterType<LancarVendaNoPrazoPage>();
                containerBuilder.RegisterType<LancarVendaNoCreditoPage>();
                containerBuilder.RegisterType<LancarVendaNoChequePage>();
                containerBuilder.RegisterType<LancarVendaComTrocoPage>();
                containerBuilder.RegisterType<LancarVendaNoBancoPage>();
                containerBuilder.RegisterType<AlterarTabelaDePrecoDoPdvPage>();
                containerBuilder.RegisterType<VoltarNoPdvComEscPage>();
                containerBuilder.RegisterType<LancarFormaDePagamentoPageFactory>().As<ILancarFormaDePagamentoPageFactory>();
                containerBuilder.RegisterType<RemoverItemDoPdvTeste>();
                containerBuilder.RegisterType<LancarItemNoPdvTeste>();
                containerBuilder.RegisterType<LancarVendaNoDinheiroTeste>();
                containerBuilder.RegisterType<LancarVendaNoPrazoTeste>();
                containerBuilder.RegisterType<LancarVendaNoCreditoTeste>();
                containerBuilder.RegisterType<LancarVendaComTrocoTeste>();
                containerBuilder.RegisterType<LancarVendaNoBancoTeste>();
                containerBuilder.RegisterType<AlterarTabelaDePrecoDoPdvTeste>();
                containerBuilder.RegisterType<VoltarNoPdvComEscTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(PdvInjection).Namespace, exception);
            }
        }
    }
}
