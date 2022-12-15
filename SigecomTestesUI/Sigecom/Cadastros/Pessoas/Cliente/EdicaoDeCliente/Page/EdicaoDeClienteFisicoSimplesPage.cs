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
        private static Dictionary<string, string> _dadosDoCliente => new Dictionary<string, string>
        {
            {"TipoPessoa", "FÍSICA"},
            {"Nacionalidade", "BRASILEIRO(A)"},
            {"Nome", "CLIENTE FISICO SIMPLES EDITAR TESTE"},
            {"Cidade", "JALES"},
            {"Estado", "SÃO PAULO"}
        };

        public EdicaoDeClienteFisicoSimplesPage(DriverService driver) => _driverService = driver;

        public void PesquisarClienteQueSeraEditado(EdicaoDeClienteBasePage edicaoDeClienteBasePage)
        {
            edicaoDeClienteBasePage.AbrirTelaDeCadastroDeCliente();
            edicaoDeClienteBasePage.ClicarNoAtalhoDePesquisar();
            edicaoDeClienteBasePage.RetornarPesquisaDePessoa(out var pesquisaDePessoaPage);
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("cliente", _dadosDoCliente["Nome"]);
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
            _driverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoEstado, 1);
            _driverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoCidade, 1);
        }

        public void VerificarDadosDaPessoaEditados()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNome), EdicaoDeClienteFisicoModel.NomeDoClienteAlterado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEstado), EdicaoDeClienteFisicoModel.Estado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCidade), EdicaoDeClienteFisicoModel.Cidade);
        }

        public void FluxoDePesquisaDaPessoaEditado(EdicaoDeClienteBasePage edicaoDeClienteBasePage, PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            edicaoDeClienteBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("cliente", EdicaoDeClienteFisicoModel.NomeDoClienteAlterado);
        }
    }
}
