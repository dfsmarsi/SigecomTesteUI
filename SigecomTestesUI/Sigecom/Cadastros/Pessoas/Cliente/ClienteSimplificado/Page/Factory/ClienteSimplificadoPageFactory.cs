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
            };
        }
    }
}
