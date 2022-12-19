using System;
using System.Collections.Generic;
using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeColaborador.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeColaborador.Page
{
    public class CadastroDeFornecedorJuridicoPage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dadosDeFornecedor;

        public CadastroDeFornecedorJuridicoPage(DriverService driver, Dictionary<string, string> dadosDeFornecedor) :
            base(driver) =>
            _dadosDeFornecedor = dadosDeFornecedor;

        private void ClicarNaOpcaoDoMenu()
        {
            try
            {
                AcessarOpcaoMenu(CadastroDeFornecedorModel.BotaoMenu);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        private void ClicarNaOpcaoDoSubMenu()
        {
            try
            {
                AcessarOpcaoSubMenu(CadastroDeFornecedorModel.BotaoSubMenu);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        private void ClicarBotaoNovo()
        {
            try
            {
                ClicarBotao(CadastroDeFornecedorModel.BotaoNovo);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        private void ClicarBotaoPesquisar()
        {
            try
            {
                ClicarBotao(CadastroDeFornecedorModel.BotaoPesquisar);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public bool VerificarTipoPessoa()
        {
            var valorTipoPessoa = DriverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoTipoPessoa);
            return valorTipoPessoa.Equals("JURÍDICA");
        }

        public bool PreencherCamposSimples()
        {
            try
            {
                DriverService.SelecionarItemComboBox(CadastroDeFornecedorModel.ElementoTipoPessoa, 1);
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoNome, _dadosDeFornecedor["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoCep, _dadosDeFornecedor["Cep"]);
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoNumero, _dadosDeFornecedor["Numero"]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool PreencherCamposCompleto()
        {
            try
            {
                DriverService.SelecionarItemComboBox(CadastroDeFornecedorModel.ElementoTipoPessoa, 1);
                DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeFornecedorModel.ElementoCpf, _dadosDeFornecedor["Cnpj"], Keys.Enter);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void VerificarCamposDoCarregados()
        {
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoNome), _dadosDeFornecedor["Nome"]);
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoCep), _dadosDeFornecedor["Cep"]);
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoNumero), _dadosDeFornecedor["Numero"]);
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoEndereco), _dadosDeFornecedor["Endereco"]);
        }


        public bool GravarCadastro()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeFornecedorModel.BotaoGravar);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        private void FecharJanelaCadastroFornecedorComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeFornecedorModel.TelaCadastroFornecedor);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public void AcessarTelaDeCadastroDeFornecedor()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoNovo();
            VerificarTipoPessoa();
        }

        public void PesquisarFornecedorGravado(ILifetimeScope beginLifetimeScope)
        {
            ClicarBotaoPesquisar();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);
            pesquisaDePessoaPage.PesquisarPessoa("fornecedor", _dadosDeFornecedor["Nome"]);
            var existeClienteNaPesquisa = pesquisaDePessoaPage.VerificarSeExistePessoaNaGrid(_dadosDeFornecedor["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            pesquisaDePessoaPage.FecharJanelaComEsc("fornecedor");
            FecharJanelaCadastroFornecedorComEsc();
        }
    }
}
