using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Model;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste
{
    public class CadastroDeCategoriaBalancaTeste: CadastroDeCategoriaBaseTeste
    {
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
                {"Grupo", "GRUPO BALANCA"},
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
    }
}
