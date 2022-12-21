using System;
using OpenQA.Selenium;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.ExceptionTabelaDePreco;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Model;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Page.Interfaces;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Page
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
                _driverService.SelecionarItemComboBox(CadastroDeTabelaDePrecoModel.ElementoAtalho, 1);
                _driverService.SelecionarItemComboBox(CadastroDeTabelaDePrecoModel.ElementoRegra, 1);
                _driverService.DigitarNoCampoId(CadastroDeTabelaDePrecoModel.ElementoPorcentagem, CadastroDeTabelaDePrecoModel.ValorPorcentagem);
                _driverService.DigitarNoCampoEnterName(CadastroDeTabelaDePrecoModel.ElementoPesquisaDeProduto, CadastroDeTabelaDePrecoModel.NomeDoProdutoParaPesquisar, Keys.Enter);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDeTabelaDePrecoException(exception.ToString());
            }
        }
    }
}
