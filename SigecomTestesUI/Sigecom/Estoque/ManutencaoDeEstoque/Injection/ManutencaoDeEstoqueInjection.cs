using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Page;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Teste;

namespace SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Injection
{
    public class ManutencaoDeEstoqueInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<EntradaAvulsaNaManutencaoDeEstoquePage>();
                containerBuilder.RegisterType<EntradaAvulsaNaManutencaoDeEstoqueTeste>();
                containerBuilder.RegisterType<SaidaAvulsaNaManutencaoDeEstoquePage>();
                containerBuilder.RegisterType<SaidaAvulsaNaManutencaoDeEstoqueTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ManutencaoDeEstoqueInjection).Namespace, exception);
            }
        }
    }
}
