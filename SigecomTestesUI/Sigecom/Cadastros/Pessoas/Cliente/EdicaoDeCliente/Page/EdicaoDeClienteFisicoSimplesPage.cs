using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.Model;
using System.Collections.Generic;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page
{
    public class EdicaoDeClienteFisicoSimplesPage : IEdicaoDeClienteFisicoPage
    {
        private readonly DriverService _driverService;
        private static Dictionary<string, string> _dadosDoCliente => new Dictionary<string, string>()
        {
            {"TipoPessoa", "FÍSICA"},
            {"Nacionalidade", "Brasileira"},
            {"Nome", "CLIENTE FISICO EDITAR TESTE"},
            {"Cidade", "JALES"},
            {"Estado", ""}
        };

        public EdicaoDeClienteFisicoSimplesPage(DriverService driver, Dictionary<string, string> dadosDoCliente)
        {
            _driverService = driver;
        }

        public void VerificarDadosDaPessoa()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoTipoPessoa), _dadosDoCliente["TipoPessoa"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNacionalidade), _dadosDoCliente["Nacionalidade"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNome), _dadosDoCliente["Nome"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCidade), _dadosDoCliente["Cidade"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEstado), _dadosDoCliente["Estado"]);
        }

        public void PreencherAsInformacoesDaPessoasNaEdicao()
        {
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoNome, EdicaoDeClienteFisicoModel.NomeDoClienteAlterado);
            _driverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoCidade, 1);
            _driverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoEstado, 1);
        }

        public void VerificarDadosDaPessoaEditados()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNome), EdicaoDeClienteFisicoModel.NomeDoClienteAlterado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCidade), EdicaoDeClienteFisicoModel.Cidade);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEstado), EdicaoDeClienteFisicoModel.Estado);
        }

        public void FluxoDePesquisaDaPessoaEditado(CadastroDeClienteFisicoPage cadastroDeClienteFisicoPage, PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            cadastroDeClienteFisicoPage.ClicarBotaoPesquisar();
            pesquisaDePessoaPage.PesquisarPessoa("cliente", EdicaoDeClienteFisicoModel.NomeDoClienteAlterado);
        }
    }
}
