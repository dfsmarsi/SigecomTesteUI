using System.ComponentModel;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco
{
    public enum QuantidadeDeProdutoParaTabelaDePreco
    {
        [Description("Todos os produtos")] TodosOsProdutos = 0,
        [Description("Produto especifico")] ProdutoEspecifico = 1,
    }
}
