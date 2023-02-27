using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Compra.Xml.Page;
using SigecomTestesUI.Sigecom.Compra.Xml.Teste;
using System;

namespace SigecomTestesUI.Sigecom.Compra.Xml.Injection
{
    public class CompraXmlInjection:Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CompraXmlCompletaPage>();
                containerBuilder.RegisterType<CompraXmlCompletaTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CompraXmlInjection).Namespace, exception);
            }
        }
    }
}
