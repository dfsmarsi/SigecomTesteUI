﻿using System;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Enum;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Page.Factory
{
    public class CadastroDeTabelaDePrecoPageFactory: ICadastroDeTabelaDePrecoPageFactory
    {
        public ICadastroDeTabelaDePrecoPage Fabricar(DriverService driverService,
            QuantidadeDeProdutoParaTabelaDePreco quantidadeDeProdutoParaTabelaDePreco)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();

            return quantidadeDeProdutoParaTabelaDePreco switch
            {
                QuantidadeDeProdutoParaTabelaDePreco.TodosOsProdutos => beginLifetimeScope.Resolve<Func<DriverService, CadastroDeTabelaDePrecoTodosOsProdutosPage>>()(driverService),
                QuantidadeDeProdutoParaTabelaDePreco.ProdutoEspecifico => beginLifetimeScope.Resolve<Func<DriverService, CadastroDeTabelaDePrecoProdutoEspecificoPage>>()(driverService),
                _ => throw new ArgumentOutOfRangeException(nameof(quantidadeDeProdutoParaTabelaDePreco),
                    quantidadeDeProdutoParaTabelaDePreco, null)
            };
        }
    }
}
