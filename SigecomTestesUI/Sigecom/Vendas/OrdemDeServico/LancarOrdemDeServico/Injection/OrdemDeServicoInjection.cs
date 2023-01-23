using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Page;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Teste;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Injection
{
    public class OrdemDeServicoInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<LancarItensNaOrdemDeServicoPage>();
                containerBuilder.RegisterType<LancarItensNaOrdemDeServicoTeste>();
                containerBuilder.RegisterType<RemoverItemDaOrdemDeServicoPage>();
                containerBuilder.RegisterType<RemoverItemDaOrdemDeServicoTeste>();
                containerBuilder.RegisterType<AplicarDescontoNaOrdemDeServicoPage>();
                containerBuilder.RegisterType<AplicarDescontoNaOrdemDeServicoTeste>();
                containerBuilder.RegisterType<AlterarTabelaDePrecoNaOrdemDeServicoPage>();
                containerBuilder.RegisterType<AlterarTabelaDePrecoNaOrdemDeServicoTeste>();
                containerBuilder.RegisterType<VoltarNaOrdemDeServicoComEscPage>();
                containerBuilder.RegisterType<VoltarNaOrdemDeServicoComEscTeste>();
                containerBuilder.RegisterType<CadastrarObjetoPage>();
                containerBuilder.RegisterType<CadastrarObjetoTeste>();
                containerBuilder.RegisterType<CaracteristicasDaOrdemDeServicoPage>();
                containerBuilder.RegisterType<CaracteristicasDaOrdemDeServicoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(OrdemDeServicoInjection).Namespace, exception);
            }
        }
    }
}
