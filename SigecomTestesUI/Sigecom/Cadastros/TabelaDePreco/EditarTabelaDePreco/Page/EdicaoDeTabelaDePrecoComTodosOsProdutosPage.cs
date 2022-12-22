using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Model;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Model;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Page.Interfaces;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Page
{
    public class EdicaoDeTabelaDePrecoComTodosOsProdutosPage : IEdicaoDeTabelaDePrecoPage
    {
        private readonly DriverService _driverService;

        public EdicaoDeTabelaDePrecoComTodosOsProdutosPage(DriverService driverService) => _driverService = driverService;

        public void VerificarCamposPreenchidos()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeTabelaDePrecoModel.ElementoDescricao), CadastroDeTabelaDePrecoModel.NomeDescricaoTodosOsProdutos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeTabelaDePrecoModel.ElementoAtalho), CadastroDeTabelaDePrecoModel.AtalhoTodosOsProdutos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeTabelaDePrecoModel.ElementoRegra), CadastroDeTabelaDePrecoModel.Regra);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeTabelaDePrecoModel.ElementoPorcentagem), CadastroDeTabelaDePrecoModel.ValorPorcentagem);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid("Markup na tabela(%)"), CadastroDeTabelaDePrecoModel.MarkupNaTabela);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid("Valor na tabela"), CadastroDeTabelaDePrecoModel.ValorNaTabela);
        }

        public void PreencherCamposDaTabelaQueForamEditados()
        {
            _driverService.DigitarNoCampoId(CadastroDeTabelaDePrecoModel.ElementoDescricao, EdicaoDeTabelaDePrecoModel.NomeDescricaoTodosOsProdutos);
            _driverService.SelecionarItemComboBox(CadastroDeTabelaDePrecoModel.ElementoAtalho, 3);
            _driverService.SelecionarItemComboBox(CadastroDeTabelaDePrecoModel.ElementoRegra, 2);
            _driverService.DigitarNoCampoId(CadastroDeTabelaDePrecoModel.ElementoPorcentagem, EdicaoDeTabelaDePrecoModel.ValorPorcentagem);
            _driverService.DigitarNoCampoEnterName(CadastroDeTabelaDePrecoModel.ElementoPesquisaDeProduto, EdicaoDeTabelaDePrecoModel.NomeDoProdutoParaPesquisar, Keys.Enter);
        }

        public void VerificarCamposPreenchidosEditados()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeTabelaDePrecoModel.ElementoDescricao), EdicaoDeTabelaDePrecoModel.NomeDescricaoTodosOsProdutos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeTabelaDePrecoModel.ElementoAtalho), EdicaoDeTabelaDePrecoModel.AtalhoTodosOsProdutos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeTabelaDePrecoModel.ElementoRegra), EdicaoDeTabelaDePrecoModel.Regra);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeTabelaDePrecoModel.ElementoPorcentagem), EdicaoDeTabelaDePrecoModel.ValorPorcentagem);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid("Markup na tabela(%)"), EdicaoDeTabelaDePrecoModel.MarkupNaTabela);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid("Valor na tabela"), EdicaoDeTabelaDePrecoModel.ValorNaTabela);
        }
    }
}
