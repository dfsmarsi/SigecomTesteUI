using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page
{
    public class EdicaoDeClienteJuridicoCompletoPage : IEdicaoDeClientePage
    {
        private readonly DriverService _driverService;

        private static Dictionary<string, string> _dadosDoCliente => new Dictionary<string, string>
        {
            {"TipoPessoa", "JURÍDICA"},
            {"Nacionalidade", "BRASILEIRO(A)"},
            {"Nome", "CLIENTE JURIDICO COMPLETO EDITAR TESTE"},
            {"Cnpj", "23.423.959/0001-21"},
            {"Cep", "15720-000"},
            {"Endereco", "AVENIDA DA ALEGRIA"},
            {"Numero", "0001"},
            {"Bairro", "CENTRO"},
            {"Estado", "SÃO PAULO"},
            {"Cidade", "PALMEIRA D OESTE"}
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
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCep), _dadosDoCliente["Cep"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEndereco), _dadosDoCliente["Endereco"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNumero), _dadosDoCliente["Numero"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoBairro), _dadosDoCliente["Bairro"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEstado), _dadosDoCliente["Estado"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCidade), _dadosDoCliente["Cidade"]);
        }

        public void PreencherAsInformacoesDaPessoasNaEdicao()
        {
            _driverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeClienteModel.ElementoCpf, EdicaoDeClienteJuridicoCompletoModel.Cnpj, Keys.Enter); 
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNome), EdicaoDeClienteJuridicoCompletoModel.NomeDoClienteAlterado);
        }

        public void VerificarDadosDaPessoaEditados()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNome), EdicaoDeClienteJuridicoCompletoModel.NomeDoClienteAlterado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCpf), EdicaoDeClienteJuridicoCompletoModel.CnpjComPontos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCep), EdicaoDeClienteJuridicoCompletoModel.CepComPontos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEndereco), EdicaoDeClienteJuridicoCompletoModel.Endereco);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNumero), EdicaoDeClienteJuridicoCompletoModel.Numero);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoBairro), EdicaoDeClienteJuridicoCompletoModel.Bairro);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEstado), EdicaoDeClienteJuridicoCompletoModel.Estado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCidade), EdicaoDeClienteJuridicoCompletoModel.Cidade);
        }

        public void FluxoDePesquisaDaPessoaEditado(EdicaoDeClienteBasePage edicaoDeClienteBasePage,
            PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            edicaoDeClienteBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("cliente", EdicaoDeClienteJuridicoCompletoModel.NomeDoClienteAlterado);
        }
    }
}
