using System;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Model;
using System.Collections.Generic;
using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste
{
    public class CadastroDeCategoriaBalancaTeste: BaseTestes
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
                {"Markup", "0"}
            };

            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeCategoriaPage = beginLifetimeScope
                .Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeCategoriaPage>>();
            resolveCadastroDeCategoriaPage(DriverService, dadosDeCategoriaBalanca).RealizarFluxoDeCadastroDeCategoria(CadastroDeCategoriaModel.ElementoToggleBalanca);
        }
    }
}
