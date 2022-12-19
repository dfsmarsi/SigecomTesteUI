using System.Collections.Generic;
using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page
{
    public class EdicaoDeFornecedorFisicoSimplesPage: IEdicaoDeFornecedorPage
    {
        private readonly DriverService _driverService;
        private static Dictionary<string, string> DadosDoFornecedor => new Dictionary<string, string>
        {
            {"TipoPessoa", "FÍSICA"},
            {"Nacionalidade", "BRASILEIRO(A)"},
            {"Nome", "FORNECEDOR FISICO SIMPLES EDITAR TESTE"},
            {"Cidade", "JALES"},
            {"Estado", "SÃO PAULO"}
        };

        public EdicaoDeFornecedorFisicoSimplesPage(DriverService driverService) => _driverService = driverService;

        public void PesquisarFornecedorQueSeraEditado(EdicaoDeFornecedorBasePage edicaoDeColaboradorBasePage)
        {
            edicaoDeColaboradorBasePage.AbrirTelaDeCadastroDeFornecedor();
            edicaoDeColaboradorBasePage.ClicarNoAtalhoDePesquisar();
            edicaoDeColaboradorBasePage.RetornarPesquisaDePessoa(out var pesquisaDePessoaPage);
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("fornecedor", DadosDoFornecedor["Nome"]);
        }

        public void VerificarDadosDaPessoa()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoTipoPessoa), DadosDoFornecedor["TipoPessoa"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoNacionalidade), DadosDoFornecedor["Nacionalidade"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoNome), DadosDoFornecedor["Nome"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCidade), DadosDoFornecedor["Cidade"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoEstado), DadosDoFornecedor["Estado"]);
        }

        public void PreencherAsInformacoesDaPessoasNaEdicao()
        {
            _driverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoNome, EdicaoDeFornecedorFisicoSimplesModel.NomeDoColaboradorAlterado);
            _driverService.SelecionarItemComboBox(CadastroDeFornecedorModel.ElementoEstado, 1);
            _driverService.SelecionarItemComboBox(CadastroDeFornecedorModel.ElementoCidade, 1);
        }

        public void VerificarDadosDaPessoaEditados()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoNome), EdicaoDeFornecedorFisicoSimplesModel.NomeDoColaboradorAlterado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoEstado), EdicaoDeFornecedorFisicoSimplesModel.Estado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCidade), EdicaoDeFornecedorFisicoSimplesModel.Cidade);
        }

        public void FluxoDePesquisaDaPessoaEditado(EdicaoDeFornecedorBasePage edicaoDeFornecedorBasePage,
            PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            edicaoDeFornecedorBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("fornecedor", EdicaoDeFornecedorFisicoSimplesModel.NomeDoColaboradorAlterado);
        }
    }
}
