using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.EdicaoDeProdutoPage.Interface
{
    public interface IEdicaoDeProdutoPage
    {
        void VerificarCamposDoProduto();
        bool PreencherCamposDoProdutoAoEditar();
        void VerificarCamposDeProdutoEditado();
        void PreencherCamposDaAbaAoEditar();
        void FluxoDePesquisaDoProdutoEditado(EdicaoDeProdutoBasePage edicaoDeProdutoBasePage,
            PesquisaDeProdutoPage pesquisaDeProdutoPage);
    }
}
