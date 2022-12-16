using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page
{
    public class EdicaoDeColaboradorJuridicoSimplesPage: IEdicaoDeColaboradorPage
    {
        private readonly DriverService _driverService;
        private static Dictionary<string, string> DadosDoColaborador => new Dictionary<string, string>
        {
            {"TipoPessoa", "JURÍDICA"},
            {"Nacionalidade", "BRASILEIRO(A)"},
            {"Nome", "COLABORADOR JURIDICA SIMPLES EDITAR TESTE"},
            {"Cidade", "JALES"},
            {"Estado", "SÃO PAULO"}
        };

        public EdicaoDeColaboradorJuridicoSimplesPage(DriverService driverService) => _driverService = driverService;

        public void PesquisarColaboradorQueSeraEditado(EdicaoDeColaboradorBasePage edicaoDeColaboradorBasePage)
        {
            edicaoDeColaboradorBasePage.AbrirTelaDeCadastroDeColaborador();
            edicaoDeColaboradorBasePage.ClicarNoAtalhoDePesquisar();
            edicaoDeColaboradorBasePage.RetornarPesquisaDePessoa(out var pesquisaDePessoaPage);
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("colaborador", DadosDoColaborador["Nome"]);
        }

        public void VerificarDadosDaPessoa()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoTipoPessoa), DadosDoColaborador["TipoPessoa"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoNacionalidade), DadosDoColaborador["Nacionalidade"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoNome), DadosDoColaborador["Nome"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCidade), DadosDoColaborador["Cidade"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEstado), DadosDoColaborador["Estado"]);
        }

        public void PreencherAsInformacoesDaPessoasNaEdicao()
        {
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoNome, EdicaoDeColaboradorJuridicoSimplesModel.NomeDoColaboradorAlterado);
            _driverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoEstado, 1);
            _driverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoCidade, 1);
        }

        public void VerificarDadosDaPessoaEditados()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoNome), EdicaoDeColaboradorJuridicoSimplesModel.NomeDoColaboradorAlterado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEstado), EdicaoDeColaboradorJuridicoSimplesModel.Estado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCidade), EdicaoDeColaboradorJuridicoSimplesModel.Cidade);
        }

        public void FluxoDePesquisaDaPessoaEditado(EdicaoDeColaboradorBasePage edicaoDeColaboradorBasePage,
            PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            edicaoDeColaboradorBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("colaborador", EdicaoDeColaboradorJuridicoSimplesModel.NomeDoColaboradorAlterado);
        }
    }
}
