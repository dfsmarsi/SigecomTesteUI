using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoPage.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using System;
using System.Threading;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoPage
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
                _driverService.DigitarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaCodigoDeBarrasDaGrade, CadastroDeProdutoGradeModel.CodigoDeBarras);
                _driverService.DigitarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaTamanhoDaGrade, CadastroDeProdutoGradeModel.TamanhoDaGrade);
                _driverService.DigitarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaCorDaGrade, CadastroDeProdutoGradeModel.CorDaGrade);
                _driverService.DigitarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaEstoqueDaGrade, CadastroDeProdutoGradeModel.EstoqueDaGrade);
                _driverService.DigitarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaCustoDaGrade, CadastroDeProdutoGradeModel.CustoDaGrade);
                _driverService.DigitarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaMarkupDaGrade, CadastroDeProdutoGradeModel.MarkupDaGrade);
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
