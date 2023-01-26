using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage
{
    public class CadastroDeProdutoGradePage : ICadastroDeProdutoPage
    {
        private readonly DriverService _driverService;

        public CadastroDeProdutoGradePage(DriverService driver) => _driverService = driver;

        public bool PreencherCamposDoProduto()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, CadastroDeProdutoGradeModel.NomeDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, CadastroDeProdutoBaseModel.UnidadeDoProduto);
                _driverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeProdutoModel.ElementoCategoria, CadastroDeProdutoGradeModel.CategoriaDoProduto, Keys.Enter);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoReferencia, CadastroDeProdutoBaseModel.ReferenciaDoProduto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDaAba()
        {
            try
            {
                _driverService.DigitarNovosItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaCodigoDeBarrasDaGrade, CadastroDeProdutoGradeModel.CodigoDeBarras);
                _driverService.DigitarNovosItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaTamanhoDaGrade, CadastroDeProdutoGradeModel.TamanhoDaGrade);
                _driverService.DigitarNovosItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaCorDaGrade, CadastroDeProdutoGradeModel.CorDaGrade);
                _driverService.DigitarNovosItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaEstoqueDaGrade, CadastroDeProdutoGradeModel.EstoqueDaGrade);
                _driverService.DigitarNovosItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaCustoDaGrade, CadastroDeProdutoGradeModel.CustoDaGrade);
                _driverService.DigitarNovosItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaMarkupDaGrade, CadastroDeProdutoGradeModel.MarkupDaGrade);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void FluxoDePesquisaDoProduto(CadastroDeProdutoBasePage cadastroDeProdutoBasePage, PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            cadastroDeProdutoBasePage.FecharJanelaCadastroDeProdutoComEsc();
            cadastroDeProdutoBasePage.ClicarNoAtalhoDePesquisarNaTelaPrincipal();
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(CadastroDeProdutoGradeModel.NomeFinalDoProduto);
            var possuiProduto = pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(CadastroDeProdutoGradeModel.NomeFinalDoProduto);
            Assert.True(possuiProduto);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
        }
    }
}
