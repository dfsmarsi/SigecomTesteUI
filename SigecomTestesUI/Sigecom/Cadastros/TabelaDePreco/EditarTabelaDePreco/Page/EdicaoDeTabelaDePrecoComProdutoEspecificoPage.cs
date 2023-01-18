using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Model;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Model;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Page.Interfaces;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Page
{
    public class EdicaoDeTabelaDePrecoComProdutoEspecificoPage: IEdicaoDeTabelaDePrecoPage
    {
        private readonly DriverService _driverService;

        public EdicaoDeTabelaDePrecoComProdutoEspecificoPage(DriverService driverService) => _driverService = driverService;

        public void VerificarCamposPreenchidos()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeTabelaDePrecoModel.ElementoDescricao), TabelaDeProdutoComInformacoesAnteriorModel.NomeDescricaoUnicoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeTabelaDePrecoModel.ElementoRegra), TabelaDeProdutoComInformacoesAnteriorModel.Regra);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeTabelaDePrecoModel.ElementoPorcentagem), TabelaDeProdutoComInformacoesAnteriorModel.ValorPorcentagem);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid("Markup na tabela(%)"), TabelaDeProdutoComInformacoesAnteriorModel.MarkupNaTabela);
            Assert.AreEqual(_driverService.PegarValorDaColunaDaGrid("Valor na tabela"), TabelaDeProdutoComInformacoesAnteriorModel.ValorNaTabela);
        }

        public void PreencherCamposDaTabelaQueForamEditados()
        {
            _driverService.DigitarNoCampoId(CadastroDeTabelaDePrecoModel.ElementoDescricao, EdicaoDeTabelaDePrecoModel.NomeDescricaoUnicoProduto);
            _driverService.SelecionarItemComboBox(CadastroDeTabelaDePrecoModel.ElementoAtalho, 4);
            _driverService.SelecionarItemComboBox(CadastroDeTabelaDePrecoModel.ElementoRegra, 1);
            _driverService.DigitarNoCampoId(CadastroDeTabelaDePrecoModel.ElementoPorcentagem, EdicaoDeTabelaDePrecoModel.ValorPorcentagem);
        }
    }
}
