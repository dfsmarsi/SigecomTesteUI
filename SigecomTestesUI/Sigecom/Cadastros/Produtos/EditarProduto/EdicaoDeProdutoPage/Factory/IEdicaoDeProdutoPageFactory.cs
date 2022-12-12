using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.EdicaoDeProdutoPage.Interface;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.EdicaoDeProdutoPage.Factory
{
    public interface IEdicaoDeProdutoPageFactory
    {
        IEdicaoDeProdutoPage Fabricar(DriverService driverService, TipoDeProduto tipoDeProduto);
    }
}
