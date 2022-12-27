using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Enum;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page.Interface
{
    public interface IEdicaoDeProdutoPageFactory
    {
        IEdicaoDeProdutoPage Fabricar(DriverService driverService, TipoDeProduto tipoDeProduto);
    }
}
