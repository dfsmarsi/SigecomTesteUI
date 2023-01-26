using Autofac;
using System;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Page;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Teste;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Injection
{
    public class ConsultaDeOrcamentoInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<EditarNaConsultaDeOrcamentoPage>();
                containerBuilder.RegisterType<EditarNaConsultaDeOrcamentoTeste>();
                containerBuilder.RegisterType<GerarVendaNaConsultaDeOrcamentoPage>();
                containerBuilder.RegisterType<GerarVendaNaConsultaDeOrcamentoTeste>();
                containerBuilder.RegisterType<GerarOrdemDeServicoNaConsultaDeOrcamentoPage>();
                containerBuilder.RegisterType<GerarOrdemDeServicoNaConsultaDeOrcamentoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ConsultaDeOrcamentoInjection).Namespace, exception);
            }
        }
    }
}
