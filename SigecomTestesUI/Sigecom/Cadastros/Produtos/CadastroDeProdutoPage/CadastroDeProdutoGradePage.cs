using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoPage.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoPage
{
    public class CadastroDeProdutoGradePage : PageObjectModel, ICadastroDeProdutoPage
    {
        public CadastroDeProdutoGradePage(DriverService driver) : base(driver) { }

        public bool PreencherCamposDoProduto()
        {
            try
            {
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, CadastroDeProdutoGradeModel.NomeDoProduto);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, CadastroDeProdutoBaseModel.UnidadeDoProduto);
                DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeProdutoModel.ElementoCategoria, CadastroDeProdutoGradeModel.CategoriaDoProduto, Keys.Enter);
                EsperarAcaoEmSegundos(2);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoReferencia, CadastroDeProdutoBaseModel.ReferenciaDoProduto);
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
                DriverService.DigitarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaCodigoDeBarrasDaGrade, CadastroDeProdutoGradeModel.CodigoDeBarras);
                DriverService.DigitarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaTamanhoDaGrade, CadastroDeProdutoGradeModel.TamanhoDaGrade);
                DriverService.DigitarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaCorDaGrade, CadastroDeProdutoGradeModel.CorDaGrade);
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
