using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Enum;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.EditarTabelaDePreco.Page.Interfaces
{
    public interface IEdicaoDeTabelaDePrecoPageFactory
    {
        IEdicaoDeTabelaDePrecoPage Fabricar(DriverService driverService, QuantidadeDeProdutoParaTabelaDePreco quantidadeDeProdutoParaTabelaDePreco);
    }
}
