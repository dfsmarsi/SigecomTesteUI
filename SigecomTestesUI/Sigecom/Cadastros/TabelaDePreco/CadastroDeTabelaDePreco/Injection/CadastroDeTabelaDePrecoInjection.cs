﻿using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Page;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Page.Factory;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Teste;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Injection
{
    public class CadastroDeTabelaDePrecoInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CadastroDeTabelaDePrecoBasePage>();
                containerBuilder.RegisterType<CadastroDeTabelaDePrecoProdutoEspecificoPage>();
                containerBuilder.RegisterType<CadastroDeTabelaDePrecoTodosOsProdutosPage>();
                containerBuilder.RegisterType<CadastroDeTabelaDePrecoPageFactory>().As<ICadastroDeTabelaDePrecoPageFactory>();
                containerBuilder.RegisterType<CadastroDeTabelaDePrecoComTodosOsProdutosTeste>();

            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDeTabelaDePrecoInjection).Namespace, exception);
            }
        }
    }
}
