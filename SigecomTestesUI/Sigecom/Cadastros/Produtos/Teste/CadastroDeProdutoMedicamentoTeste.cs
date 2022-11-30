using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste
{
    public class CadastroDeProdutoMedicamentoTeste : BaseTestes
    {
        public void RetornarCadastroDeProduto(out CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeProdutoPage =
                beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoPage>>();
            cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService);
        }

        [Test(Description = "Cadastro de Produto de Medicamento Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Produto")]
        public void CadastrarProdutoDeMedicamentoSomenteCamposObrigatorios()
        {
            // Arange
            RetornarCadastroDeProduto(out var cadastroDeProdutoPage);
            cadastroDeProdutoPage.AdicionarUmNovoProdutoNaTelaDeCadastroDeProduto(cadastroDeProdutoPage);

            // Act
            cadastroDeProdutoPage.PreencherCamposDoProduto(TipoDeProduto.Medicamento);
            cadastroDeProdutoPage.VerificarSePrecoDeVendaFoiCalculado();
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaImpostos);
            cadastroDeProdutoPage.PreencherCamposDeImpostos();
            cadastroDeProdutoPage.AcessarAba(CadastroDeProdutoModel.AbaMedicamento);
            cadastroDeProdutoPage.PreencherCamposDaAba(TipoDeProduto.Medicamento);
            cadastroDeProdutoPage.Gravar();

            // Assert
            cadastroDeProdutoPage.RealizarFluxoDePesquisaDoProduto(cadastroDeProdutoPage, TipoDeProduto.Medicamento);
        }
    }
}
