using SigecomTestesUI.Services;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page.Interface
{
    public interface IEdicaoDeProdutoPageFactory
    {
        IEdicaoDeProdutoPage Fabricar(DriverService driverService, TipoDeProduto tipoDeProduto);
    }
}
