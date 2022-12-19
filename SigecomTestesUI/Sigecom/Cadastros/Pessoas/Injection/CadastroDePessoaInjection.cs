using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Page;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Teste;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Page;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Teste;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Page;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Teste;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Injection
{
    public class CadastroDePessoaInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CadastroDeClienteFisicoPage>();
                containerBuilder.RegisterType<CadastroDeClienteJuridicoPage>();
                containerBuilder.RegisterType<CadastroDeClienteJuridicoSimplesTeste>();
                containerBuilder.RegisterType<CadastroDeClienteJuridicoCompletoTeste>();
                containerBuilder.RegisterType<CadastroDeClienteFisicoSimplesTeste>();
                containerBuilder.RegisterType<CadastroDeClienteFisicoCompletoTeste>();
                containerBuilder.RegisterType<CadastroDeColaboradorFisicoPage>();
                containerBuilder.RegisterType<CadastroDeColaboradorFisicoSimplesTeste>();
                containerBuilder.RegisterType<CadastroDeColaboradorFisicoCompletoTeste>();
                containerBuilder.RegisterType<CadastroDeColaboradorJuridicoPage>();
                containerBuilder.RegisterType<CadastroDeColaboradorJuridicoSimplesTeste>();
                containerBuilder.RegisterType<CadastroDeColaboradorJuridicoCompletoTeste>();
                containerBuilder.RegisterType<CadastroDeFornecedorFisicoPage>();
                containerBuilder.RegisterType<CadastroDeFornecedorFisicoSimplesTeste>();
                containerBuilder.RegisterType<CadastroDeFornecedorFisicoCompletoTeste>();
                containerBuilder.RegisterType<CadastroDeFornecedorJuridicoPage>();
                containerBuilder.RegisterType<CadastroDeFornecedorJuridicoSimplesTeste>();
                containerBuilder.RegisterType<CadastroDeFornecedorJuridicoCompletoTeste>();
                containerBuilder.RegisterType<PesquisaDePessoaPage>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDePessoaInjection).Namespace, exception);
            }
        }
    }
}
