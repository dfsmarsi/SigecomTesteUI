using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page.Interface;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using System;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page
{
    public class EdicaoDeProdutoGradePage : IEdicaoDeProdutoPage
    {
        private readonly DriverService _driverService;

        public EdicaoDeProdutoGradePage(DriverService driver) =>
            _driverService = driver;

        public void PesquisarProdutoQueSeraEditado(EdicaoDeProdutoBasePage edicaoDeProdutoBasePage)
        {
            edicaoDeProdutoBasePage.AbrirTelaDeCadastroDoProduto();
            edicaoDeProdutoBasePage.ClicarNoAtalhoDePesquisar();
            edicaoDeProdutoBasePage.RetornarPesquisaDeProduto(out var pesquisaDeProdutoPage);
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(EdicaoDeProdutoGradeModel.NomeDoProdutoParaPesquisar);
        }

        public void VerificarCamposDoProduto()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCategoria), CadastroDeProdutoGradeModel.CategoriaDoProduto);
        }

        public bool PreencherCamposDoProdutoAoEditar()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, EdicaoDeProdutoGradeModel.NomeDoProdutoAlterado);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void VerificarCamposDeProdutoEditado()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNomeProduto), EdicaoDeProdutoGradeModel.NomeDoProdutoAlterado);
        }

        public void VerificarCamposDaAba()
        {
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid(CadastroDeProdutoModel.ElementoGridColunaCodigoDeBarrasDaGrade), CadastroDeProdutoGradeModel.CodigoDeBarras);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid(CadastroDeProdutoModel.ElementoGridColunaTamanhoDaGrade), CadastroDeProdutoGradeModel.TamanhoDaGrade);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid(CadastroDeProdutoModel.ElementoGridColunaCorDaGrade), CadastroDeProdutoGradeModel.CorDaGrade);

            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid(CadastroDeProdutoModel.ElementoGridColunaEstoqueDaGrade), CadastroDeProdutoGradeModel.EstoqueDaGrade);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid(CadastroDeProdutoModel.ElementoGridColunaCustoDaGrade), CadastroDeProdutoGradeModel.CustoDaGrade);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid(CadastroDeProdutoModel.ElementoGridColunaMarkupDaGrade), CadastroDeProdutoGradeModel.MarkupDaGrade);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid(CadastroDeProdutoModel.ElementoGridColunaVendaDaGrade), CadastroDeProdutoGradeModel.VendaDaGrade);
        }

        public void PreencherCamposDaAbaAoEditar()
        {
            try
            {
                _driverService.EditarItensNaGridComDuploClick(CadastroDeProdutoModel.ElementoGridColunaCodigoDeBarrasDaGrade, EdicaoDeProdutoGradeModel.CodigoDeBarras);
                _driverService.EditarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaTamanhoDaGrade, EdicaoDeProdutoGradeModel.TamanhoDaGrade);
                _driverService.EditarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaCorDaGrade, EdicaoDeProdutoGradeModel.CorDaGrade);
                _driverService.EditarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaCustoDaGrade, EdicaoDeProdutoGradeModel.CustoDaGrade);
                _driverService.EditarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaMarkupDaGrade, EdicaoDeProdutoGradeModel.MarkupDaGrade);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void VerificarCamposDaAbaEditado()
        {
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid(CadastroDeProdutoModel.ElementoGridColunaCodigoDeBarrasDaGrade), EdicaoDeProdutoGradeModel.CodigoDeBarras);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid(CadastroDeProdutoModel.ElementoGridColunaTamanhoDaGrade), EdicaoDeProdutoGradeModel.TamanhoDaGrade);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid(CadastroDeProdutoModel.ElementoGridColunaCorDaGrade), EdicaoDeProdutoGradeModel.CorDaGrade);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid(CadastroDeProdutoModel.ElementoGridColunaCustoDaGrade), EdicaoDeProdutoGradeModel.CustoDaGrade);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid(CadastroDeProdutoModel.ElementoGridColunaMarkupDaGrade), EdicaoDeProdutoGradeModel.MarkupDaGrade);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid(CadastroDeProdutoModel.ElementoGridColunaVendaDaGrade), EdicaoDeProdutoGradeModel.VendaDaGrade);
        }

        public void FluxoDePesquisaDoProdutoEditado(EdicaoDeProdutoBasePage edicaoDeProdutoBasePage,
            PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            edicaoDeProdutoBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(EdicaoDeProdutoGradeModel.NomeFinalDoProduto);
        }
    }
}
