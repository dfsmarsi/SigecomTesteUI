using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Page;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Teste;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Injection
{
    public class OrcamentoInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<LancarItensNoOrcamentoPage>();
                containerBuilder.RegisterType<LancarItensNoOrcamentoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(OrcamentoInjection).Namespace, exception);
            }
        }
    }
}
