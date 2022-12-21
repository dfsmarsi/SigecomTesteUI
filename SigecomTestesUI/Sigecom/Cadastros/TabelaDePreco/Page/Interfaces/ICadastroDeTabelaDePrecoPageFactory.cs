using SigecomTestesUI.Services;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Page.Interfaces
{
    public interface ICadastroDeTabelaDePrecoPageFactory
    {
        ICadastroDeTabelaDePrecoPage Fabricar(DriverService driverService, QuantidadeDeProdutoParaTabelaDePreco quantidadeDeProdutoParaTabelaDePreco);
    }
}
