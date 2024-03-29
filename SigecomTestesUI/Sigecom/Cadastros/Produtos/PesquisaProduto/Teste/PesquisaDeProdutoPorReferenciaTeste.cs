﻿using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Teste
{
    public class PesquisaDeProdutoPorReferenciaTeste:BaseTestes
    {
        [Test(Description = "Pesquisa de produto pela referencia")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Pesquisa")]
        [AllureSubSuite("Produto")]
        public void PesquisarProdutoPelaReferencia()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>();
            var pesquisaDeProdutoPage = resolvePesquisaDeProdutoPage(DriverService);

            // Act
            pesquisaDeProdutoPage.PesquisarComF9UmProdutoNaTelaPrincipal(beginLifetimeScope);
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(PesquisaDeProdutoInformacoesParaTesteModel.ReferenciaDoProduto);

            // Assert
            Assert.True(pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto));
            pesquisaDeProdutoPage.FecharJanelaComEsc();

        }
    }
}
