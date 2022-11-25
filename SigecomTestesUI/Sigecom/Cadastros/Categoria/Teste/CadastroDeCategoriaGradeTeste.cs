using NUnit.Allure.Attributes;
using NUnit.Framework;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste
{
    public class CadastroDeCategoriaTeste: CadastroDeCategoriaBaseTeste
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
                {"Grupo", "GRUPO GRADE"},
                {"Markup", "10"}
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
    }
}
