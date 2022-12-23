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
                _driverService.DigitarNoCampoName(CadastroDeClienteSimplificadoModel.ElementoCampoDeCpfECnpj, CadastroDeClienteSimplificadoFisicoCompletoModel.Cpf);
                _driverService.SelecionarItemComboBox(CadastroDeClienteSimplificadoModel.ElementoSelecaoDeCpfECnpj, 1);
                _driverService.DigitarNoCampoName(CadastroDeClienteSimplificadoModel.ElementoCelularDoCliente, CadastroDeClienteSimplificadoFisicoCompletoModel.CelularDoCliente);
                _driverService.DigitarNoCampoName(CadastroDeClienteSimplificadoModel.ElementoNomeDoCliente, CadastroDeClienteSimplificadoFisicoCompletoModel.NomeDoCliente);
                _driverService.DigitarNoCampoName(CadastroDeClienteSimplificadoModel.ElementoCepDoCliente, CadastroDeClienteSimplificadoFisicoCompletoModel.CepDoCliente);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
