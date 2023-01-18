using System;
using System.Collections.Generic;
using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Page
{
    public class CadastroDeClienteJuridicoPage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dadosDoCliente;

        public CadastroDeClienteJuridicoPage(DriverService driver, Dictionary<string, string> dadosDoCliente) : base(driver) =>
            _dadosDoCliente = dadosDoCliente;

        private void ClicarNaOpcaoDoMenu()
        {
            try
            {
                AcessarOpcaoMenu(CadastroDeClienteModel.BotaoMenu);
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
                AcessarOpcaoSubMenu(CadastroDeClienteModel.BotaoSubMenu);
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
                ClicarBotaoName(CadastroDeClienteModel.BotaoNovo);
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
                ClicarBotaoName(CadastroDeClienteModel.BotaoPesquisar);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public bool VerificarTipoPessoa()
        {
            var valorTipoPessoa = DriverService.ObterValorElementoId(CadastroDeClienteModel.ElementoTipoPessoa);
            return valorTipoPessoa.Equals("JURÍDICA");
        }

        public bool PreencherCamposSimples()
        {
            try
            {
                DriverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoTipoPessoa, 1);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoNome, _dadosDoCliente["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoCep, _dadosDoCliente["Cep"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoNumero, _dadosDoCliente["Numero"]);
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
                DriverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoTipoPessoa, 1);
                DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeClienteModel.ElementoCpf, _dadosDoCliente["Cnpj"], Keys.Enter);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void VerificarCamposDoCarregados()
        {
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNome), _dadosDoCliente["Nome"]);
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeClienteModel.ElementoCep), _dadosDoCliente["Cep"]);
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeClienteModel.ElementoNumero), _dadosDoCliente["Numero"]);
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeClienteModel.ElementoEndereco), _dadosDoCliente["Endereco"]);
        }


        public bool GravarCadastro()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeClienteModel.BotaoGravar);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        private void FecharJanelaComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeClienteModel.ElementoTelaCadastroCliente);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public void AcessarTelaDeCadastroDeCliente()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoNovo();
            VerificarTipoPessoa();
        }

        public void PesquisarClienteGravado(ILifetimeScope beginLifetimeScope)
        {
            ClicarBotaoPesquisar();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);
            pesquisaDePessoaPage.PesquisarPessoa("cliente", _dadosDoCliente["Nome"]);
            var existeClienteNaPesquisa = pesquisaDePessoaPage.VerificarSeExistePessoaNaGrid(_dadosDoCliente["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            pesquisaDePessoaPage.FecharJanelaComEsc("cliente");
            FecharJanelaComEsc();
        }
    }
}
