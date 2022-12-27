using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page.Interfaces;
using System;
using System.Threading;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page
{
    public class ClienteSimplificadoJuridicoComNomeECpfPage: IClienteSimplificadoPage
    {
        private readonly DriverService _driverService;

        public ClienteSimplificadoJuridicoComNomeECpfPage(DriverService driverService) => _driverService = driverService;

        public void PreencherCamposDoCliente()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeClienteSimplificadoModel.ElementoCampoDeCpfECnpj, CadastroDeClienteSimplificadoJuridicoModel.Cnpj);
                Thread.Sleep(TimeSpan.FromSeconds(1));
                _driverService.SelecionarItemComboBox(CadastroDeClienteSimplificadoModel.ElementoSelecaoDeCpfECnpj, 2);
                _driverService.DigitarNoCampoId(CadastroDeClienteSimplificadoModel.ElementoNomeDoCliente, CadastroDeClienteSimplificadoJuridicoModel.NomeTesteComCnpjDoCliente);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
