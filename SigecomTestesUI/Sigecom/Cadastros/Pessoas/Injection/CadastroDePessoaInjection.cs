using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor;
using SigecomTestesUI.Sigecom.Pesquisa.PesquisaPessoa;
using System;

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
                containerBuilder.RegisterType<CadastroDeColaboradorPage>();
                containerBuilder.RegisterType<CadastroDeColaboradorTeste>();
                containerBuilder.RegisterType<CadastroDeFornecedorPage>();
                containerBuilder.RegisterType<CadastroDeFornecedorTeste>();
                containerBuilder.RegisterType<PesquisaDePessoaPage>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDePessoaInjection).Namespace, exception);
            }
        }
    }
}
