using System;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Model;
using System.Collections.Generic;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Page;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste
{
    public class CadastroDeCategoriaCombustivelTeste: BaseTestes
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
                {"Markup", "0"}
            };

            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeCategoriaPage = beginLifetimeScope
                .Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeCategoriaPage>>();
            resolveCadastroDeCategoriaPage(DriverService, dadosDeCategoriaCombustivel).RealizarFluxoDeCadastroDeCategoria(CadastroDeCategoriaModel.ElementoToggleCombustivel);
        }
    }
}
