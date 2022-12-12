using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.EdicaoDeProdutoPage.Interface;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.EdicaoDeProdutoPage
{
    public class EdicaoDeProdutoSimplesPage: IEdicaoDeProdutoPage
    {
        private readonly DriverService _driverService;

        public EdicaoDeProdutoSimplesPage(DriverService driver) =>
            _driverService = driver;

        public void VerificarCamposDoProduto()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNomeProduto), CadastroDeProdutoSimplesModel.NomeDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoUnidade), CadastroDeProdutoBaseModel.UnidadeDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCategoria), CadastroDeProdutoSimplesModel.CategoriaDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCusto), CadastroDeProdutoBaseModel.CustoDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoMarkup), CadastroDeProdutoBaseModel.MarkupDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoPrecoVenda), CadastroDeProdutoBaseModel.PrecoVendaDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoReferencia), CadastroDeProdutoBaseModel.ReferenciaDoProduto);
        }

        public bool PreencherCamposDoProdutoAoEditar()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, EditarProdutoNovoSimplesModel.NomeDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, EditarProdutoNovoSimplesModel.UnidadeDoProduto);
                _driverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeProdutoModel.ElementoCategoria, EditarProdutoNovoSimplesModel.CategoriaDoProduto, Keys.Enter);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCusto, EditarProdutoNovoSimplesModel.CustoDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMarkup, EditarProdutoNovoSimplesModel.MarkupDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoReferencia, EditarProdutoNovoSimplesModel.ReferenciaDoProduto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void VerificarCamposDeProdutoEditado()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNomeProduto), EditarProdutoNovoSimplesModel.NomeDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoUnidade), EditarProdutoNovoSimplesModel.UnidadeDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCategoria), EditarProdutoNovoSimplesModel.CategoriaDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCusto), EditarProdutoNovoSimplesModel.CustoDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoMarkup), EditarProdutoNovoSimplesModel.MarkupDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoPrecoVenda), EditarProdutoNovoSimplesModel.PrecoVendaDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoReferencia), EditarProdutoNovoSimplesModel.ReferenciaDoProduto);
        }

        public void PreencherCamposDaAbaAoEditar()
        {
            //Não utilizado;
        }

        public void FluxoDePesquisaDoProdutoEditado(EdicaoDeProdutoBasePage edicaoDeProdutoBasePage,
            PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            edicaoDeProdutoBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(EditarProdutoNovoSimplesModel.NomeFinalDoProduto);
        }
    }
}
