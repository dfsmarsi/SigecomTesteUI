using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using System;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Page
{
    public class CadastroDeProdutoBalancaPage: PageObjectModel, ICadastroDeProdutoPage
    {
        public CadastroDeProdutoBalancaPage(DriverService driver) : base(driver) { }

        public bool PreencherCamposDoProduto()
        {
            try
            {
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, CadastroDeProdutoBalancaModel.NomeDoProduto);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, CadastroDeProdutoBaseModel.UnidadeDoProduto);
                DriverService.DigitarNoCampoEnterId(CadastroDeProdutoModel.ElementoCategoria, CadastroDeProdutoBalancaModel.CategoriaDoProduto);
                EsperarAcaoEmSegundos(2);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCusto, CadastroDeProdutoBaseModel.CustoDoProduto);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMarkup, CadastroDeProdutoBaseModel.MarkupDoProduto);
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
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCodigoDeBarras, CadastroDeProdutoBalancaModel.CodigoDaBalanca);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void FluxoDePesquisaDoProduto(CadastroDeProdutoPage cadastroDeProdutoPage, PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            cadastroDeProdutoPage.ClicarNoAtalhoDePesquisar();
            pesquisaDeProdutoPage.PesquisarProduto(CadastroDeProdutoBalancaModel.NomeDoProduto);
            var possuiProduto = pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(CadastroDeProdutoBalancaModel.NomeFinalDoProduto);
            Assert.True(possuiProduto);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
            cadastroDeProdutoPage.FecharJanelaCadastroDeProdutoComEsc();
        }
        
    }
}
