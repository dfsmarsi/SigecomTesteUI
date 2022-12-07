using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.Model;
using System;
using System.Collections.Generic;
using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador
{
    public class CadastroDeColaboradorFisicoPage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dadosDeColaborador;

        public CadastroDeColaboradorFisicoPage(DriverService driver, Dictionary<string, string> dadosDoCliente) :
            base(driver) =>
            _dadosDeColaborador = dadosDoCliente;

        private void ClicarNaOpcaoDoMenu()
        {
            try
            {
                AcessarOpcaoMenu(CadastroDeColaboradorModel.BotaoMenu);
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
                AcessarOpcaoSubMenu(CadastroDeColaboradorModel.BotaoSubMenu);
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
            return valorTipoPessoa.Equals("FÍSICA");
        }

        public bool PreencherCamposSimples()
        {
            try
            {
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoNome, _dadosDeColaborador["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoCpf, _dadosDeColaborador["Cpf"]);
                DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeColaboradorModel.ElementoCep, _dadosDeColaborador["Cep"], Keys.Enter);
                EsperarAcaoEmSegundos(3);
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
                PreencherCamposSimples();
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoRg, _dadosDeColaborador["Rg"]);
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoApelido, _dadosDeColaborador["Apelido"]);
                DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeColaboradorModel.ElementoDataDeNascimento, _dadosDeColaborador["DataNascimento"], Keys.Enter);
                DriverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoSexo, 1);
                DriverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoEstadoCivil, 1);
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoComplemento, _dadosDeColaborador["Complemento"]);
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoObservacao, _dadosDeColaborador["Observacao"]);
                CadastrarContatosDoColaborador();
                CadastrarInformacoesDoFuncionarioNoCadastroDeColaborador();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void CadastrarContatosDoColaborador()
        {
            DriverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoTipoContato, 3);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoContatoDoCliente, _dadosDeColaborador["ContatoPrimario"]);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoObsContatoDoCliente, _dadosDeColaborador["ObservacaoContatoPrimario"]);
            DriverService.ClicarBotaoId(CadastroDeColaboradorModel.BotaoContato);
            EsperarAcaoEmSegundos(2);
            DriverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoTipoContato, 1);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoContatoDoCliente, _dadosDeColaborador["ContatoSecundario"]);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoObsContatoDoCliente, _dadosDeColaborador["ObservacaoContatoSecundario"]);
            DriverService.ClicarBotaoId(CadastroDeColaboradorModel.BotaoContato);
        }

        private void CadastrarInformacoesDoFuncionarioNoCadastroDeColaborador()
        {
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoDataAdmissao, _dadosDeColaborador["DataAdmissao"]);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoEmailFuncionario, _dadosDeColaborador["EmailFuncionario"]);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoDiaPagamento, _dadosDeColaborador["DiaPagamento"]);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoSalario, _dadosDeColaborador["Salario"]);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoTelefoneFuncionario, _dadosDeColaborador["TelefoneFuncionario"]);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoCargo, _dadosDeColaborador["Cargo"]);
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

        public bool FecharJanelaCadastroColaboradorComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeColaboradorModel.TelaCadastroColaborador);
                return true;
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
            FecharJanelaCadastroColaboradorComEsc();
        }
    }
}
