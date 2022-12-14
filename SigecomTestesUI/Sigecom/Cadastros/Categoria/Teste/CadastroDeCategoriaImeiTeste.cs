using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Model;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste
{
    public class CadastroDeCategoriaImeiTeste : CadastroDeCategoriaBaseTeste
    {
        [Test(Description = "Cadastro de categoria de IMEI Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Categoria")]
        public void CadastrarCategoriaImeiSomenteCamposObrigatorios()
        {
            var dadosDeCategoriaImei = new Dictionary<string, string>
            {
                {"Grupo", "GRUPO IMEI"},
                {"Markup", "0"}
            };

            // Arange
            RetornarCadastroDeCategoria(dadosDeCategoriaImei, out var cadastroDeCategoriaPage);
            AbrirTelaDeCategoriaParaTeste(cadastroDeCategoriaPage);

            // Act
            cadastroDeCategoriaPage.PreencherCamposDaCategoria(CadastroDeCategoriaModel.ElementoToggleImei);
            cadastroDeCategoriaPage.Gravar();

            // Assert
            PesquisarCategoriaGravada(cadastroDeCategoriaPage, dadosDeCategoriaImei);
        }
    }
}
