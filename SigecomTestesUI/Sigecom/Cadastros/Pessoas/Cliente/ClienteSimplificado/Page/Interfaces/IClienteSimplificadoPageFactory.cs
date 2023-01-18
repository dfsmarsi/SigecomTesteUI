using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Enum;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page.Interfaces
{
    public interface IClienteSimplificadoPageFactory
    {
        IClienteSimplificadoPage Fabricar(DriverService driverService, TipoDeClienteSimplificado tipoDeClienteSimplificado);
    }
}
