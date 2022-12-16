using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page.Interfaces
{
    public interface IEdicaoDeColaboradorPageFactory
    {
        IEdicaoDeColaboradorPage Fabricar(DriverService driverService, ClassificacaoDePessoa classificacaoDePessoa);
    }
}
