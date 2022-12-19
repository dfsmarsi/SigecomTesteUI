using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page
{
    public class EdicaoDeFornecedorFisicoCompletoPage: IEdicaoDeFornecedorPage
    {
        private readonly DriverService _driverService;

        private static Dictionary<string, string> DadosDoFornecedor => new Dictionary<string, string>
        {
            {"TipoPessoa", "FÍSICA"},
            {"Nacionalidade", "BRASILEIRO(A)"},
            {"Nome", "FORNECEDOR FISICA COMPLETO EDITAR TESTE"},
            {"Cpf", "860.920.330-11"},
            {"Rg", "204917633"},
            {"Apelido", "COMPLETO EDITAR TESTE"},
            {"Sexo", "Masculino"},
            {"DataNascimento", "terça-feira, 4 de janeiro de 1684"},
            {"EstadoCivil", "Solteiro(a)"},
            {"Cep", "15700-008"},
            {"Endereco", "RUA 3"},
            {"Numero", "1234"},
            {"Bairro", "CENTRO"},
            {"Estado", "SÃO PAULO"},
            {"Cidade", "JALES"},
            {"Complemento", "CASA"},
            {"Observacao", "OBSERVAÇÃO TESTE"}
        };

        public EdicaoDeFornecedorFisicoCompletoPage(DriverService driverService) => _driverService = driverService;

        public void PesquisarFornecedorQueSeraEditado(EdicaoDeFornecedorBasePage edicaoDeFornecedorBasePage)
        {
            edicaoDeFornecedorBasePage.AbrirTelaDeCadastroDeFornecedor();
            edicaoDeFornecedorBasePage.ClicarNoAtalhoDePesquisar();
            edicaoDeFornecedorBasePage.RetornarPesquisaDePessoa(out var pesquisaDePessoaPage);
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("fornecedor", DadosDoFornecedor["Nome"]);
        }

        public void VerificarDadosDaPessoa()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoTipoPessoa), DadosDoFornecedor["TipoPessoa"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoNacionalidade), DadosDoFornecedor["Nacionalidade"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoNome), DadosDoFornecedor["Nome"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCpf), DadosDoFornecedor["Cpf"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoRg), DadosDoFornecedor["Rg"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoApelido), DadosDoFornecedor["Apelido"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoSexo), DadosDoFornecedor["Sexo"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoDataDeNascimento), DadosDoFornecedor["DataNascimento"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoEstadoCivil), DadosDoFornecedor["EstadoCivil"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCep), DadosDoFornecedor["Cep"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoEndereco), DadosDoFornecedor["Endereco"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoNumero), DadosDoFornecedor["Numero"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoBairro), DadosDoFornecedor["Bairro"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoEstado), DadosDoFornecedor["Estado"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCidade), DadosDoFornecedor["Cidade"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoComplemento), DadosDoFornecedor["Complemento"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoObservacao), DadosDoFornecedor["Observacao"]);
        }

        public void PreencherAsInformacoesDaPessoasNaEdicao()
        {
            _driverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoNome, EdicaoDeFornecedorFisicoCompletoModel.NomeDoFornecedorAlterado);
            _driverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoCpf, EdicaoDeFornecedorFisicoCompletoModel.Cpf);
            _driverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoRg, EdicaoDeFornecedorFisicoCompletoModel.Rg);
            _driverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoApelido, EdicaoDeFornecedorFisicoCompletoModel.Apelido);
            _driverService.SelecionarItemComboBox(CadastroDeFornecedorModel.ElementoSexo, 1);
            _driverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoDataDeNascimento, EdicaoDeFornecedorFisicoCompletoModel.DataNascimento);
            _driverService.SelecionarItemComboBox(CadastroDeFornecedorModel.ElementoEstadoCivil, 1);
            _driverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoCep, EdicaoDeFornecedorFisicoCompletoModel.Cep);
            _driverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoEndereco, EdicaoDeFornecedorFisicoCompletoModel.Endereco);
            _driverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoNumero, EdicaoDeFornecedorFisicoCompletoModel.Numero);
            _driverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoBairro, EdicaoDeFornecedorFisicoCompletoModel.Bairro);
            _driverService.SelecionarItemComboBox(CadastroDeFornecedorModel.ElementoEstado, 1);
            _driverService.SelecionarItemComboBox(CadastroDeFornecedorModel.ElementoCidade, 1);
            _driverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoComplemento, EdicaoDeFornecedorFisicoCompletoModel.Complemento);
            _driverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoDescontoPadrao, EdicaoDeFornecedorFisicoCompletoModel.DescontoPadrao);
            _driverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoObservacao, EdicaoDeFornecedorFisicoCompletoModel.Observacao);
        }

        public void VerificarDadosDaPessoaEditados()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoNome), EdicaoDeFornecedorFisicoCompletoModel.NomeDoFornecedorAlterado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCpf), EdicaoDeFornecedorFisicoCompletoModel.CpfComPontos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoRg), EdicaoDeFornecedorFisicoCompletoModel.Rg);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoApelido), EdicaoDeFornecedorFisicoCompletoModel.Apelido);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoSexo), EdicaoDeFornecedorFisicoCompletoModel.Sexo);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoDataDeNascimento), EdicaoDeFornecedorFisicoCompletoModel.DataDeNascimentoPorExtenso);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoEstadoCivil), EdicaoDeFornecedorFisicoCompletoModel.EstadoCivil);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCep), EdicaoDeFornecedorFisicoCompletoModel.CepComPontos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoEndereco), EdicaoDeFornecedorFisicoCompletoModel.Endereco);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoNumero), EdicaoDeFornecedorFisicoCompletoModel.Numero);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoBairro), EdicaoDeFornecedorFisicoCompletoModel.Bairro);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoEstado), EdicaoDeFornecedorFisicoCompletoModel.Estado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCidade), EdicaoDeFornecedorFisicoCompletoModel.Cidade);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoComplemento), EdicaoDeFornecedorFisicoCompletoModel.Complemento);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoDescontoPadrao), EdicaoDeFornecedorFisicoCompletoModel.DescontoPadrao);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoObservacao), EdicaoDeFornecedorFisicoCompletoModel.Observacao);
        }

        public void FluxoDePesquisaDaPessoaEditado(EdicaoDeFornecedorBasePage edicaoDeFornecedorBasePage,
            PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            edicaoDeFornecedorBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("Fornecedor", EdicaoDeFornecedorFisicoCompletoModel.NomeDoFornecedorAlterado);
        }
    }
}
