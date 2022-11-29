using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using System;
using System.Collections.Generic;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos
{
    public class CadastroDeProdutoPage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dadosDeProduto;
        public CadastroDeProdutoPage(DriverService driver, Dictionary<string, string> dadosDeProduto) : base(driver) => 
            _dadosDeProduto = dadosDeProduto;

        public bool ClicarNaOpcaoDoMenu() => 
            AcessarOpcaoMenu(CadastroDeProdutoModel.BotaoMenuCadastro);

        public bool ClicarNaOpcaoDoSubMenu() => 
            AcessarOpcaoSubMenu(CadastroDeProdutoModel.BotaoSubMenuProduto);

        public bool ClicarNaOpcaoDoPesquisar() =>
            AcessarOpcaoMenu(CadastroDeProdutoModel.BotaoPesquisar);

        public void ClicarNoAtalhoDePesquisar() =>
            DriverService.AbrirPesquisaDeProdutoComF9(CadastroDeProdutoModel.BotaoPesquisar);

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
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, _dadosDeProduto["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, _dadosDeProduto["Unidade"]);
                DriverService.DigitarNoCampoEnterId(CadastroDeProdutoModel.ElementoCategoria, _dadosDeProduto["Categoria"]);
                EsperarAcaoEmSegundos(2);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCusto, _dadosDeProduto["Custo"]);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMarkup, _dadosDeProduto["Markup"]);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoReferencia, _dadosDeProduto["Referencia"]);
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
            return precoDeVenda.Equals(double.Parse(_dadosDeProduto["PrecoVenda"]));
        }

        public bool AcessarAba(string aba)
        {
            try
            {
                DriverService.ClicarBotaoName(aba);
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
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNcm, _dadosDeProduto["NCM"]);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDaBalanca()
        {
            try
            {
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCodigoDeBarras, _dadosDeProduto["Balanca"]);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDeCombustivel()
        {
            try
            {
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoGasNaturalNacional, _dadosDeProduto["GasNacional"]);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoGasNaturalImportado, _dadosDeProduto["GasImportado"]);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoValorDePartida, _dadosDeProduto["ValorPartida"]);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoQuantidadeDeGasNatural, _dadosDeProduto["QtdeGasNatural"]);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDaGrade()
        {
            try
            {
                DriverService.DigitarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaCodigoDeBarrasDaGrade, _dadosDeProduto["Código de barras"]);
                DriverService.DigitarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaTamanhoDaGrade, _dadosDeProduto["Tamanho"]);
                DriverService.DigitarItensNaGrid(CadastroDeProdutoModel.ElementoGridColunaCorDaGrade, _dadosDeProduto["Cor"]);
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
