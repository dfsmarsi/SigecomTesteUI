using System;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using Autofac;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Model;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.PesquisaDeCategoria;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria
{
    public class CadastroDeCategoriaTeste : BaseTestes
    {
        [Test(Description = "Cadastro de Categoria Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Categoria")]
        public void CadastrarCategoriaSomenteCamposObrigatorios()
        {
            var dadosDeCategoria = new Dictionary<string, string>
            {
                {"Grupo", "GRADE"},
                {"Markup", "5"}
            };
            // Arange
            RetornarCadastroDeCategoria(dadosDeCategoria, out var cadastroDeCategoriaPage);
            AbrirTelaDeCategoriaParaTeste(cadastroDeCategoriaPage);

            // Act
            cadastroDeCategoriaPage.PreencherCamposDaCategoriaGrade();
            cadastroDeCategoriaPage.Gravar();

            // Assert
            PesquisarCategoriaGravada(cadastroDeCategoriaPage, dadosDeCategoria);
        }

        [Test(Description = "Cadastro de Categoria de Balança Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Categoria")]
        public void CadastrarCategoriaBalancaSomenteCamposObrigatorios()
        {
            var dadosDeCategoriaBalanca = new Dictionary<string, string>
            {
                {"Grupo", "BALANCA"},
                {"Markup", "10"}
            };

            // Arange
            RetornarCadastroDeCategoria(dadosDeCategoriaBalanca, out var cadastroDeCategoriaPage);
            AbrirTelaDeCategoriaParaTeste(cadastroDeCategoriaPage);

            // Act
            cadastroDeCategoriaPage.PreencherCamposDaCategoria(CadastroDeCategoriaModel.ElementoToggleBalanca);
            cadastroDeCategoriaPage.Gravar();

            // Assert
            PesquisarCategoriaGravada(cadastroDeCategoriaPage, dadosDeCategoriaBalanca);
        }

        [Test(Description = "Cadastro de Categoria de Combustivel Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Categoria")]
        public void CadastrarCategoriaCombustivelSomenteCamposObrigatorios()
        {
            var dadosDeCategoriaCombustivel = new Dictionary<string, string>
            {
                {"Grupo", "COMBUSTIVEL"},
                {"Markup", "10"}
            };

            // Arange
            RetornarCadastroDeCategoria(dadosDeCategoriaCombustivel, out var cadastroDeCategoriaPage);
            AbrirTelaDeCategoriaParaTeste(cadastroDeCategoriaPage);

            // Act
            cadastroDeCategoriaPage.PreencherCamposDaCategoria(CadastroDeCategoriaModel.ElementoToggleCombustivel);
            cadastroDeCategoriaPage.Gravar();

            // Assert
            PesquisarCategoriaGravada(cadastroDeCategoriaPage, dadosDeCategoriaCombustivel);
        }

        [Test(Description = "Cadastro de Categoria de Medicamento Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Categoria")]
        public void CadastrarCategoriaMedicamentoSomenteCamposObrigatorios()
        {
            var dadosDeCategoriaMedicamento = new Dictionary<string, string>
            {
                {"Grupo", "MEDICAMENTO"},
                {"Markup", "10"}
            };

            // Arange
            RetornarCadastroDeCategoria(dadosDeCategoriaMedicamento, out var cadastroDeCategoriaPage);
            AbrirTelaDeCategoriaParaTeste(cadastroDeCategoriaPage);

            // Act
            cadastroDeCategoriaPage.PreencherCamposDaCategoria(CadastroDeCategoriaModel.ElementoToggleMedicamento);
            cadastroDeCategoriaPage.Gravar();

            // Assert
            PesquisarCategoriaGravada(cadastroDeCategoriaPage, dadosDeCategoriaMedicamento);
        }

        private void RetornarCadastroDeCategoria(Dictionary<string, string> dadosDeCategoria,
            out CadastroDeCategoriaPage cadastroDeCategoriaPage)
        {
            var resolveCadastroDeCategoriaPage = _lifetimeScope
                .Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeCategoriaPage>>();
            cadastroDeCategoriaPage = resolveCadastroDeCategoriaPage(DriverService, dadosDeCategoria);
        }

        private static void AbrirTelaDeCategoriaParaTeste(CadastroDeCategoriaPage cadastroDeCategoriaPage)
        {
            cadastroDeCategoriaPage.ClicarNaOpcaoDoMenu();
            cadastroDeCategoriaPage.ClicarNaOpcaoDoSubMenu();
            cadastroDeCategoriaPage.ClicarNoBotaoNovoCategoria();
            cadastroDeCategoriaPage.ClicarNoBotaoNovo();
        }

        private void PesquisarCategoriaGravada(CadastroDeCategoriaPage cadastroDeCategoriaPage, IReadOnlyDictionary<string, string> dadosDoCadastro)
        {
            cadastroDeCategoriaPage.ClicarNaOpcaoDoPesquisar();
            var resolvePesquisaDeCategoriaPage = _lifetimeScope.Resolve<Func<DriverService, PesquisaDeCategoriaPage>>();
            var pesquisaDeCategoriaPage = resolvePesquisaDeCategoriaPage(DriverService);
            pesquisaDeCategoriaPage.PesquisarCategoria(dadosDoCadastro["Grupo"]);
            Assert.True(pesquisaDeCategoriaPage.VerificarSeExisteCategoriaNaGrid(dadosDoCadastro["Grupo"]));
            pesquisaDeCategoriaPage.FecharJanelaComEsc();
            cadastroDeCategoriaPage.FecharJanelaCadastroDeProdutoComEsc(
                CadastroDeCategoriaModel.ElementoTelaCadastroDeCategoria);
            cadastroDeCategoriaPage.FecharJanelaCadastroDeProdutoComEsc(
                CadastroDeCategoriaModel.ElementoTelaControleDeCategoria);
        }
    }
}
