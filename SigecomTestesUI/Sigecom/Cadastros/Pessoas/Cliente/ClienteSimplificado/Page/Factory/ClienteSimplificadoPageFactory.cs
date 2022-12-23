using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Enum;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page.Interfaces;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page.Factory
{
    public class ClienteSimplificadoPageFactory: IClienteSimplificadoPageFactory
    {
        public IClienteSimplificadoPage Fabricar(DriverService driverService, TipoDeClienteSimplificado tipoDeClienteSimplificado)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            return tipoDeClienteSimplificado switch
            {
                TipoDeClienteSimplificado.FisicoCompleto => beginLifetimeScope.Resolve<Func<DriverService, ClienteSimplificadoFisicoCompletoPage>>()(
                    driverService),
                TipoDeClienteSimplificado.FisicoComNome => beginLifetimeScope.Resolve<Func<DriverService,ClienteSimplificadoFisicoComNomePage>>()(driverService),
                TipoDeClienteSimplificado.FisicoComNomeECpf => beginLifetimeScope.Resolve<Func<DriverService, ClienteSimplificadoFisicoComNomeECpfPage>>()(driverService),
                TipoDeClienteSimplificado.JuridicoComNome => beginLifetimeScope.Resolve<Func<DriverService, ClienteSimplificadoJuridicoComNomePage>>()(driverService),
                TipoDeClienteSimplificado.JuridicoComNomeECpf => beginLifetimeScope.Resolve<Func<DriverService, ClienteSimplificadoJuridicoComNomeECpfPage>>()(driverService),
                _ => throw new ArgumentOutOfRangeException(nameof(tipoDeClienteSimplificado), tipoDeClienteSimplificado, null)
            };
        }
    }
}
