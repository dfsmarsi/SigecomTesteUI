using SigecomTestesUI.Services;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoPage.Interfaces
{
    public interface ICadastroDeProdutoFactory
    {
        ICadastroDeProdutoPage Fabricar(DriverService driverService, TipoDeProduto tipoDeProduto);
    }
}
