using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using System.Collections.Generic;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador
{
    public class CadastroDeColaboradorJuridicoPage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dadosDeColaborador;

        public CadastroDeColaboradorJuridicoPage(DriverService driver, Dictionary<string, string> dadosDoCliente) :
            base(driver) =>
            _dadosDeColaborador = dadosDoCliente;

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CadastroDeColaboradorModel.BotaoMenu);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CadastroDeColaboradorModel.BotaoSubMenu);

        private void ClicarBotaoNovo()
        {
            try
            {
                ClicarBotao(CadastroDeColaboradorModel.BotaoNovo);
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
                ClicarBotao(CadastroDeColaboradorModel.BotaoPesquisar);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public bool VerificarTipoPessoa()
        {
            var valorTipoPessoa = DriverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoTipoPessoa);
            return valorTipoPessoa.Equals("JURÍDICA");
        }

        public bool PreencherCamposSimples()
        {
            try
            {
                DriverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoTipoPessoa, 1);
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoNome, _dadosDeColaborador["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoCep, _dadosDeColaborador["Cep"]);
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoNumero, _dadosDeColaborador["Numero"]);
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
                DriverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoTipoPessoa, 1);
                DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeColaboradorModel.ElementoCpf, _dadosDeColaborador["Cnpj"], Keys.Enter);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void VerificarCamposDoCarregados()
        {
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoNome), _dadosDeColaborador["Nome"]);
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCep), _dadosDeColaborador["Cep"]);
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoNumero), _dadosDeColaborador["Numero"]);
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEndereco), _dadosDeColaborador["Endereco"]);
        }

        public bool GravarCadastro()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeColaboradorModel.BotaoGravar);
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
                DriverService.FecharJanelaComEsc(CadastroDeColaboradorModel.TelaCadastroColaborador);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public void AcessarTelaDeCadastroDeColaborador()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoNovo();
            VerificarTipoPessoa();
        }

        public void PesquisarColaboradorGravado(ILifetimeScope beginLifetimeScope)
        {
            ClicarBotaoPesquisar();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);
            pesquisaDePessoaPage.PesquisarPessoa("colaborador", _dadosDeColaborador["Nome"]);
            var existeClienteNaPesquisa = pesquisaDePessoaPage.VerificarSeExistePessoaNaGrid(_dadosDeColaborador["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            pesquisaDePessoaPage.FecharJanelaComEsc("colaborador");
            FecharJanelaComEsc();
        }
    }
}
