using SigecomTestesUI.Services;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Page.Interfaces
{
    public interface ICadastroDeProdutoFactory
    {
        ICadastroDeProdutoPage Fabricar(DriverService driverService, TipoDeProduto tipoDeProduto);
    }
}
