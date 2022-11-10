using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos
{
    public class CadastroDeProdutoPage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dadosProduto = new Dictionary<string, string>
        {
            {"Nome","PRODUTO"},
            {"Unidade", "UN"},
            {"CodigoInterno","int"},
            {"Categoria","PRODUTO"},
            {"Custo","5,00"},
            {"Markup","100,00"},
            {"PrecoVenda","10,00"},
            {"Referencia","ref"},
            {"NCM","22030000"}
        };

        public CadastroDeProdutoPage(DriverService driver) : base(driver)
        {
        }

        public bool ClicarNaOpcaoDoMenu() => 
            AcessarOpcaoMenu(CadastroDeProdutoModel.BotaoMenuCadastro);

        public bool ClicarNaOpcaoDoSubMenu() => 
            AcessarOpcaoSubMenu(CadastroDeProdutoModel.BotaoSubMenuProduto);

        public bool ClicarNoBotaoNovo()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeProdutoModel.BotaoNovoCadastro);
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
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, _dadosProduto["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, _dadosProduto["Unidade"]);
                DriverService.DigitarNoCampoEnterId(CadastroDeProdutoModel.ElementoCategoria, _dadosProduto["Categoria"]);
                EsperarAcaoEmSegundos(2);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCusto, _dadosProduto["Custo"]);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMarkup, _dadosProduto["Markup"]);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoReferencia, _dadosProduto["Referencia"]);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool VerificarSePrecoDeVendaFoiCalculado()
        {
            var precoDeVenda = double.Parse(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoPrecoVenda));
            return precoDeVenda.Equals(double.Parse(_dadosProduto["PrecoVenda"]));
        }

        public bool AcessarAbaImpostos()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeProdutoModel.AbaImpostos);
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
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoOrigemMercadoria, 1);
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoSituacaoTributaria, 1);
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoNaturezaCfop, 1);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNcm, _dadosProduto["NCM"]);
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
                DriverService.ClicarBotaoName(CadastroDeProdutoModel.BotaoGravar);
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
                DriverService.FecharJanelaComEsc(CadastroDeProdutoModel.ElementoTelaCadastroDeProduto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
