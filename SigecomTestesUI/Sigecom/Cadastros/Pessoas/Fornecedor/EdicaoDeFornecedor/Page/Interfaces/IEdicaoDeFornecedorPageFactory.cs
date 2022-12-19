using SigecomTestesUI.Services;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page.Interfaces
{
    public interface IEdicaoDeFornecedorPageFactory
    {
        IEdicaoDeFornecedorPage Fabricar(DriverService driverService, ClassificacaoDePessoa classificacaoDePessoa);
    }
}
