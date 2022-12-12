namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Model
{
    public class CadastroDeProdutoModel
    {
        public static string BotaoMenuCadastro => "Cadastro";
        public static string BotaoSubMenuProduto => "Produtos";
        public static string ElementoTelaCadastroDeProduto => "Cadastro de produtos";
        public static string BotaoNovoCadastro => "F2 - Novo";
        public static string BotaoGravar => "F5 - Gravar";
        public static string BotaoPesquisar => "F9 - Pesquisar";

        public static string AbaProduto => "Produto";
        public static string ElementoNomeProduto => "txtProduto_Nome";
        public static string ElementoUnidade => "cbxProduto_Unidade";
        public static string ElementoCategoria => "txtCategoria";
        public static string ElementoCusto => "txtUltimaCompra";
        public static string ElementoMarkup => "txtMarkup";
        public static string ElementoPrecoVenda => "txtPrecoVenda";
        public static string ElementoReferencia => "txtReferencia";

        //Aba Impostos
        public static string AbaImpostos => "Impostos";
        public static string ElementoCodigoInterno => "txtCodigoProdutoInterno";
        public static string ElementoOrigemMercadoria => "cbxOrigem";
        public static string ElementoSituacaoTributaria => "cbxSituacaoTributaria";
        public static string ElementoNaturezaCfop => "cbxNaturezaCfop";
        public static string ElementoNcm => "txtNCM";

        //Aba Grade
        public static string AbaGrade => "Grade";
        public static string ElementoGridColunaCodigoDeBarrasDaGrade => "Código de barras";
        public static string ElementoGridColunaTamanhoDaGrade => "Tamanho";
        public static string ElementoGridColunaCorDaGrade => "Cor";

        public static string ElementoGridColunaEstoqueDaGrade => "Estoque";
        public static string ElementoGridColunaCustoDaGrade => "Custo";
        public static string ElementoGridColunaMarkupDaGrade => "Markup";
        public static string ElementoGridColunaVendaDaGrade => "Venda";

        //Aba Balança
        public static string AbaBalanca => "Balança";
        public static string ElementoCodigoDeBarrasBalanca => "txtCodigoProdBalanca";

        //Aba Combustível
        public static string AbaCombustivel => "Combustível";
        public static string ElementoGasNaturalNacional=> "txtGlpNacional";
        public static string ElementoGasNaturalImportado => "txtGlpImportado";
        public static string ElementoValorDePartida => "txtValorPartida";
        public static string ElementoQuantidadeDeGasNatural=> "txtQtdeGasNatural";
        public static string ElementoCodigoAnp => "txtCodigoANP";
        public static string ElementoCodif => "txtCODIF";


        public static string AbaMedicamento => "Medicamento";
        public static string ElementoRegistroNaAnvisa => "textEditRegistroAnvisa";
        public static string ElementoPrecoMaximoAoConsumidor => "textEditPrecoMaximoAoConsumidor";
        public static string ElementoMotivoDaIsecao => "memoEditMotivoDaIsencao";
        public static string ElementoNumeroDoLote => "textEditNumeroDoLote";
        public static string ElementoQuantidadeDeProdutoNoLote => "TextEditQuantidadeDeProdutoNoLote";
        public static string ElementoFabricacao => "dateEditFabricacao";
        public static string ElementoValidade => "dateEditValidade";
    }
}
