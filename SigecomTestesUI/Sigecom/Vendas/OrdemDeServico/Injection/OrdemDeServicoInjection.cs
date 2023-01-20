using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Page;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Teste;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Injection
{
    public class OrdemDeServicoInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<LancarItensNaOrdemDeServicoPage>();
                containerBuilder.RegisterType<LancarItensNaOrdemDeServicoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(OrdemDeServicoInjection).Namespace, exception);
            }
        }
    }
}
