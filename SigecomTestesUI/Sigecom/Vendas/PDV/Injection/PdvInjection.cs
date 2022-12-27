using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page;
using SigecomTestesUI.Sigecom.Vendas.PDV.Teste;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Injection
{
    public class PdvInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<LancarItensNoPdvPage>();
                containerBuilder.RegisterType<PdvLancarItensTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(PdvInjection).Namespace, exception);
            }
        }
    }
}
