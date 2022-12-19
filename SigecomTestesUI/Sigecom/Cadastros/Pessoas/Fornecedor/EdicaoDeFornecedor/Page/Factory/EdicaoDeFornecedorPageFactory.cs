using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page.Interfaces;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page.Factory
{
    public class EdicaoDeFornecedorPageFactory: IEdicaoDeFornecedorPageFactory
    {
        public IEdicaoDeFornecedorPage Fabricar(DriverService driverService, ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var life = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            return classificacaoDePessoa switch
            {
                ClassificacaoDePessoa.FisicaSimples => life.Resolve<Func<DriverService, EdicaoDeFornecedorFisicoSimplesPage>>()(driverService),
                ClassificacaoDePessoa.JuridicaSimples => life.Resolve<Func<DriverService, EdicaoDeFornecedorJuridicoSimplesPage>>()(driverService),
                ClassificacaoDePessoa.FisicaCompleta => life.Resolve<Func<DriverService, EdicaoDeFornecedorFisicoCompletoPage>>()(driverService),
                ClassificacaoDePessoa.JuridicaCompleta => life.Resolve<Func<DriverService, EdicaoDeFornecedorJuridicoCompletoPage>>()(driverService),
                _ => throw new ArgumentOutOfRangeException(nameof(classificacaoDePessoa), classificacaoDePessoa, null)
            };
        }
    }
}
