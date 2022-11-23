using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste.Interfaces;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria
{
    public class CadastroDeCategoriaTeste : BaseTestes
    {
        private readonly ICadastroDeCategoriaBaseTeste _cadastroDeCategoriaBaseTeste;
        public CadastroDeCategoriaTeste(ICadastroDeCategoriaBaseTeste cadastroDeCategoriaBaseTeste) =>
            _cadastroDeCategoriaBaseTeste = cadastroDeCategoriaBaseTeste;

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
            _cadastroDeCategoriaBaseTeste.RetornarCadastroDeCategoria(dadosDeCategoria, out var cadastroDeCategoriaPage);
            _cadastroDeCategoriaBaseTeste.AbrirTelaDeCategoriaParaTeste(cadastroDeCategoriaPage);

            // Act
            cadastroDeCategoriaPage.PreencherCamposDaCategoriaGrade();
            cadastroDeCategoriaPage.Gravar();

            // Assert
            _cadastroDeCategoriaBaseTeste.PesquisarCategoriaGravada(cadastroDeCategoriaPage, dadosDeCategoria);
        }
    }
}
