using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Model;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Model;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Enum;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Page
{
    public class EdicaoDeTabelaDePrecoBasePage: PageObjectModel
    {
        public EdicaoDeTabelaDePrecoBasePage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CadastroDeTabelaDePrecoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CadastroDeTabelaDePrecoModel.BotaoSubMenu);

        private void ClicarNoBotaoAlterar() =>
            ClicarBotao(CadastroDeTabelaDePrecoModel.ElementoBotaoAlterar);

        public void ClicarNoBotaoAplicar() =>
            ClicarBotao(CadastroDeTabelaDePrecoModel.ElementoAplicarRegra);

        public void AlterarATabelaDePreco(string nome)
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.CliqueNoElementoDaGridComVarios("Descrição", nome);
            ClicarNoBotaoAlterar();
        }

        public void VerificarCamposPreenchidos(QuantidadeDeProdutoParaTabelaDePreco quantidadeDeProdutoParaTabelaDePreco)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<IEdicaoDeTabelaDePrecoPageFactory>().Fabricar(DriverService, quantidadeDeProdutoParaTabelaDePreco).VerificarCamposPreenchidos();
        }

        public void PreencherCamposDaTabelaQueForamEditados(QuantidadeDeProdutoParaTabelaDePreco quantidadeDeProdutoParaTabelaDePreco)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<IEdicaoDeTabelaDePrecoPageFactory>().Fabricar(DriverService, quantidadeDeProdutoParaTabelaDePreco).PreencherCamposDaTabelaQueForamEditados();
        }

        public void VerificarCamposDaGridDeProdutos()
        {
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Markup na tabela(%)"), EdicaoDeTabelaDePrecoModel.MarkupNaTabela);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid("Valor na tabela"), EdicaoDeTabelaDePrecoModel.ValorNaTabela);
        }

        public void ClicarNoBotaoGravar() =>
            ClicarBotao(CadastroDeTabelaDePrecoModel.ElementoGravar);
    }
}
