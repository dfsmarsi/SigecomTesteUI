using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using System.Collections.Generic;

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

        private void ClicarBotaoNovo() =>
            ClicarBotaoNovo(CadastroDeColaboradorModel.BotaoNovo);

        public bool ClicarBotaoPesquisar()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeColaboradorModel.BotaoPesquisar);
                return true;
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
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoCpf, _dadosDeColaborador["Cnpj"]);
                DriverService.DigitarNoCampoEnterId(CadastroDeColaboradorModel.ElementoCep, _dadosDeColaborador["Cep"]);
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
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoRg, _dadosDeColaborador["Ie"]);
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoInscricaoSuframa,
                    _dadosDeColaborador["Suframa"]);
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoApelido, _dadosDeColaborador["NomeFantasia"]);
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoComplemento,
                    _dadosDeColaborador["Complemento"]);
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoObservacao,
                    _dadosDeColaborador["Observacao"]);
                CadastrarContatosDoCliente();
                CadastrarInformacoesDoFuncionarioNoCadastroDeColaborador();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void CadastrarContatosDoCliente()
        {
            DriverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoTipoContato, 3);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoContatoDoCliente,
                _dadosDeColaborador["ContatoPrimario"]);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoObsContatoDoCliente,
                _dadosDeColaborador["ObservacaoContatoPrimario"]);
            DriverService.ClicarBotaoId(CadastroDeColaboradorModel.BotaoContato);
            EsperarAcaoEmSegundos(2);
            DriverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoTipoContato, 1);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoContatoDoCliente,
                _dadosDeColaborador["ContatoSecundario"]);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoObsContatoDoCliente,
                _dadosDeColaborador["ObservacaoContatoSecundario"]);
            DriverService.ClicarBotaoId(CadastroDeColaboradorModel.BotaoContato);
        }

        private void CadastrarInformacoesDoFuncionarioNoCadastroDeColaborador()
        {
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoDataAdmissao,
                _dadosDeColaborador["DataAdmissao"]);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoEmailFuncionario,
                _dadosDeColaborador["EmailFuncionario"]);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoDiaPagamento,
                _dadosDeColaborador["DiaPagamento"]);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoSalario, _dadosDeColaborador["Salario"]);
            DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoTelefoneFuncionario,
                _dadosDeColaborador["TelefoneFuncionario"]);
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
