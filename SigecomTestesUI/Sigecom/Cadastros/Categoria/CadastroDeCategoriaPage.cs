using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Model;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria
{
    public class CadastroDeCategoriaPage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dadosDeCategoria;
        public CadastroDeCategoriaPage(DriverService driver, Dictionary<string, string> dadosDeCategoria) : base(driver) => 
            _dadosDeCategoria = dadosDeCategoria;

        public bool ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CadastroDeCategoriaModel.BotaoMenuCadastro);

        public bool ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CadastroDeCategoriaModel.BotaoSubMenuCategoria);

        public bool ClicarNaOpcaoDoPesquisar() =>
            AcessarOpcaoMenu(CadastroDeCategoriaModel.BotaoPesquisar);

        public bool ClicarNoBotaoNovoCategoria()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeCategoriaModel.BotaoNovoCategoria);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ClicarNoBotaoNovo()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeCategoriaModel.BotaoNovo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDoProduto()
        {
            try
            {
                DriverService.DigitarNoCampoId(CadastroDeCategoriaModel.ElementoNomeGrupo, _dadosDeCategoria["Grupo"]);
                DriverService.DigitarNoCampoId(CadastroDeCategoriaModel.ElementoMarkup, _dadosDeCategoria["Markup"]);
                DriverService.SelecionarItemComboBox(CadastroDeCategoriaModel.ElementoTipoGrupo, 1);
                DriverService.SelecionarItemDaGrid(CadastroDeCategoriaModel.ElementoGrid, 1);
                EsperarAcaoEmSegundos(2);
                DriverService.SelecionarItemDaGrid(CadastroDeCategoriaModel.ElementoGrid, 2);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Gravar()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeCategoriaModel.BotaoGravar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool FecharJanelaCadastroDeProdutoComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeCategoriaModel.ElementoTelaCadastroDeCategoria);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
