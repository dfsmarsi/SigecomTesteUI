using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Page;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Teste
{
    public class CadastroDeTabelaDePrecoComTodosOsProdutosTeste: BaseTestesComTelaAbertaNoFechar
    {
        [Test(Description = "Cadastro de tabela de preço com todos os produtos")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("TabelaDePreco")]
        public void CadastrarProdutoDeBalancaSomenteCamposObrigatorios()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeTabelaDePrecoBasePage = beginLifetimeScope.Resolve<Func<DriverService, CadastroDeTabelaDePrecoBasePage>>();
            var cadastroDeTabelaDePrecoBasePage = resolveCadastroDeTabelaDePrecoBasePage(DriverService);
            cadastroDeTabelaDePrecoBasePage.AdicionarUmaNovaTabelaDePreco();
            cadastroDeTabelaDePrecoBasePage.PreencherCamposDaTabela(QuantidadeDeProdutoParaTabelaDePreco.TodosOsProdutos);
            cadastroDeTabelaDePrecoBasePage.ClicarNoBotaoAplicar();
            cadastroDeTabelaDePrecoBasePage.ClicarNoBotaoGravar(); 
        }
    }
}
