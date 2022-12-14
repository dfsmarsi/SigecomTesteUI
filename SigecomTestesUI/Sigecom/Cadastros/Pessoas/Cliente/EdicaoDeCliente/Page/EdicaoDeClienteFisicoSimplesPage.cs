using System.Collections.Generic;
using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page
{
    public class EdicaoDeClienteFisicoSimplesPage : IEdicaoDeClienteFisicoPage
    {
        private readonly DriverService _driverService;
        private readonly Dictionary<string, string> _dadosDoCliente;

        public EdicaoDeClienteFisicoSimplesPage(DriverService driver, Dictionary<string, string> dadosDoCliente)
        {
            _driverService = driver;
            _dadosDoCliente = dadosDoCliente;
        }

        public void VerificarDadosDaPessoa()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoTipoPessoa), _dadosDoCliente["TipoPessoa"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoTipoPessoa), _dadosDoCliente["Nacionalidade"]);
        }

        public void PreencherAsInformacoesDaPessoasNaEdicao()
        {

        }

        public void VerificarDadosDaPessoaEditados()
        {

        }
    }
}
