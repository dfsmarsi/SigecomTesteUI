using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Enum;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.CadastroDeTabelaDePreco.Page.Interfaces
{
    public interface ICadastroDeTabelaDePrecoPageFactory
    {
        ICadastroDeTabelaDePrecoPage Fabricar(DriverService driverService, QuantidadeDeProdutoParaTabelaDePreco quantidadeDeProdutoParaTabelaDePreco);
    }
}
