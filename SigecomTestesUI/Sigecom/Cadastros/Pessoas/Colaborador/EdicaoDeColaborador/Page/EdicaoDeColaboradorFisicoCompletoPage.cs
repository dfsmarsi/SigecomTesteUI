using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page
{
    public class EdicaoDeColaboradorFisicoCompletoPage: IEdicaoDeColaboradorPage
    {
        private readonly DriverService _driverService;
        private static Dictionary<string, string> DadosDoColaborador => new Dictionary<string, string>
        {
            {"TipoPessoa", "FÍSICA"},
            {"Nacionalidade", "BRASILEIRO(A)"},
            {"Nome", "COLABORADOR FISICA COMPLETO EDITAR TESTE"},
            {"Cpf", "860.920.330-11"},
            {"Rg", "204917633"},
            {"Apelido", "COMPLETO FISICA EDITAR TESTE"},
            {"Sexo", "Masculino"},
            {"DataNascimento", "terça-feira, 4 de janeiro de 2000"},
            {"EstadoCivil", "Solteiro(a)"},
            {"Cep", "15700-008"},
            {"Endereco", "RUA 3"},
            {"Numero", "1234"},
            {"Bairro", "CENTRO"},
            {"Estado", "SÃO PAULO"},
            {"Cidade", "JALES"},
            {"Complemento", "CASA"},
            {"DescontoPadrao", "5,00"},
            {"Observacao", "OBSERVAÇÃO TESTE"},
            {"DataAdmissao", "01/01/2015"},
            {"EmailFuncionario", "teste@sistemasbr.net"},
            {"DiaPagamento", "07"},
            {"Salario", "800,00"},
            {"TelefoneFuncionario", "(11) 96405-6467"},
            {"Cargo", "TESTER"}
        };

        public EdicaoDeColaboradorFisicoCompletoPage(DriverService driverService) => _driverService = driverService;

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
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCpf), DadosDoColaborador["Cpf"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoRg), DadosDoColaborador["Rg"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoApelido), DadosDoColaborador["Apelido"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoSexo), DadosDoColaborador["Sexo"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoDataDeNascimento), DadosDoColaborador["DataNascimento"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEstadoCivil), DadosDoColaborador["EstadoCivil"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCep), DadosDoColaborador["Cep"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEndereco), DadosDoColaborador["Endereco"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoNumero), DadosDoColaborador["Numero"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoBairro), DadosDoColaborador["Bairro"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEstado), DadosDoColaborador["Estado"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCidade), DadosDoColaborador["Cidade"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoComplemento), DadosDoColaborador["Complemento"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoDescontoPadrao), DadosDoColaborador["DescontoPadrao"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoObservacao), DadosDoColaborador["Observacao"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoDataAdmissao), DadosDoColaborador["DataAdmissao"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEmailFuncionario), DadosDoColaborador["EmailFuncionario"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoDiaPagamento), DadosDoColaborador["DiaPagamento"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoSalario), DadosDoColaborador["Salario"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoTelefoneFuncionario), DadosDoColaborador["TelefoneFuncionario"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCargo), DadosDoColaborador["Cargo"]);
        }

        public void PreencherAsInformacoesDaPessoasNaEdicao()
        {
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoNome, EdicaoDeColaboradorFisicoCompletoModel.NomeDoColaboradorAlterado);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoCpf, EdicaoDeColaboradorFisicoCompletoModel.Cpf);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoRg, EdicaoDeColaboradorFisicoCompletoModel.Rg);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoApelido, EdicaoDeColaboradorFisicoCompletoModel.Apelido);
            _driverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoSexo, 1);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoDataDeNascimento, EdicaoDeColaboradorFisicoCompletoModel.DataNascimento);
            _driverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoEstadoCivil, 1);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoCep, EdicaoDeColaboradorFisicoCompletoModel.Cep);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoEndereco, EdicaoDeColaboradorFisicoCompletoModel.Endereco);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoNumero, EdicaoDeColaboradorFisicoCompletoModel.Numero);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoBairro, EdicaoDeColaboradorFisicoCompletoModel.Bairro);
            _driverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoEstado, 1);
            _driverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoCidade, 1);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoComplemento, EdicaoDeColaboradorFisicoCompletoModel.Complemento);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoDescontoPadrao, EdicaoDeColaboradorFisicoCompletoModel.DescontoPadrao);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoObservacao, EdicaoDeColaboradorFisicoCompletoModel.Observacao);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoDataAdmissao, EdicaoDeColaboradorFisicoCompletoModel.DataAdmissao);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoEmailFuncionario, EdicaoDeColaboradorFisicoCompletoModel.EmailFuncionario);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoDiaPagamento, EdicaoDeColaboradorFisicoCompletoModel.DiaPagamento);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoSalario, EdicaoDeColaboradorFisicoCompletoModel.Salario);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoTelefoneFuncionario, EdicaoDeColaboradorFisicoCompletoModel.TelefoneFuncionario);
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoCargo, EdicaoDeColaboradorFisicoCompletoModel.Cargo);
        }

        public void VerificarDadosDaPessoaEditados()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoNome), EdicaoDeColaboradorFisicoCompletoModel.NomeDoColaboradorAlterado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCpf), EdicaoDeColaboradorFisicoCompletoModel.CpfComPontos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoRg), EdicaoDeColaboradorFisicoCompletoModel.Rg);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoApelido), EdicaoDeColaboradorFisicoCompletoModel.Apelido);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoSexo), EdicaoDeColaboradorFisicoCompletoModel.Sexo);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoDataDeNascimento), EdicaoDeColaboradorFisicoCompletoModel.DataDeNascimentoPorExtenso);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEstadoCivil), EdicaoDeColaboradorFisicoCompletoModel.EstadoCivil);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCep), EdicaoDeColaboradorFisicoCompletoModel.CepComPontos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEndereco), EdicaoDeColaboradorFisicoCompletoModel.Endereco);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoNumero), EdicaoDeColaboradorFisicoCompletoModel.Numero);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoBairro), EdicaoDeColaboradorFisicoCompletoModel.Bairro);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEstado), EdicaoDeColaboradorFisicoCompletoModel.Estado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCidade), EdicaoDeColaboradorFisicoCompletoModel.Cidade);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoComplemento), EdicaoDeColaboradorFisicoCompletoModel.Complemento);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoDescontoPadrao), EdicaoDeColaboradorFisicoCompletoModel.DescontoPadrao);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoObservacao), EdicaoDeColaboradorFisicoCompletoModel.Observacao);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoDataAdmissao), EdicaoDeColaboradorFisicoCompletoModel.DataAdmissao);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEmailFuncionario), EdicaoDeColaboradorFisicoCompletoModel.EmailFuncionario);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoDiaPagamento), EdicaoDeColaboradorFisicoCompletoModel.DiaPagamento);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoSalario), EdicaoDeColaboradorFisicoCompletoModel.Salario);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoTelefoneFuncionario), EdicaoDeColaboradorFisicoCompletoModel.TelefoneFuncionario);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCargo), EdicaoDeColaboradorFisicoCompletoModel.Cargo);
        }

        public void FluxoDePesquisaDaPessoaEditado(EdicaoDeColaboradorBasePage edicaoDeColaboradorBasePage,
            PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            edicaoDeColaboradorBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("colaborador", EdicaoDeColaboradorFisicoCompletoModel.NomeDoColaboradorAlterado);
        }
    }
}
