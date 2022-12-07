using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using System;
using System.Threading;
using OpenQA.Selenium;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Page
{
    public class CadastroDeProdutoMedicamentoPage : ICadastroDeProdutoPage
    {
        private readonly DriverService _driverService;

        public CadastroDeProdutoMedicamentoPage(DriverService driver) =>
            _driverService = driver;

        public bool PreencherCamposDoProduto()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, CadastroDeProdutoMedicamentoModel.NomeDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, CadastroDeProdutoBaseModel.UnidadeDoProduto);
                _driverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeProdutoModel.ElementoCategoria, CadastroDeProdutoMedicamentoModel.CategoriaDoProduto, Keys.Enter);
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
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoRegistroNaAnvisa, CadastroDeProdutoMedicamentoModel.RegistroNaAnvisa);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoPrecoMaximoAoConsumidor, CadastroDeProdutoMedicamentoModel.PrecoMaximoAoConsumidor);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMotivoDaIsecao, CadastroDeProdutoMedicamentoModel.MotivoDaIsecao);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNumeroDoLote, CadastroDeProdutoMedicamentoModel.NumeroDoLote);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoQuantidadeDeProdutoNoLote, CadastroDeProdutoMedicamentoModel.QuantidadeDeProdutoNoLote);
                _driverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoFabricacao, 1);
                _driverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoValidade, 1);
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
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(CadastroDeProdutoMedicamentoModel.NomeDoProduto);
            var possuiProduto = pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(CadastroDeProdutoMedicamentoModel.NomeFinalDoProduto);
            Assert.True(possuiProduto);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
        }
    }
}
