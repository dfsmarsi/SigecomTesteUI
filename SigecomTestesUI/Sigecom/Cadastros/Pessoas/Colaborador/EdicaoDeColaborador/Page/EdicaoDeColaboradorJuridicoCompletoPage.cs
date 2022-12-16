using System;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page
{
    public class EdicaoDeColaboradorJuridicoCompletoPage : IEdicaoDeColaboradorPage
    {
        private readonly DriverService _driverService;
        private static Dictionary<string, string> DadosDoColaborador => new Dictionary<string, string>
        {
            {"TipoPessoa", "JURÍDICO"},
            {"Nacionalidade", "BRASILEIRO(A)"},
            {"Nome", "FELIPE DE ARGOLO BENICIO 02713305543"},
            {"Cnpj", "26.726.069/0001-90"},
            {"Apelido", "BENICIO FOTOGRAFO"},
            {"Cep", "41342-010"},
            {"Endereco", "RUA JORNALISTA ARMANDO LOBRACCI NETO"},
            {"Numero", "303"},
            {"Bairro", "FAZENDA GRANDE II"},
            {"Estado", "BAHIA"},
            {"Cidade", "SALVADOR"},
            {"DescontoPadrao", "0,00"},
        };

        public EdicaoDeColaboradorJuridicoCompletoPage(DriverService driverService) => _driverService = driverService;

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
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCpf), DadosDoColaborador["Cnpj"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoApelido), DadosDoColaborador["Apelido"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCep), DadosDoColaborador["Cep"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEndereco), DadosDoColaborador["Endereco"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoNumero), DadosDoColaborador["Numero"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoBairro), DadosDoColaborador["Bairro"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEstado), DadosDoColaborador["Estado"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCidade), DadosDoColaborador["Cidade"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoDescontoPadrao), DadosDoColaborador["DescontoPadrao"]);
        }

        public void PreencherAsInformacoesDaPessoasNaEdicao()
        {
            _driverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeColaboradorModel.ElementoCpf, EdicaoDeColaboradorJuridicoCompletoModel.Cnpj, Keys.Enter);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoNome), EdicaoDeColaboradorJuridicoCompletoModel.NomeDoColaboradorAlterado);
        }

        public void VerificarDadosDaPessoaEditados()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoNome), EdicaoDeColaboradorJuridicoCompletoModel.NomeDoColaboradorAlterado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCpf), EdicaoDeColaboradorJuridicoCompletoModel.CnpjComPontos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoApelido), EdicaoDeColaboradorJuridicoCompletoModel.Apelido);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCep), EdicaoDeColaboradorJuridicoCompletoModel.CepComPontos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEndereco), EdicaoDeColaboradorJuridicoCompletoModel.Endereco);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoNumero), EdicaoDeColaboradorJuridicoCompletoModel.Numero);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoBairro), EdicaoDeColaboradorJuridicoCompletoModel.Bairro);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEstado), EdicaoDeColaboradorJuridicoCompletoModel.Estado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCidade), EdicaoDeColaboradorJuridicoCompletoModel.Cidade);
        }

        public void FluxoDePesquisaDaPessoaEditado(EdicaoDeColaboradorBasePage edicaoDeColaboradorBasePage,
            PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            edicaoDeColaboradorBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("colaborador", EdicaoDeColaboradorJuridicoCompletoModel.NomeDoColaboradorAlterado);
        }
    }
}
