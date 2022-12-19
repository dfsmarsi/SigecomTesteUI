using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page
{
    public class EdicaoDeFornecedorJuridicoSimplesPage: IEdicaoDeFornecedorPage
    {
        private readonly DriverService _driverService;
        private static Dictionary<string, string> DadosDoFornecedor => new Dictionary<string, string>
        {
            {"TipoPessoa", "JURÍDICA"},
            {"Nacionalidade", "BRASILEIRO(A)"},
            {"Nome", "FORNECEDOR JURIDICA SIMPLES EDITAR TESTE"},
            {"Cidade", "JALES"},
            {"Estado", "SÃO PAULO"}
        };

        public EdicaoDeFornecedorJuridicoSimplesPage(DriverService driverService) => _driverService = driverService;

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
            _driverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoNome, EdicaoDeFornecedorJuridicoSimplesModel.NomeDoColaboradorAlterado);
            _driverService.SelecionarItemComboBox(CadastroDeFornecedorModel.ElementoEstado, 1);
            _driverService.SelecionarItemComboBox(CadastroDeFornecedorModel.ElementoCidade, 1);
        }

        public void VerificarDadosDaPessoaEditados()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoNome), EdicaoDeFornecedorJuridicoSimplesModel.NomeDoColaboradorAlterado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoEstado), EdicaoDeFornecedorJuridicoSimplesModel.Estado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCidade), EdicaoDeFornecedorJuridicoSimplesModel.Cidade);
        }

        public void FluxoDePesquisaDaPessoaEditado(EdicaoDeFornecedorBasePage edicaoDeFornecedorBasePage,
            PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            edicaoDeFornecedorBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("fornecedor", EdicaoDeFornecedorJuridicoSimplesModel.NomeDoColaboradorAlterado);
        }
    }
}
