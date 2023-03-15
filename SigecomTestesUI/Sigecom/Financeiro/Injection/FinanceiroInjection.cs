using Autofac;
using SigecomTestesUI.Sigecom.Financeiro.Caixa.Injection;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Injection;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Injection;

namespace SigecomTestesUI.Sigecom.Financeiro.Injection
{
    internal static class FinanceiroInjection
    {
        internal static void ConstruindoDependenciasDeVendas(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<CaixaInjection>();
            containerBuilder.RegisterModule<ContaAReceberInjection>();
            containerBuilder.RegisterModule<ContaAPagarInjection>();
        }
    }
}
