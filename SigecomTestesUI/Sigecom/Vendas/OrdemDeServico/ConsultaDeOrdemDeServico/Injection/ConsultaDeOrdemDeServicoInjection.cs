using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.ConsultaDeOrdemDeServico.Page;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.ConsultaDeOrdemDeServico.Teste;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.ConsultaDeOrdemDeServico.Injection
{
    public class ConsultaDeOrdemDeServicoInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<EditarNaConsultaDeOrdemDeServicoPage>();
                containerBuilder.RegisterType<EditarNaConsultaDeOrdemDeServicoTeste>();
                containerBuilder.RegisterType<FaturarNaConsultaDeOrdemDeServicoPage>();
                containerBuilder.RegisterType<FaturarNaConsultaDeOrdemDeServicoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ConsultaDeOrdemDeServicoInjection).Namespace, exception);
            }
        }
    }
}
