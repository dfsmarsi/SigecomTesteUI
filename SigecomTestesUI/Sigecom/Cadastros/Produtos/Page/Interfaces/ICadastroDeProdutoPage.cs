using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Page.Interfaces
{
    public interface ICadastroDeProdutoPage
    {
        bool PreencherCamposDoProduto();
        bool PreencherCamposDaAba();
        void FluxoDePesquisaDoProduto(CadastroDeProdutoPage cadastroDeProdutoPage, PesquisaDeProdutoPage pesquisaDeProdutoPage);
    }
}
