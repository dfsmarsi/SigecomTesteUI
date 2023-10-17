using System;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Model;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.ExceptionTabelaDePreco;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Page
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
                _driverService.ClicarNoToggleSwitchPeloId(CadastroDeTabelaDePrecoModel.ElementoToggleTodosOsProdutos);
                _driverService.SelecionarItemComboBox(CadastroDeTabelaDePrecoModel.ElementoRegra, 2);
                _driverService.DigitarNoCampoId(CadastroDeTabelaDePrecoModel.ElementoPorcentagem, CadastroDeTabelaDePrecoModel.ValorPorcentagem);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDeTabelaDePrecoException(exception.ToString());
            }
        }
    }
}
