using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Page;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Enum;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Teste
{
    public class CadastroDeTabelaDePrecoComProdutoEspecifico:BaseTestesComTelaAbertaNoFechar
    {
        [Test(Description = "Cadastro de tabela de preço com produto específico")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("TabelaDePreco")]
        public void CadastrarTabelaDePrecoComProdutoEspecifico()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeTabelaDePrecoBasePage = beginLifetimeScope.Resolve<Func<DriverService, CadastroDeTabelaDePrecoBasePage>>();
            var cadastroDeTabelaDePrecoBasePage = resolveCadastroDeTabelaDePrecoBasePage(DriverService);
            cadastroDeTabelaDePrecoBasePage.AdicionarUmaNovaTabelaDePreco();
            cadastroDeTabelaDePrecoBasePage.PreencherCamposDaTabela(QuantidadeDeProdutoParaTabelaDePreco.ProdutoEspecifico);
            cadastroDeTabelaDePrecoBasePage.ClicarNoBotaoAplicar();
            cadastroDeTabelaDePrecoBasePage.VerificarCamposDaGridDeProdutos();
            cadastroDeTabelaDePrecoBasePage.ClicarNoBotaoGravar();
        }
    }
}
