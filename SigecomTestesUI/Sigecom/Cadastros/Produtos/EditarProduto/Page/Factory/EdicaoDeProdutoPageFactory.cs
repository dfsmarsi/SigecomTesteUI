using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page.Interface;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page.Factory
{
    public class EdicaoDeProdutoPageFactory: IEdicaoDeProdutoPageFactory
    {
        public IEdicaoDeProdutoPage Fabricar(DriverService driverService, TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();

            return tipoDeProduto switch
            {
                TipoDeProduto.Produto => beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeProdutoSimplesPage>>()(driverService),
                TipoDeProduto.Balanca => beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeProdutoBalancaPage>>()(driverService),
                TipoDeProduto.Grade => beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeProdutoGradePage>>()(driverService),
                TipoDeProduto.Combustivel => beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeProdutoCombustivelPage>>()(driverService),
            };
        }
    }
}
