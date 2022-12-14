using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page.Interface;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page
{
    public class EdicaoDeProdutoMedicamentoPage : IEdicaoDeProdutoPage
    {
        private readonly DriverService _driverService;

        public EdicaoDeProdutoMedicamentoPage(DriverService driver) =>
            _driverService = driver;

        public void PesquisarProdutoQueSeraEditado(EdicaoDeProdutoBasePage edicaoDeProdutoBasePage)
        {
            edicaoDeProdutoBasePage.AbrirTelaDeCadastroDoProduto();
            edicaoDeProdutoBasePage.ClicarNoAtalhoDePesquisar();
            edicaoDeProdutoBasePage.RetornarPesquisaDeProduto(out var pesquisaDeProdutoPage);
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(EdicaoDeProdutoMedicamentoModel.NomeDoProdutoParaPesquisar);
        }

        public void VerificarCamposDoProduto()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCategoria), CadastroDeProdutoMedicamentoModel.CategoriaDoProduto);
        }

        public bool PreencherCamposDoProdutoAoEditar()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, EdicaoDeProdutoMedicamentoModel.NomeDoProdutoAlterado);
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
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoRegistroNaAnvisa), CadastroDeProdutoMedicamentoModel.RegistroNaAnvisa);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoPrecoMaximoAoConsumidor), CadastroDeProdutoMedicamentoModel.PrecoMaximoAoConsumidor);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoMotivoDaIsecao), CadastroDeProdutoMedicamentoModel.MotivoDaIsecao);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNumeroDoLote), CadastroDeProdutoMedicamentoModel.NumeroDoLote);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoQuantidadeDeProdutoNoLote), CadastroDeProdutoMedicamentoModel.QuantidadeDeProdutoNoLote);
        }

        public void PreencherCamposDaAbaAoEditar()
        {
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoRegistroNaAnvisa, EdicaoDeProdutoMedicamentoModel.RegistroNaAnvisa);
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoPrecoMaximoAoConsumidor, EdicaoDeProdutoMedicamentoModel.PrecoMaximoAoConsumidor); 
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMotivoDaIsecao, EdicaoDeProdutoMedicamentoModel.MotivoDaIsecao);
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNumeroDoLote, EdicaoDeProdutoMedicamentoModel.NumeroDoLote);
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoQuantidadeDeProdutoNoLote, EdicaoDeProdutoMedicamentoModel.QuantidadeDeProdutoNoLote);
        }

        public void VerificarCamposDaAbaEditado()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoRegistroNaAnvisa), EdicaoDeProdutoMedicamentoModel.RegistroNaAnvisa);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoPrecoMaximoAoConsumidor), EdicaoDeProdutoMedicamentoModel.PrecoMaximoAoConsumidor);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoMotivoDaIsecao), EdicaoDeProdutoMedicamentoModel.MotivoDaIsecao);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNumeroDoLote), EdicaoDeProdutoMedicamentoModel.NumeroDoLote);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoQuantidadeDeProdutoNoLote), EdicaoDeProdutoMedicamentoModel.QuantidadeDeProdutoNoLote);
        }

        public void FluxoDePesquisaDoProdutoEditado(EdicaoDeProdutoBasePage edicaoDeProdutoBasePage,
            PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            edicaoDeProdutoBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(EdicaoDeProdutoMedicamentoModel.NomeFinalDoProduto);
        }
    }
}
