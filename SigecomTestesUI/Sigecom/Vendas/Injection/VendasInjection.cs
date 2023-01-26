using Autofac;
using SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Injection;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Injection;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Injection;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Injection;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.ConsultaDeOrdemDeServico.Injection;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Injection;
using SigecomTestesUI.Sigecom.Vendas.PDV.Injection;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Injection;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.ConsultaDePreVenda.Injection;
using SigecomTestesUI.Sigecom.Vendas.PreVenda.LancarPreVenda.Injection;

namespace SigecomTestesUI.Sigecom.Vendas.Injection
{
    internal static class VendasInjection
    {
        internal static void ConstruindoDependenciasDeVendas(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<PdvInjection>();
            containerBuilder.RegisterModule<PedidoInjection>();
            containerBuilder.RegisterModule<PreVendaInjection>();
            containerBuilder.RegisterModule<ConsultaDaPreVendaInjection>();
            containerBuilder.RegisterModule<CondicionalInjection>();
            containerBuilder.RegisterModule<ConsultaDeCondicionalInjection>();
            containerBuilder.RegisterModule<OrdemDeServicoInjection>();
            containerBuilder.RegisterModule<ConsultaDeOrdemDeServicoInjection>();
            containerBuilder.RegisterModule<OrcamentoInjection>();
            containerBuilder.RegisterModule<ConsultaDeOrcamentoInjection>();
        }
    }
}
