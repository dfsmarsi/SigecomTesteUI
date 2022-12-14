using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage.Interfaces
{
    public interface ICadastroDeProdutoPage
    {
        bool PreencherCamposDoProduto();
        bool PreencherCamposDaAba();
        void FluxoDePesquisaDoProduto(CadastroDeProdutoBasePage cadastroDeProdutoBasePage, PesquisaDeProdutoPage pesquisaDeProdutoPage);
    }
}
