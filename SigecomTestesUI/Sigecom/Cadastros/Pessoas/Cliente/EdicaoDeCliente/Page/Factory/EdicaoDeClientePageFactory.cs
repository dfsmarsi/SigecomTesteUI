using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Interfaces;
using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Factory
{
    public class EdicaoDeClientePageFactory: IEdicaoDeClientePageFactory
    {
        public IEdicaoDeClientePage Fabricar(DriverService driverService, ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var life = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            return classificacaoDePessoa switch
            {
                ClassificacaoDePessoa.FisicaSimples => life.Resolve<Func<DriverService, EdicaoDeClienteFisicoSimplesPage>>()(driverService),
                ClassificacaoDePessoa.JuridicaSimples => life.Resolve<Func<DriverService, EdicaoDeClienteJuridicoSimplesPage>>()(driverService),
                ClassificacaoDePessoa.FisicaCompleta => life.Resolve<Func<DriverService, EdicaoDeClienteFisicoCompletoPage>>()(driverService)
            };
        }
    }
}
