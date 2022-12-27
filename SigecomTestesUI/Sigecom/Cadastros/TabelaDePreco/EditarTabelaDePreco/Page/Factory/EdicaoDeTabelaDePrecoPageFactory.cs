using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Enum;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Page.Factory
{
    public class EdicaoDeTabelaDePrecoPageFactory : IEdicaoDeTabelaDePrecoPageFactory
    {
        public IEdicaoDeTabelaDePrecoPage Fabricar(DriverService driverService,
            QuantidadeDeProdutoParaTabelaDePreco quantidadeDeProdutoParaTabelaDePreco)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            return quantidadeDeProdutoParaTabelaDePreco switch
            {
                QuantidadeDeProdutoParaTabelaDePreco.TodosOsProdutos => beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeTabelaDePrecoComTodosOsProdutosPage>>()(driverService),
                QuantidadeDeProdutoParaTabelaDePreco.ProdutoEspecifico => beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeTabelaDePrecoComProdutoEspecificoPage>>()(driverService),
                _ => throw new ArgumentOutOfRangeException(nameof(quantidadeDeProdutoParaTabelaDePreco), quantidadeDeProdutoParaTabelaDePreco, null)
            };
        }
    }
}
