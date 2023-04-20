using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page
{
    public class EdicaoDeFornecedorJuridicoCompletoPage: IEdicaoDeFornecedorPage
    {
        private readonly DriverService _driverService;

        private static Dictionary<string, string> DadosDoFornecedor => new Dictionary<string, string>
        {
            {"TipoPessoa", "JURÍDICA"},
            {"Nacionalidade", "BRASILEIRO(A)"},
            {"Nome", "FORNECEDOR JURIDICO COMPLETO ORIGINAL"},
            {"Cnpj", "56.714.181/0001-72"},
            {"Apelido", "FORNECEDOR JURIDICO COMPLETO"},
            {"Cep", "15700-008"},
            {"Endereco", "RUA 3"},
            {"Numero", "111"},
            {"Bairro", "CENTRO"},
            {"Estado", "SÃO PAULO"},
            {"Cidade", "JALES"},
        };

        public EdicaoDeFornecedorJuridicoCompletoPage(DriverService driverService) => _driverService = driverService;

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
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCpf), DadosDoFornecedor["Cnpj"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoApelido), DadosDoFornecedor["Apelido"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCep), DadosDoFornecedor["Cep"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoEndereco), DadosDoFornecedor["Endereco"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoNumero), DadosDoFornecedor["Numero"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoBairro), DadosDoFornecedor["Bairro"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoEstado), DadosDoFornecedor["Estado"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCidade), DadosDoFornecedor["Cidade"]);
        }

        public void PreencherAsInformacoesDaPessoasNaEdicao()
        {
            _driverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeFornecedorModel.ElementoCpf, EdicaoDeFornecedorJuridicoCompletoModel.Cnpj, Keys.Enter);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoNome), EdicaoDeFornecedorJuridicoCompletoModel.NomeDoFornecedorAlterado);
        }

        public void VerificarDadosDaPessoaEditados()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoNome), EdicaoDeFornecedorJuridicoCompletoModel.NomeDoFornecedorAlterado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCpf), EdicaoDeFornecedorJuridicoCompletoModel.CnpjComPontos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCep), EdicaoDeFornecedorJuridicoCompletoModel.CepComPontos);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoEndereco), EdicaoDeFornecedorJuridicoCompletoModel.Endereco);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoNumero), EdicaoDeFornecedorJuridicoCompletoModel.Numero);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoBairro), EdicaoDeFornecedorJuridicoCompletoModel.Bairro);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoEstado), EdicaoDeFornecedorJuridicoCompletoModel.Estado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCidade), EdicaoDeFornecedorJuridicoCompletoModel.Cidade);
        }

        public void FluxoDePesquisaDaPessoaEditado(EdicaoDeFornecedorBasePage edicaoDeFornecedorBasePage,
            PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            edicaoDeFornecedorBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("fornecedor", EdicaoDeFornecedorJuridicoCompletoModel.NomeDoFornecedorAlterado);
        }
    }
}
