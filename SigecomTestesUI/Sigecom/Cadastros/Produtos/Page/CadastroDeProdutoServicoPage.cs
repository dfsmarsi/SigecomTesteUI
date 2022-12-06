using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using System;
using System.Threading;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Page
{
    public class CadastroDeProdutoServicoPage: ICadastroDeProdutoPage
    {
        private readonly DriverService _driverService;

        public CadastroDeProdutoServicoPage(DriverService driver) =>
            _driverService = driver;

        public bool PreencherCamposDoProduto()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, CadastroDeProdutoServicoModel.NomeDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, CadastroDeProdutoBaseModel.UnidadeDoProduto);
                _driverService.DigitarNoCampoEnterId(CadastroDeProdutoModel.ElementoCategoria, CadastroDeProdutoServicoModel.CategoriaDoProduto);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCusto, CadastroDeProdutoBaseModel.CustoDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMarkup, CadastroDeProdutoBaseModel.MarkupDoProduto);
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
            return false;
            //Não utilizado;
        }

        public void FluxoDePesquisaDoProduto(CadastroDeProdutoPage cadastroDeProdutoPage, PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            cadastroDeProdutoPage.FecharJanelaCadastroDeProdutoComEsc();
            cadastroDeProdutoPage.ClicarNoAtalhoDePesquisarNaTelaPrincipal();
            pesquisaDeProdutoPage.PesquisarProduto(CadastroDeProdutoServicoModel.NomeDoProduto);
            var possuiProduto = pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(CadastroDeProdutoServicoModel.NomeFinalDoProduto);
            Assert.True(possuiProduto);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
        }
    }
}
