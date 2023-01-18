using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Injection;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Injection;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Injection;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Injection;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Injection;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Injection;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Injection
{
    public class CadastroDePessoaInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterModule<CadastroDeClienteInjection>();
                containerBuilder.RegisterModule<CadastroDeColaboradorInjection>();
                containerBuilder.RegisterModule<CadastroDeFornecedorInjection>();
                containerBuilder.RegisterModule<EdicaoDeClienteInjection>();
                containerBuilder.RegisterModule<EdicaoDeColaboradorInjection>();
                containerBuilder.RegisterModule<EdicaoDeFornecedorInjection>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDePessoaInjection).Namespace, exception);
            }
        }
    }
}
