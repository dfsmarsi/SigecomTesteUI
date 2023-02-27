using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Compra.Avulsa.Page;
using SigecomTestesUI.Sigecom.Compra.Avulsa.Teste;

namespace SigecomTestesUI.Sigecom.Compra.Avulsa.Injection
{
    public class CompraAvulsaInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CompraAvulsaCompletaPage>();
                containerBuilder.RegisterType<CompraAvulsaCompletaTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CompraAvulsaInjection).Namespace, exception);
            }
        }
    }
}
