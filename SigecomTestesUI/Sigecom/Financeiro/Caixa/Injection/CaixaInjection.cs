using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Financeiro.Caixa.Page;
using SigecomTestesUI.Sigecom.Financeiro.Caixa.Teste;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.Caixa.Injection
{
    public class CaixaInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<AbrirCaixaPage>();
                containerBuilder.RegisterType<AbrirCaixaTeste>();
                containerBuilder.RegisterType<SangriaSuprimentoNoCaixaPage>();
                containerBuilder.RegisterType<SangriaSuprimentoNoCaixaTeste>();
                containerBuilder.RegisterType<ReabrirCaixaPage>();
                containerBuilder.RegisterType<ReabrirCaixaTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CaixaInjection).Namespace, exception);
            }
        }
    }
}
