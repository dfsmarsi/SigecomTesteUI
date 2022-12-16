using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System.Collections.Generic;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Factory
{
    public class EdicaoDeClienteJuridicoCompletoPage : IEdicaoDeClientePage
    {
        private readonly DriverService _driverService;

        private static Dictionary<string, string> _dadosDoCliente => new Dictionary<string, string>
        {
            {"TipoPessoa", "JURÍDICA"},
            {"Nacionalidade", "BRASILEIRO(A)"},
            {"Nome", "CLIENTE JURIDICO COMPLETO EDITAR TESTE"},
            {"Cnpj", "08.257.471/0001-91"},
            {"Ie", "123456789"},
            {"Suframa", "123456789"},
            {"NomeFantasia", "COMPLETO EDITAR TESTE"},
            {"Cep", "15700-008"},
            {"Endereco", "RUA 3"},
            {"Numero", "1234"},
            {"Bairro", "CENTRO"},
            {"Estado", "SÃO PAULO"},
            {"Cidade", "JALES"},
            {"Complemento", "CASA"},
            {"Contatos", "CELULAR"},
            {"DescontoPadrao", "5,00"},
            {"Observacao", "OBSERVAÇÃO TESTE"},
            {"TabelaDePreco", "Nenhuma selecionada"},
            {"Grupo", "Nenhum"},
            {"AvisoDeVenda", "AVISO TESTE"}
        };

        public EdicaoDeClienteJuridicoCompletoPage(DriverService driver) => _driverService = driver;

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
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCpf), _dadosDoCliente["Cnpj"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoRg), _dadosDoCliente["Ie"]);

            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoApelido), _dadosDoCliente["NomeFantasia"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCep), _dadosDoCliente["Cep"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEndereco), _dadosDoCliente["Endereco"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNumero), _dadosDoCliente["Numero"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoBairro), _dadosDoCliente["Bairro"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEstado), _dadosDoCliente["Estado"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCidade), _dadosDoCliente["Cidade"]);

            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoComplemento), _dadosDoCliente["Complemento"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoContatos), _dadosDoCliente["Contatos"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoDescontoPadrao), _dadosDoCliente["DescontoPadrao"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoObservacao), _dadosDoCliente["Observacao"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoTabelaDePreco), _dadosDoCliente["TabelaDePreco"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoGrupo), _dadosDoCliente["Grupo"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoAvisoDeVenda), _dadosDoCliente["AvisoDeVenda"]);

        }

        public void PreencherAsInformacoesDaPessoasNaEdicao()
        {
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoNome, EdicaoDeClienteJuridicoCompletoModel.NomeDoClienteAlterado);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoCpf, EdicaoDeClienteJuridicoCompletoModel.Cnpj);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoRg, EdicaoDeClienteJuridicoCompletoModel.Ie);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoApelido, EdicaoDeClienteJuridicoCompletoModel.NomeFantasia);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoCep, EdicaoDeClienteJuridicoCompletoModel.Cep);

            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoEndereco, EdicaoDeClienteJuridicoCompletoModel.Endereco);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoNumero, EdicaoDeClienteJuridicoCompletoModel.Numero);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoBairro, EdicaoDeClienteJuridicoCompletoModel.Bairro);
            _driverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoEstado, 1);
            _driverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoCidade, 1);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoComplemento, EdicaoDeClienteJuridicoCompletoModel.Complemento);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoContatos, EdicaoDeClienteJuridicoCompletoModel.Contatos);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoDescontoPadrao, EdicaoDeClienteJuridicoCompletoModel.DescontoPadrao);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoObservacao, EdicaoDeClienteJuridicoCompletoModel.Observacao);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoTabelaDePreco, EdicaoDeClienteJuridicoCompletoModel.TabelaDePreco);
            _driverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoGrupo, 1);
            _driverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoAvisoDeVenda, EdicaoDeClienteJuridicoCompletoModel.AvisoDeVenda);
        }

        public void VerificarDadosDaPessoaEditados()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNome), EdicaoDeClienteJuridicoCompletoModel.NomeDoClienteAlterado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCpf), EdicaoDeClienteJuridicoCompletoModel.CpfComPontos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoRg), EdicaoDeClienteJuridicoCompletoModel.Ie);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoApelido), EdicaoDeClienteJuridicoCompletoModel.NomeFantasia);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCep), EdicaoDeClienteJuridicoCompletoModel.CepComPontos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEndereco), EdicaoDeClienteJuridicoCompletoModel.Endereco);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNumero), EdicaoDeClienteJuridicoCompletoModel.Numero);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoBairro), EdicaoDeClienteJuridicoCompletoModel.Bairro);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEstado), EdicaoDeClienteJuridicoCompletoModel.Estado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCidade), EdicaoDeClienteJuridicoCompletoModel.Cidade);

            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoComplemento), EdicaoDeClienteJuridicoCompletoModel.Complemento);
            //Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoProfissao), EdicaoDeClienteJuridicoCompletoModel.Profissao);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoContatos), EdicaoDeClienteJuridicoCompletoModel.Contatos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoDescontoPadrao), EdicaoDeClienteJuridicoCompletoModel.DescontoPadrao);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoObservacao), EdicaoDeClienteJuridicoCompletoModel.Observacao);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoTabelaDePreco), EdicaoDeClienteJuridicoCompletoModel.TabelaDePreco);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoGrupo), EdicaoDeClienteJuridicoCompletoModel.Grupo);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoAvisoDeVenda), EdicaoDeClienteJuridicoCompletoModel.AvisoDeVenda);
        }

        public void FluxoDePesquisaDaPessoaEditado(EdicaoDeClienteBasePage edicaoDeClienteBasePage,
            PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            edicaoDeClienteBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("cliente", EdicaoDeClienteJuridicoCompletoModel.NomeDoClienteAlterado);
        }
    }
}
