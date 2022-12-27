using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Page;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Enum;
using System;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Teste
{
    public class EdicaoDeTabelaDePrecoComTodosOsProdutosTeste : BaseTestesComTelaAbertaNoFechar
    {
        [Test(Description = "Editar tabela de preço com todos os produtos")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("TabelaDePreco")]
        public void EditarTabelaDePrecoComTodosOsProdutos()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeTabelaDePrecoBasePage = beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeTabelaDePrecoBasePage>>();
            var cadastroDeTabelaDePrecoBasePage = resolveCadastroDeTabelaDePrecoBasePage(DriverService);
            cadastroDeTabelaDePrecoBasePage.AlterarATabelaDePreco(TabelaDeProdutoComInformacoesAnteriorModel.NomeDescricaoTodosOsProdutos);
            cadastroDeTabelaDePrecoBasePage.PreencherCamposDaTabelaQueForamEditados(QuantidadeDeProdutoParaTabelaDePreco.TodosOsProdutos);
            cadastroDeTabelaDePrecoBasePage.ClicarNoBotaoAplicar();
            cadastroDeTabelaDePrecoBasePage.ClicarNoBotaoGravar();
        }
    }
}
