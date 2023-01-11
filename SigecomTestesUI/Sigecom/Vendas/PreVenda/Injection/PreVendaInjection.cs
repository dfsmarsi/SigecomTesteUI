using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.Page;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.Teste;

namespace SigecomTestesUI.Sigecom.Vendas.PreVenda.Injection
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
                containerBuilder.RegisterType<GravarEImprimirPreVendaPage>();
                containerBuilder.RegisterType<GravarEImprimirPreVendaTeste>();
                containerBuilder.RegisterType<FaturarEImprimirPreVendaPage>();
                containerBuilder.RegisterType<FaturarEImprimirPreVendaTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(PreVendaInjection).Namespace, exception);
            }
        }
    }
}
