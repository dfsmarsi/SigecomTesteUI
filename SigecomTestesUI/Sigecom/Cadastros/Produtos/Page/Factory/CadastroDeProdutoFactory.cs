using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Page.Interfaces;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Page.Factory
{
    public class CadastroDeProdutoFactory : ICadastroDeProdutoFactory
    {
        public ICadastroDeProdutoPage Fabricar(DriverService driverService, TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();

            return tipoDeProduto switch
            {
                TipoDeProduto.Balanca => beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoBalancaPage>>()(driverService),
                TipoDeProduto.Produto => beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoSimplesPage>>()(driverService),
                TipoDeProduto.Combustivel => beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoCombustivelPage>>()(driverService),
                TipoDeProduto.Grade => beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoGradePage>>()(driverService),
                TipoDeProduto.Medicamento => beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoMedicamentoPage>>()(driverService)
            };
        }
    }
}
