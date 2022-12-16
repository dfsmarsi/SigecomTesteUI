using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System.Collections.Generic;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page
{
    public class EdicaoDeClienteFisicoCompletoPage : IEdicaoDeClientePage
    {
        private readonly DriverService _driverService;

        private static Dictionary<string, string> _dadosDoCliente => new Dictionary<string, string>
        {
            {"TipoPessoa", "FÍSICA"},
            {"Nacionalidade", "BRASILEIRO(A)"},
            {"Nome", "CLIENTE FISICO COMPLETO EDITAR TESTE"},
            {"Cpf", "941.543.670-05"},
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
            {"Profissao", "PROGRAMADOR(A)"},
            {"Contatos", "CELULAR"},
            {"DescontoPadrao", "5,00"},
            {"Observacao", "OBSERVAÇÃO TESTE"},
            {"TabelaDePreco", "Nenhuma selecionada"},
            {"Grupo", "Nenhum"},
            {"AvisoDeVenda", "AVISO TESTE"}
        };

        public EdicaoDeClienteFisicoCompletoPage(DriverService driver) => _driverService = driver;

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
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCpf), _dadosDoCliente["Cpf"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoRg), _dadosDoCliente["Rg"]);

            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoApelido), _dadosDoCliente["Apelido"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoSexo), _dadosDoCliente["Sexo"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoDataDeNascimento), _dadosDoCliente["DataNascimento"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEstadoCivil), _dadosDoCliente["EstadoCivil"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCep), _dadosDoCliente["Cep"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEndereco), _dadosDoCliente["Endereco"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNumero), _dadosDoCliente["Numero"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoBairro), _dadosDoCliente["Bairro"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEstado), _dadosDoCliente["Estado"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCidade), _dadosDoCliente["Cidade"]);

            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoComplemento), _dadosDoCliente["Complemento"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoProfissao), _dadosDoCliente["Profissao"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoContatos), _dadosDoCliente["Contatos"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoDescontoPadrao), _dadosDoCliente["DescontoPadrao"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoObservacao), _dadosDoCliente["Observacao"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoTabelaDePreco), _dadosDoCliente["TabelaDePreco"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoGrupo), _dadosDoCliente["Grupo"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoAvisoDeVenda), _dadosDoCliente["AvisoDeVenda"]);

        }

        public void PreencherAsInformacoesDaPessoasNaEdicao()
        {
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoNome, EdicaoDeClienteFisicoCompletoModel.NomeDoClienteAlterado);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoCpf, EdicaoDeClienteFisicoCompletoModel.Cpf);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoRg, EdicaoDeClienteFisicoCompletoModel.Rg);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoApelido, EdicaoDeClienteFisicoCompletoModel.Apelido);
            _driverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoSexo, 1);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoDataDeNascimento, EdicaoDeClienteFisicoCompletoModel.DataNascimento);
            _driverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoEstadoCivil, 1);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoCep, EdicaoDeClienteFisicoCompletoModel.Cep);

            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoEndereco, EdicaoDeClienteFisicoCompletoModel.Endereco);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoNumero, EdicaoDeClienteFisicoCompletoModel.Numero);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoBairro, EdicaoDeClienteFisicoCompletoModel.Bairro);
            _driverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoEstado, 1);
            _driverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoCidade, 1);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoComplemento, EdicaoDeClienteFisicoCompletoModel.Complemento);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoProfissao, EdicaoDeClienteFisicoCompletoModel.Profissao);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoContatos, EdicaoDeClienteFisicoCompletoModel.Contatos);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoDescontoPadrao, EdicaoDeClienteFisicoCompletoModel.DescontoPadrao);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoObservacao, EdicaoDeClienteFisicoCompletoModel.Observacao);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoTabelaDePreco, EdicaoDeClienteFisicoCompletoModel.TabelaDePreco);
            _driverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoGrupo, 1);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoAvisoDeVenda, EdicaoDeClienteFisicoCompletoModel.AvisoDeVenda);
        }

        public void VerificarDadosDaPessoaEditados()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNome), EdicaoDeClienteFisicoCompletoModel.NomeDoClienteAlterado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCpf), EdicaoDeClienteFisicoCompletoModel.CpfComPontos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoRg), EdicaoDeClienteFisicoCompletoModel.Rg);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoApelido), EdicaoDeClienteFisicoCompletoModel.Apelido);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoSexo), EdicaoDeClienteFisicoCompletoModel.Sexo);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoDataDeNascimento), EdicaoDeClienteFisicoCompletoModel.DataDeNascimentoPorExtenso);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEstadoCivil), EdicaoDeClienteFisicoCompletoModel.EstadoCivil);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCep), EdicaoDeClienteFisicoCompletoModel.CepComPontos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEndereco), EdicaoDeClienteFisicoCompletoModel.Endereco);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNumero), EdicaoDeClienteFisicoCompletoModel.Numero);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoBairro), EdicaoDeClienteFisicoCompletoModel.Bairro);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEstado), EdicaoDeClienteFisicoCompletoModel.Estado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCidade), EdicaoDeClienteFisicoCompletoModel.Cidade);

            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoComplemento), EdicaoDeClienteFisicoCompletoModel.Complemento);
            //Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoProfissao), EdicaoDeClienteFisicoCompletoModel.Profissao);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoContatos), EdicaoDeClienteFisicoCompletoModel.Contatos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoDescontoPadrao), EdicaoDeClienteFisicoCompletoModel.DescontoPadrao);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoObservacao), EdicaoDeClienteFisicoCompletoModel.Observacao);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoTabelaDePreco), EdicaoDeClienteFisicoCompletoModel.TabelaDePreco);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoGrupo), EdicaoDeClienteFisicoCompletoModel.Grupo);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoAvisoDeVenda), EdicaoDeClienteFisicoCompletoModel.AvisoDeVenda);
        }

        public void FluxoDePesquisaDaPessoaEditado(EdicaoDeClienteBasePage edicaoDeClienteBasePage,
            PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            edicaoDeClienteBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("cliente", EdicaoDeClienteFisicoCompletoModel.NomeDoClienteAlterado);
        }
    }
}
