using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Model;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste
{
    public class CadastroDeCategoriaCombustivelTeste: CadastroDeCategoriaBaseTeste
    {
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
                {"Grupo", "GRUPO COMBUSTIVEL"},
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
    }
}
