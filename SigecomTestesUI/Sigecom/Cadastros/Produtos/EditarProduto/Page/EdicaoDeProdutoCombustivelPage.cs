using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page.Interface;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Model.CompararProduto;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page
{
    public class EdicaoDeProdutoCombustivelPage:IEdicaoDeProdutoPage
    {
        private readonly DriverService _driverService;

        public EdicaoDeProdutoCombustivelPage(DriverService driver) =>
            _driverService = driver;

        public void PesquisarProdutoQueSeraEditado(EdicaoDeProdutoBasePage edicaoDeProdutoBasePage)
        {
            edicaoDeProdutoBasePage.AbrirTelaDeCadastroDoProduto();
            edicaoDeProdutoBasePage.ClicarNoAtalhoDePesquisar();
            edicaoDeProdutoBasePage.RetornarPesquisaDeProduto(out var pesquisaDeProdutoPage);
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(OriginalCombustivelModel.NomeDoProdutoParaPesquisar);
        }

        public void VerificarCamposDoProduto()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCategoria), OriginalCombustivelModel.CategoriaDoProduto);
        }

        public bool PreencherCamposDoProdutoAoEditar()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, EdicaoDeProdutoCombustivelModel.NomeDoProdutoAlterado);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void VerificarCamposDeProdutoEditado()
        {
            //Não utilizado;
        }

        public void VerificarCamposDaAba()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoGasNaturalNacional), OriginalCombustivelModel.GasNacionalDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoGasNaturalImportado), OriginalCombustivelModel.GasImportadoDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoValorDePartida), OriginalCombustivelModel.ValorPartidaDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoQuantidadeDeGasNatural), OriginalCombustivelModel.QtdeGasNaturalDoProduto);
        }

        public void PreencherCamposDaAbaAoEditar()
        {
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCodigoAnp, EdicaoDeProdutoCombustivelModel.CodigoAnp);
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCodif, EdicaoDeProdutoCombustivelModel.Codif);
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoGasNaturalNacional, EdicaoDeProdutoCombustivelModel.GasNacionalDoProduto);
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoGasNaturalImportado, EdicaoDeProdutoCombustivelModel.GasImportadoDoProduto);
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoValorDePartida, EdicaoDeProdutoCombustivelModel.ValorPartidaDoProduto);
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoQuantidadeDeGasNatural, EdicaoDeProdutoCombustivelModel.QtdeGasNaturalDoProduto);
        }

        public void VerificarCamposDaAbaEditado()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCodigoAnp), EdicaoDeProdutoCombustivelModel.CodigoAnp);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCodif), EdicaoDeProdutoCombustivelModel.Codif);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoGasNaturalNacional), EdicaoDeProdutoCombustivelModel.GasNacionalDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoGasNaturalImportado), EdicaoDeProdutoCombustivelModel.GasImportadoDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoValorDePartida), EdicaoDeProdutoCombustivelModel.ValorPartidaDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoQuantidadeDeGasNatural), EdicaoDeProdutoCombustivelModel.QtdeGasNaturalDoProduto);
        }

        public void FluxoDePesquisaDoProdutoEditado(EdicaoDeProdutoBasePage edicaoDeProdutoBasePage,
            PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            edicaoDeProdutoBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(EdicaoDeProdutoCombustivelModel.NomeFinalDoProduto);
        }
    }
}
