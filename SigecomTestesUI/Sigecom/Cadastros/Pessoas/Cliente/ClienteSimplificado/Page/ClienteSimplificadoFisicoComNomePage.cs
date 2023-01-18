using System;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page.Interfaces;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page
{
    public class ClienteSimplificadoFisicoComNomePage: IClienteSimplificadoPage
    {
        private readonly DriverService _driverService;

        public ClienteSimplificadoFisicoComNomePage(DriverService driverService) => _driverService = driverService;

        public void PreencherCamposDoCliente()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeClienteSimplificadoModel.ElementoNomeDoCliente, CadastroDeClienteSimplificadoFisicoModel.NomeTesteDoCliente);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
