using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.ExceptionTabelaDePreco;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Model;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Page.Interfaces;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Page
{
    public class CadastroDeTabelaDePrecoTodosOsProdutosPage: ICadastroDeTabelaDePrecoPage
    {
        private readonly DriverService _driverService;

        public CadastroDeTabelaDePrecoTodosOsProdutosPage(DriverService driverService) => _driverService = driverService;

        public void PreencherCamposDaTabela()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeTabelaDePrecoModel.ElementoDescricao, CadastroDeTabelaDePrecoModel.NomeDescricaoTodosOsProdutos);
                _driverService.SelecionarItemComboBox(CadastroDeTabelaDePrecoModel.ElementoAtalho, 1);
                _driverService.ClicarNoToggleSwitchPeloId(CadastroDeTabelaDePrecoModel.ElementoToggleTodosOsProdutos);
                _driverService.SelecionarItemComboBox(CadastroDeTabelaDePrecoModel.ElementoRegra, 1);
                _driverService.DigitarNoCampoId(CadastroDeTabelaDePrecoModel.ElementoPorcentagem, CadastroDeTabelaDePrecoModel.ValorPorcentagem);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDeTabelaDePrecoException(exception.ToString());
            }
        }
    }
}
