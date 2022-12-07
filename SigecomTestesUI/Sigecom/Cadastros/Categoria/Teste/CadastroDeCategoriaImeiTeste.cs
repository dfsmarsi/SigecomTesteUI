using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Model;

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
        public void CadastrarCategoriaMedicamentoSomenteCamposObrigatorios()
        {
            var dadosDeCategoriaMedicamento = new Dictionary<string, string>
            {
                {"Grupo", "GRUPO IMEI"},
                {"Markup", "0"}
            };

            // Arange
            RetornarCadastroDeCategoria(dadosDeCategoriaMedicamento, out var cadastroDeCategoriaPage);
            AbrirTelaDeCategoriaParaTeste(cadastroDeCategoriaPage);

            // Act
            cadastroDeCategoriaPage.PreencherCamposDaCategoria(CadastroDeCategoriaModel.ElementoToggleImei);
            cadastroDeCategoriaPage.Gravar();

            // Assert
            PesquisarCategoriaGravada(cadastroDeCategoriaPage, dadosDeCategoriaMedicamento);
        }
    }
}
