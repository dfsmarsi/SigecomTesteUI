using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page.Factory;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page.Interfaces;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Teste;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Injection
{
    public class EdicaoDeFornecedorInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<EdicaoDeFornecedorBasePage>();
                containerBuilder.RegisterType<EdicaoDeFornecedorJuridicoSimplesPage>();
                containerBuilder.RegisterType<EdicaoDeFornecedorJuridicoCompletoPage>();
                containerBuilder.RegisterType<EdicaoDeFornecedorFisicoSimplesPage>();
                containerBuilder.RegisterType<EdicaoDeFornecedorFisicoCompletoPage>();
                containerBuilder.RegisterType<EdicaoDeFornecedorPageFactory>().As<IEdicaoDeFornecedorPageFactory>();
                containerBuilder.RegisterType<EdicaoDeFornecedorJuridicoSimplesTeste>();
                containerBuilder.RegisterType<EdicaoDeFornecedorJuridicoCompletoTeste>();
                containerBuilder.RegisterType<EdicaoDeFornecedorFisicoSimplesTeste>();
                containerBuilder.RegisterType<EdicaoDeFornecedorFisicoCompletoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(EdicaoDeFornecedorInjection).Namespace, exception);
            }
        }
    }
}
