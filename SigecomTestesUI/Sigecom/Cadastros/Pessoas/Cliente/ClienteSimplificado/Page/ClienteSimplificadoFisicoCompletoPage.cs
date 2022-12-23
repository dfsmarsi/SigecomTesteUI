using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page.Interfaces;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page
{
    public class ClienteSimplificadoFisicoCompletoPage:IClienteSimplificadoPage
    {
        private readonly DriverService _driverService;

        public ClienteSimplificadoFisicoCompletoPage(DriverService driverService) => _driverService = driverService;

        public void PreencherCamposDoCliente()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeClienteSimplificadoModel.ElementoCampoDeCpfECnpj, CadastroDeClienteSimplificadoFisicoCompletoModel.Cpf);
                _driverService.SelecionarItemComboBox(CadastroDeClienteSimplificadoModel.ElementoSelecaoDeCpfECnpj, 1);
                _driverService.DigitarNoCampoId(CadastroDeClienteSimplificadoModel.ElementoCelularDoCliente, CadastroDeClienteSimplificadoFisicoCompletoModel.CelularDoCliente);
                _driverService.DigitarNoCampoId(CadastroDeClienteSimplificadoModel.ElementoNomeDoCliente, CadastroDeClienteSimplificadoFisicoCompletoModel.NomeDoCliente);
                _driverService.DigitarNoCampoId(CadastroDeClienteSimplificadoModel.ElementoCepDoCliente, CadastroDeClienteSimplificadoFisicoCompletoModel.CepDoCliente);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
