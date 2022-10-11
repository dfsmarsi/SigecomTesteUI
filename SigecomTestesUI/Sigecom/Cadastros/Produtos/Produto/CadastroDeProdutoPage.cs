using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Produto
{
    public class CadastroDeProdutoPage : PageObjectModel
    {
        private const string _botaoMenuCadastro = "Cadastro";
        private const string _botaoSubMenuProduto = "Produtos";
        private const string _botaoNovoCadastro = "F2 - Novo";
        private const string _botaoGravar = "F5 - Gravar";
        private const string _abaImpostos = "Impostos";
        private const string _elementoNomeProduto = "txtProduto_Nome";
        private const string _elementoUnidade = "cbxProduto_Unidade";
        private const string _elementoCategoria = "txtCategoria";
        private const string _elementoCusto = "txtUltimaCompra";
        private const string _elementoMarkup = "txtMarkup";
        private const string _elementoPrecoVenda = "txtPrecoVenda";
        private const string _elementoReferencia = "txtReferencia";
        private const string _elementoCodigoInterno = "txtCodigoProdutoInterno";
        private const string _elementoOrigemMercadoria = "cbxOrigem";
        private const string _elementoSituacaoTributaria = "cbxSituacaoTributaria";
        private const string _elementoNaturezaCfop = "cbxNaturezaCfop";
        private const string _elementoNcm = "txtNCM";

        private Dictionary<string, string> _dadosProduto;

        public CadastroDeProdutoPage(DriverService driver, Dictionary<string, string> dadosProduto) : base(driver)
        {
            _dadosProduto = dadosProduto;
        }

        public bool ClicarNaOpcaoDoMenu()
        {
            var acessadoMenu = AcessarOpcaoMenu(_botaoMenuCadastro);
            return acessadoMenu;
        }

        public bool ClicarNaOpcaoDoSubMenu()
        {
            var acessadoSubMenu = AcessarOpcaoSubMenu(_botaoSubMenuProduto);
            return acessadoSubMenu;
        }

        public bool ClicarNoBotaoNovo()
        {
            try
            {
                DriverService.ClicarBotaoName(_botaoNovoCadastro);

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
                DriverService.DigitarNoCampoId(_elementoNomeProduto, _dadosProduto["Nome"]);
                DriverService.DigitarNoCampoId(_elementoUnidade, _dadosProduto["Unidade"]);
                DriverService.DigitarNoCampoEnterId(_elementoCategoria, _dadosProduto["Categoria"]);
                EsperarAcaoEmSegundos(2);
                DriverService.DigitarNoCampoId(_elementoCusto, _dadosProduto["Custo"]);
                DriverService.DigitarNoCampoId(_elementoMarkup, _dadosProduto["Markup"]);
                DriverService.DigitarNoCampoId(_elementoReferencia, _dadosProduto["Referencia"]);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool VerificarSePrecoDeVendaFoiCalculado()
        {
            var precoDeVenda = double.Parse(DriverService.ObterValorElementoId(_elementoPrecoVenda));

            return precoDeVenda == double.Parse(_dadosProduto["PrecoVenda"]);
        }

        public bool AcessarAbaImpostos()
        {
            try
            {
                DriverService.ClicarBotaoName(_abaImpostos);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDeImpostos()
        {
            try
            {
                DriverService.SelecionarItemComboBox(_elementoOrigemMercadoria, 1);
                DriverService.SelecionarItemComboBox(_elementoSituacaoTributaria, 1);
                DriverService.SelecionarItemComboBox(_elementoNaturezaCfop, 1);
                DriverService.DigitarNoCampoId(_elementoNcm, _dadosProduto["NCM"]);

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
                DriverService.ClicarBotaoName(_botaoGravar);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
