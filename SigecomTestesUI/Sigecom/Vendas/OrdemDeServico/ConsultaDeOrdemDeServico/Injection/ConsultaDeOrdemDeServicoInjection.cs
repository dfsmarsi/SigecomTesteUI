using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Page;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Teste;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.ConsultaDeOrdemDeServico.Injection
{
    public class ConsultaDeOrdemDeServicoInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CadastrarObjetoPage>();
                containerBuilder.RegisterType<CadastrarObjetoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ConsultaDeOrdemDeServicoInjection).Namespace, exception);
            }
        }
    }
}
