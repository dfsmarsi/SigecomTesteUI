using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Teste.Interfaces
{
    public interface ICadastroDeProdutoBaseTeste
    {
        void RetornarCadastroDeProduto(Dictionary<string, string> dadosDeProduto,
            out CadastroDeProdutoPage cadastroDeProdutoPage);
        void AbrirTelaDeProdutoParaTeste(CadastroDeProdutoPage cadastroDeProdutoPage);
        void AtribuirDadosDoProdutoComImpostos(CadastroDeProdutoPage cadastroDeProdutoPage);
        void RealizarFluxoDePesquisaDoProduto(CadastroDeProdutoPage cadastroDeProdutoPage,
            Dictionary<string, string> dadosDeProduto);
    }
}
