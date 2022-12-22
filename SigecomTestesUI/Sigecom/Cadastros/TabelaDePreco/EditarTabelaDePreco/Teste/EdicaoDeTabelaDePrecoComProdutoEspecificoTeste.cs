using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Page;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Enum;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Teste
{
    public class EdicaoDeTabelaDePrecoComProdutoEspecificoTeste : BaseTestesComTelaAbertaNoFechar
    {
        [Test(Description = "Editar tabela de preço com produto específico")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("TabelaDePreco")]
        public void CadastrarTabelaDePrecoComProdutoEspecifico()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeTabelaDePrecoBasePage = beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeTabelaDePrecoBasePage>>();
            var cadastroDeTabelaDePrecoBasePage = resolveCadastroDeTabelaDePrecoBasePage(DriverService);
            cadastroDeTabelaDePrecoBasePage.AlterarATabelaDePreco();
            cadastroDeTabelaDePrecoBasePage.PreencherCamposDaTabelaQueForamEditados(QuantidadeDeProdutoParaTabelaDePreco.ProdutoEspecifico);
            cadastroDeTabelaDePrecoBasePage.ClicarNoBotaoAplicar();
            cadastroDeTabelaDePrecoBasePage.VerificarCamposDaGridDeProdutos();
            cadastroDeTabelaDePrecoBasePage.ClicarNoBotaoGravar();
        }
    }
}
