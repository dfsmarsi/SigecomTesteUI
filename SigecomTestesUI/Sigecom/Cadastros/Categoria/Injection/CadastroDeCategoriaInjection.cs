using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.PesquisaDeCategoria;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste.Interfaces;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.Injection
{
    public class CadastroDeCategoriaInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CadastroDeCategoriaPage>();
                containerBuilder.RegisterType<CadastroDeCategoriaTeste>();
                containerBuilder.RegisterType<PesquisaDeCategoriaPage>();
                containerBuilder.RegisterType<CadastroDeCategoriaBaseTeste>().As<ICadastroDeCategoriaBaseTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDeCategoriaInjection).Namespace, exception);
            }
        }
    }
}
