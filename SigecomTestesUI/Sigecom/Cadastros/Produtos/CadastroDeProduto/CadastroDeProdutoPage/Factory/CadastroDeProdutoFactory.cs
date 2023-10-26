using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Enum;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage.Factory
{
    public class CadastroDeProdutoFactory : ICadastroDeProdutoFactory
    {
        public ICadastroDeProdutoPage Fabricar(DriverService driverService, TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();

            return tipoDeProduto switch
            {
                TipoDeProduto.Balanca => beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoBalancaPage>>()(driverService),
                TipoDeProduto.Simples => beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoSimplesPage>>()(driverService),
                TipoDeProduto.Combustivel => beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoCombustivelPage>>()(driverService),
                TipoDeProduto.Grade => beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoGradePage>>()(driverService),
                TipoDeProduto.Medicamento => beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoMedicamentoPage>>()(driverService),
                TipoDeProduto.Servico => beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoServicoPage>>()(driverService),
                TipoDeProduto.Completo => beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoCompletoPage>>()(driverService),
                _ => beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoSimplesPage>>()(driverService)
            };
        }
    }
}
