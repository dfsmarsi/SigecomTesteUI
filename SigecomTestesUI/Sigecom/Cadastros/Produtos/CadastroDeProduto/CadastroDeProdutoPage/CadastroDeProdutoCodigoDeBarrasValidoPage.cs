using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage
{
    public class CadastroDeProdutoCodigoDeBarrasValidoPage: ICadastroDeProdutoPage
    {
        private readonly DriverService _driverService;

        public CadastroDeProdutoCodigoDeBarrasValidoPage(DriverService driver) =>
            _driverService = driver;

        public bool PreencherCamposDoProduto()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, CadastroDeProdutoCodigoDeBarrasValidoModel.NomeDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, CadastroDeProdutoBaseModel.UnidadeDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCusto, CadastroDeProdutoBaseModel.CustoDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMarkup, CadastroDeProdutoBaseModel.MarkupDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoReferencia, CadastroDeProdutoBaseModel.ReferenciaDoProduto);
                _driverService.DigitarNoCampoComTeclaDeAtalhoIdComThread(CadastroDeProdutoModel.ElementoCodigoDeBarrasProduto, CadastroDeProdutoCodigoDeBarrasValidoModel.CodigoDeBarras, Keys.Tab);
                Thread.Sleep(TimeSpan.FromSeconds(3));
                Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoOrigemMercadoria), CadastroDeProdutoCodigoDeBarrasValidoModel.OrigemMercadoria);
                Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoSituacaoTributaria), CadastroDeProdutoCodigoDeBarrasValidoModel.SituacaoTributaria);
                Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNaturezaCfop), CadastroDeProdutoCodigoDeBarrasValidoModel.NaturezaCfop);
                Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNcm), CadastroDeProdutoCodigoDeBarrasValidoModel.Ncm);
                Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCest), CadastroDeProdutoCodigoDeBarrasValidoModel.Cest);
                Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCstpis), CadastroDeProdutoCodigoDeBarrasValidoModel.Cstpis);
                Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCstCofins), CadastroDeProdutoCodigoDeBarrasValidoModel.CstCofins);
                Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoClassificacaoPisCofins), CadastroDeProdutoCodigoDeBarrasValidoModel.ClassificacaoPisCofins);
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
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(CadastroDeProdutoCodigoDeBarrasValidoModel.NomeFinalDoProduto);
            var possuiProduto = pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(CadastroDeProdutoCodigoDeBarrasValidoModel.NomeFinalDoProduto);
            Assert.True(possuiProduto);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
        }
    }
}
