using System;
using OpenQA.Selenium;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Model;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.ExceptionTabelaDePreco;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Page
{
    public class CadastroDeTabelaDePrecoProdutoEspecificoPage: ICadastroDeTabelaDePrecoPage
    {
        private readonly DriverService _driverService;

        public CadastroDeTabelaDePrecoProdutoEspecificoPage(DriverService driverService) => _driverService = driverService;

        public void PreencherCamposDaTabela()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeTabelaDePrecoModel.ElementoDescricao, CadastroDeTabelaDePrecoModel.NomeDescricaoUnicoProduto);
                _driverService.SelecionarItemComboBox(CadastroDeTabelaDePrecoModel.ElementoAtalho, 2);
                _driverService.SelecionarItemComboBox(CadastroDeTabelaDePrecoModel.ElementoRegra, 2);
                _driverService.DigitarNoCampoId(CadastroDeTabelaDePrecoModel.ElementoPorcentagem, CadastroDeTabelaDePrecoModel.ValorPorcentagem);
                _driverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeTabelaDePrecoModel.ElementoPesquisaDeProduto, PesquisaDeProdutoInformacoesParaTesteModel.PesquisarItemId, Keys.Enter);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDeTabelaDePrecoException(exception.ToString());
            }
        }
    }
}
