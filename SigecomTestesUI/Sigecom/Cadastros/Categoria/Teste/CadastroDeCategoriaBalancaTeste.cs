using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Model;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste.Interfaces;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste
{
    public class CadastroDeCategoriaBalancaTeste
    {
        private readonly ICadastroDeCategoriaBaseTeste _cadastroDeCategoriaBaseTeste;
        public CadastroDeCategoriaBalancaTeste(ICadastroDeCategoriaBaseTeste cadastroDeCategoriaBaseTeste) => 
            _cadastroDeCategoriaBaseTeste = cadastroDeCategoriaBaseTeste;

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
            _cadastroDeCategoriaBaseTeste.RetornarCadastroDeCategoria(dadosDeCategoriaBalanca, out var cadastroDeCategoriaPage);
            _cadastroDeCategoriaBaseTeste.AbrirTelaDeCategoriaParaTeste(cadastroDeCategoriaPage);

            // Act
            cadastroDeCategoriaPage.PreencherCamposDaCategoria(CadastroDeCategoriaModel.ElementoToggleBalanca);
            cadastroDeCategoriaPage.Gravar();

            // Assert
            _cadastroDeCategoriaBaseTeste.PesquisarCategoriaGravada(cadastroDeCategoriaPage, dadosDeCategoriaBalanca);
        }
    }
}
