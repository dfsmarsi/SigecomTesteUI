using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Page;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Teste;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Injection
{
    public class CadastroDeFornecedorInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CadastroDeFornecedorFisicoPage>();
                containerBuilder.RegisterType<CadastroDeFornecedorFisicoSimplesTeste>();
                containerBuilder.RegisterType<CadastroDeFornecedorFisicoCompletoTeste>();
                containerBuilder.RegisterType<CadastroDeFornecedorJuridicoPage>();
                containerBuilder.RegisterType<CadastroDeFornecedorJuridicoSimplesTeste>();
                containerBuilder.RegisterType<CadastroDeFornecedorJuridicoCompletoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDeFornecedorInjection).Namespace, exception);
            }
        }
    }
}
