using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Model;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page.Interfaces
{
    public class ClienteSimplificadoFisicoComNomePage: IClienteSimplificadoPage
    {
        private readonly DriverService _driverService;

        public ClienteSimplificadoFisicoComNomePage(DriverService driverService) => _driverService = driverService;

        public void PreencherCamposDoCliente()
        {
            try
            {
                _driverService.DigitarNoCampoName(CadastroDeClienteSimplificadoModel.ElementoNomeDoCliente, CadastroDeClienteSimplificadoFisicoCompletoModel.NomeDoCliente);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
