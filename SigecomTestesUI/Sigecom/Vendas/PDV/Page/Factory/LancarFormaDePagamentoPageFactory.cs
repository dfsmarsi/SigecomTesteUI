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
                FormaDePagamento.Credito => lifetimeScope.Resolve<Func<DriverService, LancarVendaNoCreditoPage>>()(driverService),
                FormaDePagamento.Cheque => lifetimeScope.Resolve<Func<DriverService,LancarVendaNoChequePage>>()(driverService),
                FormaDePagamento.Banco => lifetimeScope.Resolve<Func<DriverService, LancarVendaNoBancoPage>>()(driverService),
                _ => throw new ArgumentOutOfRangeException(nameof(formaDePagamento), formaDePagamento, null)
            };
        }
    }
}
