using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Page.Interfaces;
using System;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Page
{
    public class CadastroDeProdutoCombustivelPage : PageObjectModel, ICadastroDeProdutoPage
    {
        public CadastroDeProdutoCombustivelPage(DriverService driver) : base(driver) { }

        public bool PreencherCamposDoProduto()
        {
            try
            {
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, CadastroDeProdutoCombustivelModel.NomeDoProduto);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, CadastroDeProdutoBaseModel.UnidadeDoProduto);
                DriverService.DigitarNoCampoEnterId(CadastroDeProdutoModel.ElementoCategoria, CadastroDeProdutoCombustivelModel.CategoriaDoProduto);
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
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoGasNaturalNacional, CadastroDeProdutoCombustivelModel.GasNacionalDoProduto);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoGasNaturalImportado, CadastroDeProdutoCombustivelModel.GasImportadoDoProduto);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoValorDePartida, CadastroDeProdutoCombustivelModel.ValorPartidaDoProduto);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoQuantidadeDeGasNatural, CadastroDeProdutoCombustivelModel.QtdeGasNaturalDoProduto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void FluxoDePesquisaDoProduto(CadastroDeProdutoPage cadastroDeProdutoPage, PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            cadastroDeProdutoPage.FecharJanelaCadastroDeProdutoComEsc();
            cadastroDeProdutoPage.ClicarNoAtalhoDePesquisarNaTelaPrincipal();
            pesquisaDeProdutoPage.PesquisarProduto(CadastroDeProdutoCombustivelModel.NomeDoProduto);
            var possuiProduto = pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(CadastroDeProdutoCombustivelModel.NomeFinalDoProduto);
            Assert.True(possuiProduto);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
        }
    }
}
