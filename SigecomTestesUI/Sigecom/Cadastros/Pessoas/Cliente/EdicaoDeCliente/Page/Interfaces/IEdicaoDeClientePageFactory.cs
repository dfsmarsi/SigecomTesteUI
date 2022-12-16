using SigecomTestesUI.Services;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Interfaces
{
    public interface IEdicaoDeClientePageFactory
    {
        IEdicaoDeClientePage Fabricar(DriverService driverService, ClassificacaoDePessoa classificacaoDePessoa);
    }
}