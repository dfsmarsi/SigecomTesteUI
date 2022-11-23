using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Model;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste.Interfaces;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste
{
    public class CadastroDeCategoriaCombustivelTeste
    {
        private readonly ICadastroDeCategoriaBaseTeste _cadastroDeCategoriaBaseTeste;
        public CadastroDeCategoriaCombustivelTeste(ICadastroDeCategoriaBaseTeste cadastroDeCategoriaBaseTeste) => 
            _cadastroDeCategoriaBaseTeste = cadastroDeCategoriaBaseTeste;

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
            _cadastroDeCategoriaBaseTeste.RetornarCadastroDeCategoria(dadosDeCategoriaCombustivel, out var cadastroDeCategoriaPage);
            _cadastroDeCategoriaBaseTeste.AbrirTelaDeCategoriaParaTeste(cadastroDeCategoriaPage);

            // Act
            cadastroDeCategoriaPage.PreencherCamposDaCategoria(CadastroDeCategoriaModel.ElementoToggleCombustivel);
            cadastroDeCategoriaPage.Gravar();

            // Assert
            _cadastroDeCategoriaBaseTeste.PesquisarCategoriaGravada(cadastroDeCategoriaPage, dadosDeCategoriaCombustivel);
        }
    }
}
