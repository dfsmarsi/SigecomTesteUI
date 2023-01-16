using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Model;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Page;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Enum;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Teste
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
        public void CadastrarTabelaDePrecoComTodosOsProdutos()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeTabelaDePrecoBasePage = beginLifetimeScope.Resolve<Func<DriverService, CadastroDeTabelaDePrecoBasePage>>();
            var cadastroDeTabelaDePrecoBasePage = resolveCadastroDeTabelaDePrecoBasePage(DriverService);
            cadastroDeTabelaDePrecoBasePage.AdicionarUmaNovaTabelaDePreco();
            cadastroDeTabelaDePrecoBasePage.PreencherCamposDaTabela(QuantidadeDeProdutoParaTabelaDePreco.TodosOsProdutos);
            cadastroDeTabelaDePrecoBasePage.ClicarNoBotaoAplicar();
            cadastroDeTabelaDePrecoBasePage.ClicarNoBotaoGravar();
            cadastroDeTabelaDePrecoBasePage.VoltarTelaDeCadastro();
            cadastroDeTabelaDePrecoBasePage.VerificarSeFoiCadastradoCorretamente(CadastroDeTabelaDePrecoModel.NomeDescricaoTodosOsProdutos);
        }
    }
}
