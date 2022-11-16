using System;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using Autofac;
using SigecomTestesUI.Services;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria
{
    public class CadastroDeCategoriaTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDeCategoria = new Dictionary<string, string>()
        {
            {"Grupo", "Grade"},
            {"Markup", "5"}
        };

        [Test(Description = "Cadastro de Categoria Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Categoria")]
        public void CadastrarProdutoSomenteCamposObrigatorios()
        {
            var resolveCadastroDeCategoriaPage = _lifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeCategoriaPage>>();
            var cadastroDeCategoriaPage = resolveCadastroDeCategoriaPage(DriverService, _dadosDeCategoria);
            // Arange
            cadastroDeCategoriaPage.ClicarNaOpcaoDoMenu();
            cadastroDeCategoriaPage.ClicarNaOpcaoDoSubMenu();
            cadastroDeCategoriaPage.ClicarNoBotaoNovoCategoria();
            cadastroDeCategoriaPage.ClicarNoBotaoNovo();
            // Act
            cadastroDeCategoriaPage.PreencherCamposDoProduto();
            cadastroDeCategoriaPage.Gravar();

            // Assert
            cadastroDeCategoriaPage.FecharJanelaCadastroDeProdutoComEsc();
        }
    }
}
