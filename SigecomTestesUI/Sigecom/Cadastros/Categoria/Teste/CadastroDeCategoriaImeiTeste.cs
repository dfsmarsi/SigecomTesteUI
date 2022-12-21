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
    public class CadastroDeCategoriaImeiTeste : BaseTestes
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

            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeCategoriaPage = beginLifetimeScope
                .Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeCategoriaPage>>();
            resolveCadastroDeCategoriaPage(DriverService, dadosDeCategoriaImei).RealizarFluxoDeCadastroDeCategoria(CadastroDeCategoriaModel.ElementoToggleImei);
        }
    }
}
