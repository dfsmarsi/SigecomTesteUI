using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Estoque.AnaliseDeEstoque.Page;
using SigecomTestesUI.Sigecom.Estoque.AnaliseDeEstoque.Teste;

namespace SigecomTestesUI.Sigecom.Estoque.AnaliseDeEstoque.Injection
{
    public class AnaliseDeEstoqueInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<FiltroDaAnaliseDeEstoquePage>();
                containerBuilder.RegisterType<FiltroDaAnaliseDeEstoqueTeste>();
                containerBuilder.RegisterType<HistoricoDeMovimentacaoPage>();
                containerBuilder.RegisterType<HistoricoDeMovimentacaoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(AnaliseDeEstoqueInjection).Namespace, exception);
            }
        }
    }
}
