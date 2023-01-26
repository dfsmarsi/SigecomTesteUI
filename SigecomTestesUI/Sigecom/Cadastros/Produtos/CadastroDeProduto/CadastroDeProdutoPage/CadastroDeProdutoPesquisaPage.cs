using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage
{
    public class CadastroDeProdutoPesquisaPage : ICadastroDeProdutoPage
    {
        private readonly DriverService _driverService;

        public CadastroDeProdutoPesquisaPage(DriverService driver) =>
            _driverService = driver;

        public bool PreencherCamposDoProduto()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, PesquisaDeProdutoParaVendasTesteModel.NomeDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, PesquisaDeProdutoParaVendasTesteModel.UnidadeDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCodigoInterno, PesquisaDeProdutoParaVendasTesteModel.CodigoInternoDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCusto, PesquisaDeProdutoParaVendasTesteModel.CustoDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMarkup, PesquisaDeProdutoParaVendasTesteModel.MarkupDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoReferencia, PesquisaDeProdutoParaVendasTesteModel.ReferenciaDoProduto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDaAba()
        {
            return false;
            //Não utilizado;
        }

        public void FluxoDePesquisaDoProduto(CadastroDeProdutoBasePage cadastroDeProdutoBasePage,
            PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            cadastroDeProdutoBasePage.FecharJanelaCadastroDeProdutoComEsc();
            cadastroDeProdutoBasePage.ClicarNoAtalhoDePesquisarNaTelaPrincipal();
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(PesquisaDeProdutoParaVendasTesteModel.NomeFinalDoProduto);
            var possuiProduto = pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(PesquisaDeProdutoParaVendasTesteModel.NomeFinalDoProduto);
            Assert.True(possuiProduto);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
        }
    }
}
