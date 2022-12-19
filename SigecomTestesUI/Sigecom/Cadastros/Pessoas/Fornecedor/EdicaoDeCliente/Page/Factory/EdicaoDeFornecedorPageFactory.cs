using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeCliente.Page.Interfaces;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeCliente.Page.Factory
{
    public class EdicaoDeFornecedorPageFactory: IEdicaoDeFornecedorPageFactory
    {
        public IEdicaoDeFornecedorPage Fabricar(DriverService driverService, ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var life = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            return classificacaoDePessoa switch
            {
                ClassificacaoDePessoa.FisicaSimples => life.Resolve<Func<DriverService, EdicaoDeFornecedorFisicoSimplesPage>>()(driverService)
            };
        }
    }
}
