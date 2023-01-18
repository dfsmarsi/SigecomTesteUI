using System;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page.Interfaces;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page
{
    public class ClienteSimplificadoJuridicoComNomePage: IClienteSimplificadoPage
    {
        private readonly DriverService _driverService;

        public ClienteSimplificadoJuridicoComNomePage(DriverService driverService) => _driverService = driverService;
        public void PreencherCamposDoCliente()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeClienteSimplificadoModel.ElementoNomeDoCliente, CadastroDeClienteSimplificadoJuridicoModel.NomeTesteDoCliente);
                _driverService.SelecionarItemComboBox(CadastroDeClienteSimplificadoModel.ElementoSelecaoDeCpfECnpj, 2);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
