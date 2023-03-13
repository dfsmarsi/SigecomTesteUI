using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.PesquisaDeCategoria;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Page;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.Injection
{
    public class CadastroDeCategoriaInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CadastroDeCategoriaPage>();
                containerBuilder.RegisterType<CadastroDeCategoriaGradeTeste>();
                containerBuilder.RegisterType<CadastroDeCategoriaBalancaTeste>();
                containerBuilder.RegisterType<CadastroDeCategoriaCombustivelTeste>();
                containerBuilder.RegisterType<CadastroDeCategoriaMedicamentoTeste>();
                containerBuilder.RegisterType<PesquisaDeCategoriaPage>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDeCategoriaInjection).Namespace, exception);
            }
        }
    }
}
