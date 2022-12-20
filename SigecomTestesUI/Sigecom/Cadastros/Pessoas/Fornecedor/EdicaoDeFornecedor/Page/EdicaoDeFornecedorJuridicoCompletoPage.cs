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
            {"Nome", "CHEF DINO BURGUERIA EIRELI"},
            {"Cnpj", "11.398.116/0001-47"},
            {"Apelido", "CHEF DINO BURGUERIA"},
            {"Cep", "76804-305"},
            {"Endereco", "AVENIDA CAMPOS SALES"},
            {"Numero", "1202"},
            {"Bairro", "AREAL"},
            {"Estado", "RONDÔNIA"},
            {"Cidade", "PORTO VELHO"},
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
