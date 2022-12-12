using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page.Interface
{
    public interface IEdicaoDeProdutoPage
    {
        void PesquisarProdutoQueSeraEditado(EdicaoDeProdutoBasePage edicaoDeProdutoBasePage);
        void VerificarCamposDoProduto();
        bool PreencherCamposDoProdutoAoEditar();
        void VerificarCamposDeProdutoEditado();
        void VerificarCamposDaAba();
        void PreencherCamposDaAbaAoEditar();
        void VerificarCamposDaAbaEditado();
        void FluxoDePesquisaDoProdutoEditado(EdicaoDeProdutoBasePage edicaoDeProdutoBasePage,
            PesquisaDeProdutoPage pesquisaDeProdutoPage);
    }
}
