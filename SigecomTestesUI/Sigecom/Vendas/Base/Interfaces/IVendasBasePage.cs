namespace SigecomTestesUI.Sigecom.Vendas.Base.Interfaces
{
    public interface IVendasBasePage
    {
        string LancarProdutoPadraoNaVenda(string nomeDaTela);
        void LancarProdutosNaVenda(string nomeDaTela);
        void AbrirOAtalhoParaSelecionarCliente();
    }
}
