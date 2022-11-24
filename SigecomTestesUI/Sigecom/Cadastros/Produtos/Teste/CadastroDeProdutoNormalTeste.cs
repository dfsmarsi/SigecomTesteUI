﻿using NUnit.Allure.Attributes;
using NUnit.Framework;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste
{
    public class CadastroDeProdutoNormalTeste: CadastroDeProdutoBaseTeste
    {
        [Test(Description = "Cadastro de Produto Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Douglas")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Produto")]
        public void CadastrarProdutoSomenteCamposObrigatorios()
        {
            var dadosDeProduto = AdicionandoInformacoesNecessariasParaOTeste();
            // Arange
            RetornarCadastroDeProduto(dadosDeProduto, out var cadastroDeProdutoPage);
            AbrirTelaDeProdutoParaTeste(cadastroDeProdutoPage);

            // Act
            AtribuirDadosDoProdutoComImpostos(cadastroDeProdutoPage);
            cadastroDeProdutoPage.Gravar();

            // Assert
            RealizarFluxoDePesquisaDoProduto(cadastroDeProdutoPage, dadosDeProduto);
        }

        private static Dictionary<string, string> AdicionandoInformacoesNecessariasParaOTeste() =>
            new Dictionary<string, string>
            {
                {"Nome","PRODUTO"},
                {"Unidade", "UN"},
                {"CodigoInterno","int"},
                {"Categoria","PRODUTO"},
                {"Custo","5,00"},
                {"Markup","100,00"},
                {"PrecoVenda","10,00"},
                {"Referencia","ref"},
                {"NCM","22030000"}
            };
    }
}