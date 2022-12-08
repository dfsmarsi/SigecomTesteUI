using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoPage.Interfaces
{
    public interface ICadastroDeProdutoPage
    {
        bool PreencherCamposDoProduto();
        void VerificarCamposDoProduto();
        bool PreencherCamposDoProdutoAoEditar();
        void VerificarCamposDeProdutoEditado();
        bool PreencherCamposDaAba();
        void PreencherCamposDaAbaAoEditar();
        void FluxoDePesquisaDoProduto(CadastroDeProdutoBasePage cadastroDeProdutoBasePage, PesquisaDeProdutoPage pesquisaDeProdutoPage);
        void FluxoDePesquisaDoProdutoEditado(CadastroDeProdutoBasePage cadastroDeProdutoBasePage,
            PesquisaDeProdutoPage pesquisaDeProdutoPage);
    }
}
