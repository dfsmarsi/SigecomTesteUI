using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.EdicaoDeProdutoPage.Interface;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.EdicaoDeProdutoPage.Factory
{
    public class EdicaoDeProdutoPageFactory: IEdicaoDeProdutoPageFactory
    {
        public IEdicaoDeProdutoPage Fabricar(DriverService driverService, TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();

            return tipoDeProduto switch
            {
                TipoDeProduto.Produto => beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeProdutoSimplesPage>>()(driverService)
            };
        }
    }
}
