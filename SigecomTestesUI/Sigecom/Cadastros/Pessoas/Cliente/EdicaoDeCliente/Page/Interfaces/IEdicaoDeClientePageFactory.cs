using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Enum;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Interfaces
{
    public interface IEdicaoDeClientePageFactory
    {
        IEdicaoDeClientePage Fabricar(DriverService driverService, ClassificacaoDePessoa classificacaoDePessoa);
    }
}