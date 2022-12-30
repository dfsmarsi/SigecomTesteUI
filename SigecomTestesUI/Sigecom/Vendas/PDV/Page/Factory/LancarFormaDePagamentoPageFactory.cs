using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Enum;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page.Factory
{
    public class LancarFormaDePagamentoPageFactory: ILancarFormaDePagamentoPageFactory
    {
        public ILancarFormaDePagamentoPage Fabricar(DriverService driverService, FormaDePagamento formaDePagamento)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();

            return formaDePagamento switch
            {
                FormaDePagamento.Dinheiro => lifetimeScope.Resolve<Func<DriverService, LancarVendaNoDinheiroPage>>()(driverService),
                FormaDePagamento.Prazo => lifetimeScope.Resolve<Func<DriverService, LancarVendaNoPrazoPage>>()(driverService),
            };
        }
    }
}
