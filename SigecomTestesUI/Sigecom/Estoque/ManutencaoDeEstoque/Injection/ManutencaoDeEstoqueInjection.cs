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
                containerBuilder.RegisterType<AlteracaoEmMassaPrincipalPage>();
                containerBuilder.RegisterType<AlteracaoEmMassaPrincipalTeste>();
                containerBuilder.RegisterType<AlteracaoEmMassaDaVendaPage>();
                containerBuilder.RegisterType<AlteracaoEmMassaDaVendaTeste>();
                containerBuilder.RegisterType<AlteracaoEmMassaDoCustoPage>();
                containerBuilder.RegisterType<AlteracaoEmMassaDoCustoTeste>();
                containerBuilder.RegisterType<AlteracaoEmMassaDoMarkupPage>();
                containerBuilder.RegisterType<AlteracaoEmMassaDoMarkupTeste>();
                containerBuilder.RegisterType<AlteracaoEmMassaComTodasAsTogglesPage>();
                containerBuilder.RegisterType<AlteracaoEmMassaComTodasAsTogglesTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ManutencaoDeEstoqueInjection).Namespace, exception);
            }
        }
    }
}
