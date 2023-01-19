using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Page;
using SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Teste;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.ConsultaDeCondicional.Injection
{
    public class ConsultaDeCondicionalInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<EditarNaConsultaDeCondicionalPage>();
                containerBuilder.RegisterType<EditarNaConsultaDeCondicionalTeste>();
                containerBuilder.RegisterType<ComprarParcialNaConsultaDeCondicionalPage>();
                containerBuilder.RegisterType<ComprarParcialNaConsultaDeCondicionalTeste>();
                containerBuilder.RegisterType<ComprarTodosNaConsultaDeCondicionalPage>();
                containerBuilder.RegisterType<ComprarTodosNaConsultaDeCondicionalTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(ConsultaDeCondicionalInjection).Namespace, exception);
            }
        }
    }
}
