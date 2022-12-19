using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System.Collections.Generic;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page
{
    public class EdicaoDeClienteJuridicoSimplesPage: IEdicaoDeClientePage
    {
        private readonly DriverService _driverService;
        private static Dictionary<string, string> DadosDoCliente => new Dictionary<string, string>
        {
            {"TipoPessoa", "JURÍDICA"},
            {"Nacionalidade", "BRASILEIRO(A)"},
            {"Nome", "CLIENTE JURIDICA SIMPLES EDITAR TESTE"},
            {"Cidade", "JALES"},
            {"Estado", "SÃO PAULO"}
        };

        public EdicaoDeClienteJuridicoSimplesPage(DriverService driverService) => _driverService = driverService;

        public void PesquisarClienteQueSeraEditado(EdicaoDeClienteBasePage edicaoDeClienteBasePage)
        {
            edicaoDeClienteBasePage.AbrirTelaDeCadastroDeCliente();
            edicaoDeClienteBasePage.ClicarNoAtalhoDePesquisar();
            edicaoDeClienteBasePage.RetornarPesquisaDePessoa(out var pesquisaDePessoaPage);
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("cliente", DadosDoCliente["Nome"]);
        }

        public void VerificarDadosDaPessoa()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoTipoPessoa), DadosDoCliente["TipoPessoa"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNacionalidade), DadosDoCliente["Nacionalidade"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNome), DadosDoCliente["Nome"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCidade), DadosDoCliente["Cidade"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEstado), DadosDoCliente["Estado"]);
        }


        public void PreencherAsInformacoesDaPessoasNaEdicao()
        {
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoNome, EdicaoDeClienteJuridicoSimplesModel.NomeDoClienteAlterado);
            _driverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoEstado, 1);
            _driverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoCidade, 1);
        }

        public void VerificarDadosDaPessoaEditados()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNome), EdicaoDeClienteJuridicoSimplesModel.NomeDoClienteAlterado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEstado), EdicaoDeClienteJuridicoSimplesModel.Estado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCidade), EdicaoDeClienteJuridicoSimplesModel.Cidade);
        }

        public void FluxoDePesquisaDaPessoaEditado(EdicaoDeClienteBasePage edicaoDeClienteBasePage, PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            edicaoDeClienteBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("cliente", EdicaoDeClienteJuridicoSimplesModel.NomeDoClienteAlterado);
        }
    }
}
