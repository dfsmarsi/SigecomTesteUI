using OpenQA.Selenium;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page.Interfaces;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

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
                _driverService.DigitarNoCampoId(CadastroDeClienteSimplificadoModel.ElementoNomeDoCliente, CadastroDeClienteSimplificadoFisicoCompletoModel.NomeDoCliente);
                _driverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeClienteSimplificadoModel.ElementoCepDoCliente, CadastroDeClienteSimplificadoFisicoCompletoModel.CepDoCliente, Keys.Tab);
                _driverService.DigitarNoCampoId(CadastroDeClienteSimplificadoModel.ElementoCelularDoCliente, CadastroDeClienteSimplificadoFisicoCompletoModel.CelularDoCliente);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
