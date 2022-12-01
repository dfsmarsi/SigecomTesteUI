using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.Teste;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.Teste;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.Teste;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Injection
{
    public class CadastroDePessoaInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CadastroDeClientePage>();
                containerBuilder.RegisterType<CadastroDeClienteTeste>();
                containerBuilder.RegisterType<CadastroDeClienteCompletoTeste>();
                containerBuilder.RegisterType<CadastroDeColaboradorPage>();
                containerBuilder.RegisterType<CadastroDeColaboradorTeste>();
                containerBuilder.RegisterType<CadastroDeColaboradorCompletoTeste>();
                containerBuilder.RegisterType<CadastroDeFornecedorPage>();
                containerBuilder.RegisterType<CadastroDeFornecedorSimplesTeste>();
                containerBuilder.RegisterType<CadastroDeFornecedorCompletoTeste>();
                containerBuilder.RegisterType<PesquisaDePessoaPage>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDePessoaInjection).Namespace, exception);
            }
        }
    }
}
